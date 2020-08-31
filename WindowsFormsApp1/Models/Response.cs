using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
   public class Response
    {
        public string ID { get; set; }

        public string EArchiveReportLedgerRequestID { get; set; }

        public string Division { get; set; }

        public string Version { get; set; }

        public string Identifier { get; set; }

        public string Composer { get; set; }

        public string ReportNumber { get; set; }

        public string PeriodBeginDate { get; set; }

        public string PeriodEndDate { get; set; }

        public string PartBeginDate { get; set; }

        public string PartEndDate { get; set; }

        public string PartNumber { get; set; }

        public string Status { get; set; }

        public string SubStatus { get; set; }

        public string CreateDate { get; set; }

        public string UpdateDate { get; set; }

        public string CreateUser { get; set; }

        public string UpdateUser { get; set; }

        public bool IsActive { get; set; }

        public string ReportZip { get; set; }

        public string PartCount { get; set; }

        public string Serials { get; set; }
    }
}
