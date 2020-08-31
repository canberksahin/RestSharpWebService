using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class EArchiveReportLedger
    {
        public string ID { get; set; }
        public string EArchiveReportLedgerRequestID { get; set; }
        public int Division { get; set; }
        public string Version { get; set; }
        public string Identifier { get; set; }
        public string Composer { get; set; }
        public string ReportNumber { get; set; }
        public DateTime PeriodBeginDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public DateTime PartBeginDate { get; set; }
        public DateTime PartEndDate { get; set; }
        public int PartNumber { get; set; }
        public int Status { get; set; }
        public int SubStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsActive { get; set; }
        public string ReportZip { get; set; }
        public int PartCount { get; set; }
        public string Serials { get; set; }
    }

    public class Root
    {
        public List<EArchiveReportLedger> EArchiveReportLedgers { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfRecords { get; set; }
        public string Message { get; set; }
    }
}
