using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
//using viviapi.Model.User;
//using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;

namespace shi
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String key = "";
            String Type = "";
            String Data = "";
            String Content = "";
            NameValueCollection nvc = Request.Form;
            Response.Write("Page_Load");

            if (!string.IsNullOrEmpty(nvc["Key"]))
            {
                key = nvc["Key"];
            }

            if (!string.IsNullOrEmpty(nvc["Type"]))
            {
                Type = nvc["Type"];
            }
            if (!string.IsNullOrEmpty(nvc["Content"]))
            {
                Content = nvc["Content"];
            }

            if (!string.IsNullOrEmpty(nvc["Data"]))
            {
                Data = nvc["Data"];
            }

            string all = $"{key} {Type} {Content} {Data}";
            Response.Write(all);
            Response.Write("end");
            //Response.End();




            //string jsonstr = context.Request["jsonstr"];
            //JArray javascript = (JArray)JsonConvert.DeserializeObject(jsonstr);


            //string ImageFile = System.IO.Path.GetDirectoryName(CurrentExeName)；
            //String ji = PostInput(HttpContext.Current);

            //byte[] byts = new byte[Request.InputStream.Length];
            //Request.InputStream.Read(byts, 0, byts.Length);
            //string req = System.Text.Encoding.Default.GetString(byts);
            //req = Server.UrlDecode(req);


            //Stream reqStream = Request.InputStream;
            //byte[] buffer = new byte[(int)reqStream.Length];
            //int req = reqStream.Read(buffer, 0, (int)reqStream.Length);




            ////System.IO.StreamReader sdr = new System.IO.StreamReader(Request.InputStream);
            //String req = sdr.ReadToEnd();

            //JArray jsonObj = JArray.Parse(req);

            // body = jsonObj["body"].ToString();


            //if(body == "")
            //{
            //    Response.Write("到这里");
            //    Response.End();
            //}

            //String key = "$@#%*Bd430124";
            //HttpRequest request = Context.Request;

            //Stream postData = Request.InputStream;

            //String json = string.Empty;

            //////if (postData.Length != 0)
            //////{

            //StreamReader sr = new StreamReader(postData);

            //json = sr.ReadToEnd();

            ////if (json == "")
            ////{

            ////    JObject jo = JObject.Parse(json);



            //body = file_get_contents(json);




            //sr.Close();
            ////Context.Response.Write(json);
            ////request.SaveAs("d:\\bc.txt" , true);

            //JArray jsonObj = JArray.Parse(json);

            // body = jsonObj["body"].ToString();
            //Type = jsonObj["Type"].ToString();
            //Data = jsonObj["Data"].ToString();

            ////JObject jo = JObject.Parse(json);

            ////key = (String)jo["key"];

            //}


            //    private string PostInput(HttpContext context)  
            //    {  
            //        try  
            //        {  
            //            System.IO.Stream s = context.Request.InputStream;  
            //            int count = 0;  
            //            byte[] buffer = new byte[1024];  
            //            StringBuilder builder = new StringBuilder();  
            //            while ((count = s.Read(buffer, 0, 1024)) > 0)  
            //            {  
            //                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));  
            //            }  
            //            s.Flush();  
            //            s.Close();  
            //            s.Dispose();  
            //            return builder.ToString();  
            //        }  
            //        catch (Exception ex)  
            //        { throw ex; }  

            //}



            //public void ProcessRequest(HttpContext context)
            //{
            //    HttpRequest request = context.Request;
            //    Stream stream = request.InputStream;
            //    string json = string.Empty;
            //    string responseJson = string.Empty;
            //    if (stream.Length != 0)
            //    {
            //        StreamReader streamReader = new StreamReader(stream);
            //        json = streamReader.ReadToEnd();
            //        Person person = JSONHelper.Deserialize<Person>(json);
            //        person.FirstName = "FN";
            //        person.LastName = "LN";
            //        responseJson = JSONHelper.Serialize<Person>(person);
            //    }
            //    if (!string.IsNullOrEmpty(responseJson))
            //    {
            //        context.Response.ContentType = "text/plain";
            //        context.Response.ContentType = "UTF-8";
            //        context.Response.Write(responseJson);
            //    }
            //}     





            //string dd = GetJsonStringFromRequest();

            //if(json != "")
            //{
            //// 将用户ID传入拿到这个用户的一个实例
            //UserInfo mode8 = viviapi.BLL.User.Factory.GetBaseModel(1024);
            ////将这个用户的网站名称修改来触发验证
            //mode8.SiteUrl= json;
            ////将实例进行更新数据
            //viviapi.BLL.User.Factory.Update(mode8, null);
            //}

            // }


             




        }
    }
}
