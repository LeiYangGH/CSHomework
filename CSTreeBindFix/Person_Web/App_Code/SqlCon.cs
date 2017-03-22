using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Wuqi.Webdiyer;


/// <summary>
/// SqlCon 的摘要说明
/// </summary>
public class SqlCon
{
	public SqlCon()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public string Str = "";

    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Constr"].ToString());

    #region 打开关关闭数据源
    public void open() {

        if (con.State == ConnectionState.Closed)
            con.Open();

    
    }

    public void close() {
        if (con.State == ConnectionState.Open)
            con.Close();

    }

   
    #endregion



    #region 处理数据
    public bool usecmd(string sql) {

        open();
        SqlCommand cmd = new SqlCommand(sql,con);

        if (cmd.ExecuteNonQuery() > 0)
        { return true; }
        else
        { return false; }
        cmd.Dispose();
        close();
    }


    public DataSet DsSql(string sql) {
        open();
        SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        adapter.Fill(ds,"Table");
        return ds;
        ds.Dispose();
        close();
    }

  

    public DataSet DsPager(string sql,AspNetPager pager) {

        open();
        SqlCommand cmd = new SqlCommand(sql,con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, pager.PageSize * (pager.CurrentPageIndex - 1), pager.PageSize, "Table");
        return ds;

        ds.Dispose();
        close();
    
    }

    public void DsLoad(string sql, AspNetPager pager,DataList datalist)
    {
        open();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        adapter.Fill(ds, "Table");
        adapter.Fill(ds1, pager.PageSize * (pager.CurrentPageIndex - 1), pager.PageSize, "Table");
        pager.RecordCount = ds.Tables[0].Rows.Count;
        datalist.DataSource = ds1.Tables[0].DefaultView;
        datalist.DataBind();
        adapter.Dispose();
        ds.Dispose();
        ds1.Dispose();
        close();
    }


    //新添加一个用于Repaerter控件绑定数据，并且实现分页
    public void DsLoad(string sql, AspNetPager pager, Repeater repeater)
    {
        open();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        adapter.Fill(ds, "Table");
        adapter.Fill(ds1, pager.PageSize * (pager.CurrentPageIndex - 1), pager.PageSize, "Table");
        pager.RecordCount = ds.Tables[0].Rows.Count;
        repeater.DataSource = ds1.Tables[0].DefaultView;
        repeater.DataBind();
        adapter.Dispose();
        ds.Dispose();
        ds1.Dispose();
        close();
    }

    //新添加一个用于Repaerter控件绑定数据，并且实现分页 还有以 SqlParameter数组 为参数的方法
    public void DsLoad(string sql, AspNetPager pager, Repeater repeater, SqlParameter[] par)
    {
        open();
        SqlCommand comd = new SqlCommand(sql, con);
        for (int i = 0; i < par.Length; i++)
        {
            comd.Parameters.Add(par[i]);
        }
        SqlDataAdapter adapter = new SqlDataAdapter(comd);
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        adapter.Fill(ds, "Table");
        adapter.Fill(ds1, pager.PageSize * (pager.CurrentPageIndex - 1), pager.PageSize, "Table");
        pager.RecordCount = ds.Tables[0].Rows.Count;
        repeater.DataSource = ds1.Tables[0].DefaultView;
        repeater.DataBind();
        adapter.Dispose();
        ds.Dispose();
        ds1.Dispose();
        close();
    }

    public void BindRep(string sql,Repeater repeater) {
        open();
        SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
        DataSet ds = new DataSet();
        adapter.Fill(ds,"Table");
        repeater.DataSource = ds.Tables[0].DefaultView;
        repeater.DataBind();
        ds.Dispose();
        close();
    }

    public void DsRep(string sql, AspNetPager pager)
    {
        open();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
     
        adapter.Fill(ds, "Table");
      
        pager.RecordCount = ds.Tables[0].Rows.Count;
       
      
        ds.Dispose();
      
        close();



    }
    #endregion

    #region 判断admin登陆是否成功

    public bool checkusename(string username,string pwd) {
        open();
        SqlCommand cmd = new SqlCommand("select * from [Users] where [User_Name]='" + username + "' and password='" + pwd + "'", con);
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            if (dr.Read())
            {
                return true;

               
            }
            else
            {
                return false;

               
            }

            
            
        }
        cmd.Dispose();
        close();
    
    
    }



    public bool checkAdmin(string admin, string pass, int dp,string cid)
    {
        open();
        SqlCommand cmd = new SqlCommand("sp_checkadmin",con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@admin",SqlDbType.VarChar,50));
        cmd.Parameters.Add(new SqlParameter("@pass",SqlDbType.VarChar,50));
        cmd.Parameters.Add(new SqlParameter("@dp",SqlDbType.Int,4));
        cmd.Parameters.Add(new SqlParameter("@cid", SqlDbType.VarChar, 30));
        cmd.Parameters["@admin"].Value = admin;
        cmd.Parameters["@pass"].Value = pass;
        cmd.Parameters["@dp"].Value = dp;
        cmd.Parameters["@cid"].Value = cid;
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            if (dr.Read())
            {
                return true;

              
            }
            else
            {

                return false;

               
            }

           
           
        }
        cmd.Dispose();
        close();
       

    }

    #endregion

    #region 处理新闻表

    public bool addnews(string title,string author,string atime,string content,string from,int c_id,int dp){

        open();
        SqlCommand cmd = new SqlCommand("sp_addnews",con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@title",SqlDbType.VarChar,100));
        cmd.Parameters.Add(new SqlParameter("@content", SqlDbType.NText,16));
        cmd.Parameters.Add(new SqlParameter("@author", SqlDbType.VarChar, 50));
        cmd.Parameters.Add(new SqlParameter("@atime", SqlDbType.VarChar, 50));
        cmd.Parameters.Add(new SqlParameter("@from", SqlDbType.VarChar, 50));
        cmd.Parameters.Add(new SqlParameter("@dp", SqlDbType.Int, 4));
        cmd.Parameters.Add(new SqlParameter("@c_id", SqlDbType.Int, 4));
        cmd.Parameters["@title"].Value = title;
        cmd.Parameters["@content"].Value = content;
        cmd.Parameters["@author"].Value = author;
        cmd.Parameters["@atime"].Value = atime;
        cmd.Parameters["@from"].Value = from;
        cmd.Parameters["@c_id"].Value = c_id;
        cmd.Parameters["@dp"].Value = dp;
        
        if (cmd.ExecuteNonQuery() == 1)
        {
            return true;

        }
        else
        {

            return false;
        }
        cmd.Dispose();
        close();
       
    }

  
    public bool editnews(string title, string author, string atime, string content, string from, int news_id)
    {

        open();
        SqlCommand cmd = new SqlCommand("sp_UpdateNews", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 100));
        cmd.Parameters.Add(new SqlParameter("@content", SqlDbType.NText, 16));
        cmd.Parameters.Add(new SqlParameter("@author", SqlDbType.VarChar, 50));
        cmd.Parameters.Add(new SqlParameter("@atime", SqlDbType.VarChar, 50));
        cmd.Parameters.Add(new SqlParameter("@from", SqlDbType.VarChar, 50));
     
        cmd.Parameters.Add(new SqlParameter("@news_id", SqlDbType.Int, 4));
        cmd.Parameters["@title"].Value = title;
        cmd.Parameters["@content"].Value = content;
        cmd.Parameters["@author"].Value = author;
        cmd.Parameters["@atime"].Value = atime;
        cmd.Parameters["@from"].Value = from;
        cmd.Parameters["@news_id"].Value = news_id;
       

        if (cmd.ExecuteNonQuery() == 1)
        {
            return true;

        }
        else
        {

            return false;
        }
        cmd.Dispose();
        close();
       
    }


    public bool delnews(string news_id) {

        open();
        SqlCommand cmd = new SqlCommand("sp_delnews",con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@news_id",SqlDbType.Int,4));
        cmd.Parameters["@news_id"].Value = news_id;
        if (cmd.ExecuteNonQuery() == 1)
            return true;
        else
            return false;

        cmd.Dispose();
        close();
        
        
    }


  
#endregion


    /// <summary>
    /// 添加的一个用于Repeater控件绑定数据的方法
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <param name="repeater"></param>
    public void BindRepeater(string sqlstr, System.Web.UI.WebControls.Repeater repeater)
    {
        open();
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Table");
        close();
        repeater.DataSource = ds.Tables["Table"].DefaultView;
        repeater.DataBind();
        da.Dispose();
        ds.Dispose();
        close();
    }


    /// <summary>
    /// 这是新添加的以 SqlParameter数组 为参数的方法
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="par"></param>
    /// <returns></returns>
    public DataSet DsSql(string sql, SqlParameter[] par)
    {
        open();
        SqlCommand comd = new SqlCommand(sql, con);
        for (int i = 0; i < par.Length; i++)
        {
            comd.Parameters.Add(par[i]);
        }
        SqlDataAdapter adapter = new SqlDataAdapter(comd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "Table");
        comd.Dispose();
        close();
        return ds;
    }

    public bool backupdata(string sql) {
        open();
       
         SqlCommand cmd = new SqlCommand(sql, con); 
        int a = cmd.ExecuteNonQuery();
        if (a == -1)
        {
            return true;
        }
        else
        {
            return false;
        }
        cmd.Dispose();
        close();
    }

    public bool delbclass(int bid) {

        open();
        SqlCommand cmd = new SqlCommand("sp_DelBclass",con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@bid",SqlDbType.Int, 4));
        cmd.Parameters["@bid"].Value = bid;
        if (cmd.ExecuteNonQuery()>0)
            return true;
        else
            return false;
        cmd.Dispose();
        close();
    
    }

    public bool delsclass(int bid)
    {
        open();
        SqlCommand cmd = new SqlCommand("sp_delsclass", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@bid", SqlDbType.Int, 4));
        cmd.Parameters["@bid"].Value = bid;
        if (cmd.ExecuteNonQuery() > 0)
            return true;
        else
            return false;
        cmd.Dispose();

        close();
    }

    public bool deltsgbclass(int bid)
    {
        open();
        SqlCommand cmd = new SqlCommand("sp_tsg_bigclass", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@bid", SqlDbType.Int, 4));
        cmd.Parameters["@bid"].Value = bid;
        if (cmd.ExecuteNonQuery() > 0)
            return true;
        else
            return false;
        cmd.Dispose();

        close();
    }

    public bool deltsgsclass(int bid)
    {
        open();
        SqlCommand cmd = new SqlCommand("sp_tsg_sclass", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@sid", SqlDbType.Int, 4));
        cmd.Parameters["@sid"].Value = bid;
        if (cmd.ExecuteNonQuery() > 0)
            return true;
        else
            return false;
        cmd.Dispose();

        close();
    }

    public bool deldzclass(int bid)
    {
        open();
        SqlCommand cmd = new SqlCommand("sp_dz_deltitle", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@sid", SqlDbType.Int, 4));
        cmd.Parameters["@sid"].Value = bid;
        if (cmd.ExecuteNonQuery() > 0)
            return true;
        else
            return false;
        cmd.Dispose();

        close();

    }

}