using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class test : System.Web.UI.Page
{
    SqlCon conn=new SqlCon();

    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                AddTree(0, null);
            }
        }


    private void AddTree(int Pid, TreeNode PNode)
    {
        DataSet ds=conn.DsSql("select code,name,pcode,group_code from department");
        DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataView dv = new DataView(dt);
                //过滤ParentID,得到当前的所有子节点 ParentID为父节点ID
                dv.RowFilter = "[pcode] = " + Pid;
                //循环递归
                foreach (DataRowView Row in dv)
                {
                    //声明节点
                    TreeNode Node = new TreeNode();
                    //绑定超级链接(点击部门跳转到员工页面，员工列表由部门编码group_code字段条件控制)
                    Node.NavigateUrl = String.Format("javascript:show('{0}')", Row["group_code"].ToString());
                    //开始递归
                    if (PNode == null)
                    {
                        //添加根节点
                        Node.Text = Row["name"].ToString();
                        TreeView1.Nodes.Add(Node);
                        Node.Expanded = true; //节点状态展开
                        AddTree(Int32.Parse(Row["code"].ToString()), Node);    //再次递归
                    }
                    else
                    {
                        //添加当前节点的子节点
                        Node.Text = Row["name"].ToString();
                        PNode.ChildNodes.Add(Node);
                        Node.Expanded = true; //节点状态展开
                        AddTree(Int32.Parse(Row["code"].ToString()), Node);     //再次递归
                    }
                }
            }
    }
}