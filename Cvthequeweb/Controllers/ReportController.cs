using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Cvthequeweb.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(int id)
        {
            DataTable dt = new DataTable();
            Reports.MyDataSet ds = new Reports.MyDataSet();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);
            var connectionString = ConfigurationManager.ConnectionStrings["CVThequeConnectionString"].ConnectionString;
            SqlConnection conx = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetCandi", conx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Report1.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("MyDataSet", dt));
            ViewBag.ReportViewer = reportViewer;

            return View();
        }

        private DataTable GetData(int id)
        {
            DataTable dt = new DataTable();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["CVThequeConnectionString"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("GetCandi", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            return dt;
        }

        private void ShowReport(int id)
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);
            reportViewer.Reset();
            DataTable dt = GetData(id);
            ReportDataSource rds = new ReportDataSource("MyDataSet", dt);
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.LocalReport.ReportPath = "Reports/Report1.rdlc";
            ReportParameter[] rptParams = new ReportParameter[] {
                new ReportParameter("id",id.ToString())
            };
            reportViewer.LocalReport.SetParameters(rptParams);
            reportViewer.LocalReport.Refresh();
            ViewBag.ReportViewer = reportViewer;
        }
    }
}