using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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

        //Database bağlantısı için
        string passwordDB = "KIRGAZ_TST";
        string userIdDB = "KIRGAZ_TST";
        string dataSourceDB = "192.168.101.234:1521/orcl.kirsehir.local";


        // https://stackoverflow.com/questions/32716174/call-and-consume-web-api-in-winform-using-c-net
        string username = "apiuser.5570477043";
        string password = "b47b64bbe4877129afb380bee75a0ff5";
        string yaziPassword = '"' + "password" + '"';
        List<string> ilceListesi = new List<string>();
        List<EArchiveReportLedger> eArchiveReportLedgerListesi = new List<EArchiveReportLedger>();


        public Form1()
        {
            InitializeComponent();


            OracleConnection con = new OracleConnection();

            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

            ocsb.Password = passwordDB;
            ocsb.UserID = userIdDB;
            ocsb.DataSource = dataSourceDB;
            con.ConnectionString = ocsb.ConnectionString;
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Database bağlantısı kurulamadı.");
            }



            BindingList<KeyValuePair<string, string>> ilListesi = new BindingList<KeyValuePair<string, string>>();
            // ilListesi.Add(new KeyValuePair<string, string>("294", "Kırıkkale"));
            ilListesi.Add(new KeyValuePair<string, string>("314", "Kırşehir"));

            cmbIl.DataSource = ilListesi;
            cmbIl.ValueMember = "Key";
            cmbIl.DisplayMember = "Value";

            #region İlçeler

            OracleCommand command = con.CreateCommand();
            string sql = "select t.aciklama from yetki_parametre t where t.tablo_adi='MUH_FIS_KATEGORI' order by t.siralama";
            command.CommandText = sql;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ilceListesi.Add(reader[0].ToString());
            }

            cmbIlceListesi.DataSource = ilceListesi;
            #endregion

        }

        private void btnAl_Click_1(object sender, EventArgs e)
        {

            #region TOKEN ALMA
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
                MessageBox.Show("Token Alınamadı !! " + errorName + "-" + errorDescription);
            }
            #endregion

            var restClient1 = new RestClient("https://portal.faturaturka.com/im/v2/api/Integration");
            RestRequest req1 = new RestRequest("GetEArchiveReportLedgerListSummary", Method.POST);
            restClient1.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            var body = new Body();
            body.Year = nudYil.Value.ToString();
            if (nudAy.Value < 10)
            {
                body.Month = "0" + nudAy.Value.ToString();
            }
            else
            {
                body.Month = nudAy.Value.ToString();
            }

            req1.AddParameter("Year", body.Year, ParameterType.GetOrPost);
            req1.AddParameter("Month", body.Month, ParameterType.GetOrPost);
            req1.RequestFormat = DataFormat.Json;


            var res1 = restClient1.Execute(req1);
            var content = restClient1.Execute(req1).Content;

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(content);
            var count = myDeserializedClass.EArchiveReportLedgers.Count;
            for (int i = 0; i < count; i++)
            {
                eArchiveReportLedgerListesi.Add(myDeserializedClass.EArchiveReportLedgers[i]);
            }
            TarihEIcmalNolar liste = new TarihEIcmalNolar();

            DataTable table = new DataTable();
            table.Columns.Add("SERİ NO", typeof(string));

            List<string> seriListesi = new List<string>();
            List<string> iller = new List<string>();
            iller.Add("Kırşehir");
            iller.Add("Kırıkkale");
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                var serial = myDeserializedClass.EArchiveReportLedgers[i].Serials;

                if (!seriListesi.Contains(serial))
                {

                    seriListesi.Add(serial);
                    table.Rows.Add(serial);

                    //ComboBox combo = new ComboBox();
                    //combo.DataSource = ilceListesi;
                    //combo.Width = 200;
                    //combo.Name = "cmb" + j.ToString();
                    //string name = "cmb" + j.ToString();
                    //combo.SelectedValueChanged += Combo_SelectedValueChanged;
                    //combo.Location = new Point(550 , 61 + 20* j);
                    //this.Controls.Add(combo);
                    //j++;
                }

            }
            dgvListe.DataSource = table;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string serials = dgvListe.SelectedRows[0].Cells[0].Value.ToString();
            var ilce = cmbIlceListesi.SelectedValue;
            List<EArchiveReportLedger> listeSerial = new List<EArchiveReportLedger>();
            int kategoriId = cmbIlceListesi.SelectedIndex + 1;

            OracleConnection con = new OracleConnection();

            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

            ocsb.Password = passwordDB;
            ocsb.UserID = userIdDB;
            ocsb.DataSource = dataSourceDB;

            con.ConnectionString = ocsb.ConnectionString;
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Database bağlantısı kurulamadı.");
            }
            // Serial numarası aynı olanları listeye alınır
            foreach (var item in eArchiveReportLedgerListesi)
            {
                if (item.Serials == serials)
                {
                    listeSerial.Add(item);
                }
            }
            // Belge Türü X, belge açıklaması EARVFATICM, kategori idsi seçilen kategori olan fişler fiş tarihine göre seçilir
            #region FİŞLERİ SEÇ
            int sayac = 1;
            foreach (var item in listeSerial)
            {
                string fisIdStr = "";
                int sira = 0;
                string eIcmalNo = item.ReportNumber;
                string tarih = item.PartBeginDate.ToShortDateString();
                OracleDataAdapter da = new OracleDataAdapter();

                OracleCommand command = con.CreateCommand();
                string sql = "select t.fis_id from muh_gm_fis t where t.belge_turu = 'X' and t.belge_aciklama = 'EARVFATICM' and t.kategori_id = '" + kategoriId + "' and t.fis_tarihi = '" + tarih + "'";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (sira == 0)
                    {
                        fisIdStr += reader[0].ToString();
                        sira++;
                    }
                    else
                    {
                        fisIdStr += "," + reader[0].ToString();
                    }
                }
                //Seçilen Fiş idlerin detaylarına gidilip belge noları kısmına e-arşiv numaraları yazılır
                #region FİŞ DETAY
                if (fisIdStr != "")
                {
                    OracleCommand cmd1 = new OracleCommand("update muh_gm_fis_detay t set t.belge_no = '" + eIcmalNo + "' where t.fis_id in (" + fisIdStr + ") ", con);
                    int rowsUpdated = cmd1.ExecuteNonQuery();
                    da.UpdateCommand = cmd1;
                    if (rowsUpdated > 0 && sayac == 1)
                    {
                        MessageBox.Show("İşlem Tamamlandı");
                        sayac++;
                    }
                }
                #endregion

            }
            #endregion



            foreach (DataGridViewRow row in dgvListe.Rows)
                if (row == dgvListe.SelectedRows[0])
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
        }


        //private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string name =((ComboBox)sender).Name;
        //    int index = ((ComboBox)sender).SelectedIndex;
        //    ((ComboBox)this.Controls.Find(name, true)[0]).SelectedIndex = index;

        //}

        //private void dgvListe_SelectionChanged(object sender, EventArgs e)
        //{
        //    DataTable table = new DataTable();
        //    table.Columns.Add("FİŞ ID", typeof(string));
        //    table.Columns.Add("YEVMİYE NO", typeof(string));
        //    table.Columns.Add("FİŞ TARİHİ", typeof(string));
        //    table.Columns.Add("AÇIKLAMA", typeof(string));
        //    var tarih = dgvListe.SelectedRows[0].Cells[0].Value;

        //    OracleConnection con = new OracleConnection();

        //    OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
        //    ocsb.Password = "TEST_KIRGAZ";
        //    ocsb.UserID = "TEST_KIRGAZ";
        //    ocsb.DataSource = "192.168.102.140:1521/docuart";
        //    con.ConnectionString = ocsb.ConnectionString;
        //    con.Open();


        //    OracleCommand command = con.CreateCommand();
        //    string sql = "SELECT t.fis_id, t.yevmiye_no, t.fis_tarihi, t.aciklama FROM muh_gm_fis t where t.fis_tarihi = '" +tarih +"'";
        //    command.CommandText = sql;

        //    OracleDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        table.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
        //    }
        //    //dgvFisler.DataSource = table;
        //}
    }

}