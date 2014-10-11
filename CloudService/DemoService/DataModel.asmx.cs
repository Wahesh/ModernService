using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
namespace DemoService
{
    /// <summary>
    /// Summary description for DataModel
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataModel : System.Web.Services.WebService
    {

        [WebMethod]
        public show GetNews()
        {

            show newsDetails = new show();

            ConnectAzure funcs;
            funcs = new ConnectAzure();
            funcs.PublicConnection();
            using (SqlConnection conn = funcs.getConnString())
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("Select top 1 * from NewsDetails order by NewsID desc", conn);
              //  cmd.Parameters.AddWithValue("@NewsID", newsID);
                DataSet DS = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                SDA.Fill(DS);

             //   newsDetails.newsID = Convert.ToInt32(DS.Tables[0].Rows[0]["NewsID"]);
                newsDetails.NewsHead = DS.Tables[0].Rows[0]["NewsHeadline"].ToString();
                newsDetails.NewsDetail = DS.Tables[0].Rows[0]["NewsDetails"].ToString();
                newsDetails.Picture = DS.Tables[0].Rows[0]["PhotoLink"].ToString();
                newsDetails.Source = DS.Tables[0].Rows[0]["facebookLink"].ToString();

                conn.Close();
            }

            return newsDetails;
        }

        public class show
        {

            public string NewsHead { get; set; }
            public string NewsDetail { get; set; }
            public string Picture { get; set; }
            public string Source { get; set; }
            public string date { get; set; }
            public string NewsDescription { get; set; }
            public string Adv2 { get; set; }


        } 

    }
}
