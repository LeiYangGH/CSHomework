using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// JsCommon 的摘要说明
/// </summary>
public class JsCommon
{
	public JsCommon()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 弹出消息框
    /// </summary>
    /// <param name="msg"></param>
    public  void ShowMsg(string msg)
    {
        string js = @"<Script language='JavaScript'>
                    alert('" + msg + "');</Script>";
        HttpContext.Current.Response.Write(js);
    }

    /// <summary>
    /// 弹出消息框并且转向到新的URL
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="toURL"></param>
    public  void ShowMsg(string msg, string toURL)
    {
        string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
        HttpContext.Current.Response.Write(string.Format(js, msg, toURL));
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// 回到历史页面
    /// </summary>
    /// <param name="value">-1/1</param>
    public void GoHistory(int value)
    {
        string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
        HttpContext.Current.Response.Write(string.Format(js, value));
    }

    /// <summary>
    /// 关闭当前窗口
    /// </summary>
    public  void CloseWindow()
    {
        string js = @"<Script language='JavaScript'>
                    parent.opener=null;window.close();  
                  </Script>";
        HttpContext.Current.Response.Write(js);
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// 刷新父窗口
    /// </summary>
    /// <param name="url"></param>
    public  void RefreshParent(string url)
    {
        string js = @"<Script language='JavaScript'>
                    window.opener.location.href='" + url + "';window.close();</Script>";
        HttpContext.Current.Response.Write(js);
    }


    /// <summary>
    /// 刷新打开窗口
    /// </summary>
    public  void RefreshOpener()
    {
        string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
        HttpContext.Current.Response.Write(js);
    }


    /// <summary>
    /// 打开指定大小的新窗体
    /// </summary>
    /// <param name="url"></param>
    /// <param name="width"></param>
    /// <param name="heigth"></param>
    /// <param name="top"></param>
    /// <param name="left"></param>
    public  void OpenWindow(string url, int width, int heigth, int top, int left)
    {
        string js = @"<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

        HttpContext.Current.Response.Write(js);
    }


    /// <summary>
    /// 转向指定的Url
    /// </summary>
    /// <param name="url"></param>
    public  void LocationNewHref(string url)
    {
        string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
        js = string.Format(js, url);
        HttpContext.Current.Response.Write(js);
    }

    /// <summary>
    /// 打开指定大小位置的模式对话框
    /// </summary>
    /// <param name="url"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="top"></param>
    /// <param name="left"></param>
    public  void ShowModalDialog(string url, int width, int height, int top, int left)
    {
        string features = "dialogWidth:" + width.ToString() + "px"
            + ";dialogHeight:" + height.ToString() + "px"
            + ";dialogLeft:" + left.ToString() + "px"
            + ";dialogTop:" + top.ToString() + "px"
            + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
        string js = @"<script language=javascript>							
							showModalDialog('" + url + "','','" + features + "');</script>";
        HttpContext.Current.Response.Write(js);
    }

    /// <summary>
    /// 停留指定时间后，跳转到指定页
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="goUrl"></param>
    /// <param name="second"></param>
    public  void TipAndRedirect(string msg, string goUrl, string second)
    {
        HttpContext.Current.Response.Write("<meta http-equiv='refresh' content='" + second + ";url=" + goUrl + "'>");
        HttpContext.Current.Response.Write("<br/><br/><p align=center><div style=\"size:12px\">&nbsp;&nbsp;&nbsp;&nbsp;" + msg.Replace("!", "") + ",页面2秒内跳转!<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + goUrl + "\">如果没有跳转，请点击!</a></div></p>");
        HttpContext.Current.Response.End();
    }
}
