using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CardManagement
{
    public partial class Form_Download : Form
    {
        public Form_Download()
        {
            InitializeComponent();
        }

        //创建独立的SDK类动态
        //public  zkemkeeper.CZKEMClass zkem = new zkemkeeper.CZKEMClass();
        
        /// <summary>
        /// 页面加载时加载
        /// </summary>
        private void Form_Download_Load(object sender, EventArgs e)
        {
            this.listViewDepartment.View = View.Details;
            this.listViewDepartment.Columns.Add("卡机所属部门", 120, HorizontalAlignment.Left);  //将列头添加到ListView控件。
            //向listView中添加项
            DBUtility.DbHelperSQL.connectionString = NH.CardManagement.Win.systemClass.connectString.GetConnectString();
            string sql = "select distinct(Department)  from Tb_Machines ";
            try
            {
                DataTable DT = CardManagement.DBUtility.DbHelperSQL.Query(sql).Tables[0];
                if (DT.Rows.Count != 0)
                {
                    this.listViewDepartment.BeginUpdate();
                    ListViewItem lvi1 = new ListViewItem();
                    lvi1.ImageIndex = 0;
                    lvi1.Text = "南华厂";
                    this.listViewDepartment.Items.Add(lvi1);
                    DataRow[] DR = DT.Select();
                    for (int i = 0; i < DR.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageIndex = i + 1;
                        lvi.Text = DR[i]["Department"].ToString();
                        this.listViewDepartment.Items.Add(lvi);
                    }
                    this.listViewDepartment.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                NH.Class.Log.WriteLog.Write("CardManagement.Form_Download", "listViewDepartment", "加载listViewDepartment失败", ex, NH.Class.Log.ErrorLogType.ErrorLog);
            }
            // 加载dataGridViewMachines列表
            sql = "select machineID as '卡机名称',Department as '所属部门', Address as '卡机位置' ,DeptNo as '部门编号',IP as 'IP地址' from Tb_Machines  order by IP";
           DataTable DTM = CardManagement.DBUtility.DbHelperSQL.Query(sql).Tables[0];
            dataGridViewMachines.DataSource = DTM;
            this.Tag = DTM;
        }

        /// <summary>
        /// 当改变listView里面的值时引发的操作
        /// </summary>
        private void listViewDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDepartment.SelectedItems.Count > 0)
            {
                int dvr=0;
                string bm = this.listViewDepartment.FocusedItem.SubItems[0].Text;
                if (bm == "南华厂")
                {
                    dataGridViewMachines.DataSource = this.Tag;
                    dvr = this.dataGridViewMachines.Rows.GetRowCount(DataGridViewElementStates.Visible);
                    this.TextBoxDisplay.Text = "南华厂共有" + dvr.ToString() + "个卡机";
                }
                else
                {
                    DataTable DT =(DataTable) this.Tag;
                    DataView dv = new DataView(DT, "所属部门='" + bm + "'", "IP地址 ASC", DataViewRowState.CurrentRows);
                    dataGridViewMachines.DataSource = dv;
                    dvr = this.dataGridViewMachines.Rows.GetRowCount(DataGridViewElementStates.Visible);
                    this.TextBoxDisplay.Text = bm+"共有" + dvr+ "个卡机";
                }
            }
        }

        /// <summary>
        /// 点击下载数据加载
        /// </summary>
        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            string sdwEnrollNumber=null;//员工卡号
            int idwVerifyMode=0;//打卡类型
            int idwInOutMode=0;//
            int idwYear=0;//年
            int idwMonth=0;//月
            int idwDay=0;//日
            int idwHour=0;//时
            int  idwMinute=0;//分
            int  idwSecond=0;//秒
            int  idwWorkcode=0;//workcode值
            int idwErrorCode=0;//错误代码
            int Total ;//考勤的总记录数
            int count = dataGridViewMachines.Rows.GetRowCount(DataGridViewElementStates.Visible);//datagridview中的卡机数
            string[] BSTR = new string[count]; //卡机IP地址
            string display="连接卡机：";//TextBox显示内容

            DataTable DT = new DataTable();//创建一个临时表存放考勤数据
            DT.Columns.Add("IP", System.Type.GetType("System.String"));//添加列
            DT.Columns.Add("WorkNo", System.Type.GetType("System.String"));
            DT.Columns.Add("VerifyMode", System.Type.GetType("System.Int16"));
            DT.Columns.Add("CTime", System.Type.GetType("System.DateTime"));
            DT.Columns.Add("UpdateTime", System.Type.GetType("System.DateTime"));
            for (int i = 0; i < count; i++)
            {
                BSTR[i] = dataGridViewMachines.Rows[i].Cells["IP地址"].Value.ToString();//获取卡机IP地址
                Total = 0;//初始化考勤的总记录数
                string sql = "select maxMum from Tb_MaxCardNum where CIP='" + BSTR[i]+"'";
               idwWorkcode=(int)CardManagement.DBUtility.DbHelperSQL.command(sql);// 查询上次下载的总记录数
                //连接卡机
               if (zkem.Connect_Net(BSTR[i], 4370))
               {
                   display = display + " \r\n" + BSTR[i] + "连接成功";
                   //注册事件
                   zkem.RegEvent(zkem.MachineNumber, 65535);
                   //禁用设备
                   zkem.EnableDevice(zkem.MachineNumber, false);
               if (zkem.ReadGeneralLogData(zkem.MachineNumber))//数据下载到内存成功
                {
                    while (zkem.SSR_GetGeneralLogData(zkem.MachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth,
                         out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//循环从内存中将数据一条一条读取出来，如果成功，执行下面代码
                    {       //将考勤数据存放到临时表中
                        DataRow DR = DT.NewRow();
                        DR["IP"] = BSTR[i];
                        DR["VerifyMode"] = idwVerifyMode;
                        DR["CTime"] =DateTime.Parse( idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour + ":" + idwMinute + ":" + idwSecond);
                        //string sqlwork = "select * from USERINFO where USERID='" + sdwEnrollNumber + "'";
                        DR["WorkNo"] = sdwEnrollNumber;
                       // DR["UpdateTime"]=null;
                        DT.Rows.Add(DR);
                        Total++;//累加记录数
                    }
                    display = display + " \r\n" + BSTR[i] + "卡机:共下载"+Total.ToString()+"考情数据";
                   
                   //将DT里面的数据插入表中
                   string []  DataTableTitle=new string[DT.Columns.Count];
                   for(i=0;i<DT.Columns.Count;i++)
                   {
                        DataTableTitle[i]=DT.Columns[i].ColumnName;
                   }
                   string[] DBColumnName = { "IP", "WorkNo", "VerifyMode", "CTime", "UpdateTime" };
                   if (SqlBulkCopyData(DT, DataTableTitle, DBColumnName, "Tb_MaxCardNum",BSTR[i]))//插入数据成功执行以下语句
                   {
                       display = display + " \r\n" + BSTR[i] + "卡机的考勤记录写入成功";
                   }
                   else
                   {
                       MessageBox.Show(BSTR[i] + "卡机的考勤记录写入失败");
                      //NH.Class.Log.WriteLog.Write("CardManagement.Form_Download", "ButtonDownload", "连接" + BSTR[i] + "卡机失败", NH.Class.Log.NormalLogType.WarnLog);
                   }

                   //清除DT里面的所有行
                    DT.Columns.Clear();
                }
                   else
                {
                    zkem.GetLastError(ref idwErrorCode);//如果失败，提取错误码
                    if (idwErrorCode != 0)//当错误不为0时，将错误写入数据库，以便查询
                    {
                        MessageBox.Show(BSTR[i] + "卡机下载数据失败！");
                        NH.Class.Log.WriteLog.Write("CardManagement.Form_Download", "ButtonDownload", "卡机" + BSTR[i] + "下载数据失败，失败码：" + idwErrorCode.ToString(), NH.Class.Log.NormalLogType.WarnLog);
                    }
                    else//错误代码如果为0，则无考勤数据
                    {
                        display = display + " \r\n" + BSTR[i] + "卡机中无考勤数据！";
                    }
                }
               }
               else
               {
                  //连接卡机失败，写入数据库，以便查询
                       MessageBox.Show(BSTR[i] + "卡机连接失败！");
                       NH.Class.Log.WriteLog.Write("CardManagement.Form_Download", "ButtonDownload", "连接" + BSTR[i] + "卡机失败", NH.Class.Log.NormalLogType.WarnLog);
               }
               //启用设备
               zkem.EnableDevice(zkem.MachineNumber, true);
                //断开连接
               zkem.Disconnect();
                display=display+ " \r\n"+ BSTR[i] + "断开连接";
               this.TextBoxDisplay.Text = display;

            }
        }

        /// <summary>
        /// 点击更新时间时加载
        /// </summary>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string display = "连接卡机：";
            int count = dataGridViewMachines.Rows.GetRowCount(DataGridViewElementStates.Visible);//datagridview中的卡机数
            string[] BSTR = new string[count]; //卡机IP地址
            for (int i = 0; i < count; i++)
            {
                BSTR[i] = this.dataGridViewMachines.Rows[i].Cells["IP地址"].Value.ToString();//获取卡机IP地址
                if (zkem.Connect_Net(BSTR[i], 4370))//连接卡钟，若成功执行下面代码
                {
                    display = display + " \r\n" + BSTR[i] + "连接成功";
                    //注册事件
                    zkem.RegEvent(zkem.MachineNumber, 65535);
                    //禁用设备
                    zkem.EnableDevice(zkem.MachineNumber, false);
                    if (zkem.SetDeviceTime(zkem.MachineNumber))//同步卡钟时间
                    {
                        display = display + " \r\n" + BSTR[i] + "同步系统成功";
                    }
                    else
                    {
                        display = display + " \r\n" + BSTR[i] + "同步系统失败";
                        NH.Class.Log.WriteLog.Write("CardManagement.Form_Download", "ButtonUpdate", "同步" + BSTR[i] + "卡机时间失败", NH.Class.Log.NormalLogType.WarnLog);
                    }
                }
                else
                {
                    //连接卡机失败，写入数据库，以便查询
                    MessageBox.Show(BSTR[i] + "卡机连接失败！");
                    NH.Class.Log.WriteLog.Write("CardManagement.Form_Download", "ButtonDownload", "连接" + BSTR[i] + "卡机失败", NH.Class.Log.NormalLogType.WarnLog);
                }
                //启用设备
                zkem.EnableDevice(zkem.MachineNumber, true);
                //断开连接
                zkem.Disconnect();
                display = display + " \r\n" + BSTR[i] + "断开连接";
                this.TextBoxDisplay.Text = display;
            }

        }

        /// <summary>
        /// 点击清除数据时加载
        /// </summary>
        private void ButtonEmpty_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 当点击菜单是发生
        /// </summary>

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        /// <summary>
        /// 将datatable中的数据保存到数据库中
        /// </summary>
        /// <param name="connectionString">目标连接字符</param>
        /// <param name="TableName">目标表</param>
        /// <param name="dt">源数据</param>
        private void SqlBulkCopyByDatatable(string connectionString, string TableName, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = TableName;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        /// <summary> 
        /// 将DataTable中数据批量数据库表中
        /// <param name="dt">源数据集</param>  
        /// <param name="ExcelTitle">DataTable数据题头</param>  
        /// <param name="DBColumnName">要插入数据的表的对应字段</param>   
        /// <param name="DestinationTableName">写入数据的数据库表名</param>  
        /// </summary> 
        public static bool SqlBulkCopyData(System.Data.DataTable dt, string[] DataTableTitle, string[] DBColumnName, string DestinationTableName,string IPConfig)
        {
            SqlConnection conn = new SqlConnection(CardManagement.DBUtility.DbHelperSQL.connectionString);
            
            //初始化连接字符串  
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlBulkCopy bcp = new SqlBulkCopy(conn);
            try
            {
                //指定目标数据库表名
                bcp.DestinationTableName = DestinationTableName;
                //指定源列和目标列之间的对应关系
                for (int i = 0; i < DataTableTitle.Length-1; i++)
                {
                    bcp.ColumnMappings.Add(DataTableTitle[i], DBColumnName[i]);
                }
                //写入数据库表 
                bcp.WriteToServer(dt);
                bcp.Close();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                NH.Class.Log.WriteLog.Write("CardManagement.Form_Download", "SqlBulkCopyData", IPConfig+"卡机中的数据插入数据库失败",ex, NH.Class.Log.ErrorLogType.FatalLog);
            }
        }  






    }
}
