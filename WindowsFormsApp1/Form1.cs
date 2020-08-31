using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // https://stackoverflow.com/questions/32716174/call-and-consume-web-api-in-winform-using-c-net
        string username = "apiuser.5570477043";
        string password = "b47b64bbe4877129afb380bee75a0ff5";
        string yaziPassword = '"' + "password" + '"';


        public Form1()
        {
            InitializeComponent();

            var ilListesi = new BindingList<KeyValuePair<string, string>>();

            ilListesi.Add(new KeyValuePair<string, string>("314", "Kırşehir"));
            ilListesi.Add(new KeyValuePair<string, string>("294", "Kırıkkale"));

            cmbIl.DataSource = ilListesi;
            cmbIl.ValueMember = "Key";
            cmbIl.DisplayMember = "Value";



        }

        private void btnAl_Click_1(object sender, EventArgs e)
        {

            string division = cmbIl.SelectedValue.ToString();
            var restClient = new RestClient("https://portal.faturaturka.com/im/v2/api/Integration");
            RestRequest req = new RestRequest("token", Method.POST);
            var tokenBody = new TokenBody();//values to pass in request

            tokenBody.grant_type = "password";
            tokenBody.password = password;
            tokenBody.username = username;

            req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            req.AddHeader("division", division);
            // Content type is not required when adding parameters this way
            // This will also automatically UrlEncode the values
            req.AddParameter("grant_type", tokenBody.grant_type, ParameterType.GetOrPost);
            req.AddParameter("username", tokenBody.username, ParameterType.GetOrPost);
            req.AddParameter("password", tokenBody.password, ParameterType.GetOrPost);

            var res = restClient.Execute(req);
            var response = JsonConvert.DeserializeObject<TokenResponse>(res.Content);
            string token = response.access_token;

            if (token == null)
            {
                var error = JsonConvert.DeserializeObject<Error>(res.Content);
                string errorDescription = error.error_description;
                string errorName = error.error;
                MessageBox.Show("Token Alınamadı !! "+errorName + "-"+ errorDescription);
            }

            var restClient1 = new RestClient("https://portal.faturaturka.com/im/v2/api/Integration");
            RestRequest req1 = new RestRequest("GetEArchiveReportLedgerListSummary", Method.POST);
            restClient1.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));
            var body = new Body();//values to pass in request

            body.Year  = nudYil.Value.ToString();
            body.Month = nudAy.Value.ToString() ;

            req1.AddParameter("Year", body.Year, ParameterType.GetOrPost);
            req1.AddParameter("Month", body.Month, ParameterType.GetOrPost);

            var res1 = restClient1.Execute(req1);
            var response1 = JsonConvert.DeserializeObject<Response>(res1.Content);
        }
    }
}