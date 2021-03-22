using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace _59591071105_VoThiDieuThuong_Buoi5
{
    public partial class WebForm : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
          
                var request = WebRequest.Create("https://graph.facebook.com/UTC2HCMC?access_token=EAAAAZAw4FxQIBAI7QoZAoaw62idXtfipZBdxunjidcb5QEjc43jqz9AmIAKVsz06T9ymclpLyMwr6G89DEGlFRuGaFmQ12yplFamfV6HYnN8SmCzfurZB4K4YZAREQgwks4wFXshy0gFJgZBB7PnjqAT0Sp1BSL8rRC4zvIIZAapAZDZD");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dStream = response.GetResponseStream();
                StreamReader str = new StreamReader(dStream);
                string responseString =str.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);
            var results = new List<Post>();
            foreach (var item in jsonData.data)
            {
                
                    results.Add(new Post
                    {
                        Time = item.created_time,
                        Content = item.message,
                        Link = item.actions[0].link,
                    });
                }
                string t= "";
                for (int i = 0; i < 3; i++)
                {
                    t += "<b>Bài thứ " + (i + 1) + ": </b>" + "</br>";
                    t += "<b>Ngày đăng: </b>" + results[i].Time + "</br>";
                    t += "<b>Nội dung: </b>" + results[i].Content + "</br>";
                    t += "<b> Link bài viết: </b>" + results[i].Link + "</br>";
                }
            lbRest.Text = t;
            }
    
}
    }
