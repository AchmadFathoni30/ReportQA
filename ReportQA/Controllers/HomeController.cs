using ReportQA.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportQA.Utils;
using ReportQA.Models.DTEKA;

namespace ReportQA.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Report Bulanan";
            return View();
        }

        public ActionResult FormReportPool()
        {
            string strdtfrom = Request.QueryString["tglFrom"];
            string strdtto = Request.QueryString["tglTo"];
            string strstatus = Request.QueryString["status"];
            Boolean? status = !String.IsNullOrEmpty(strstatus) ? strstatus.Equals("1") : (Boolean?)null;

            var dtfrom = Utils.Utils.ConvertDateFromString(strdtfrom);
            var dtto = Utils.Utils.ConvertDateFromString(strdtto);

            string rptTitle = "Report_Pool_Rusak_" + strdtfrom + "_" + strdtto;

            var data = PoolRusakRepository.GetReportPoolRusak(dtfrom, dtto, status);

            ViewBag.Title = rptTitle;
            ViewBag.dtPoolRusak = data;
            ViewBag.dtfrom = dtfrom.HasValue ? dtfrom.Value.ToString("yyyy-MM-dd") : DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            ViewBag.dtto = dtto.HasValue ? dtto.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult UpdatePoolRusak()
        {
            string strdtfrom = HttpContext.Request.QueryString["tglFrom"];
            string strdtto = HttpContext.Request.QueryString["tglTo"];
            string strstatus = Request.QueryString["status"];
            Boolean? status = !String.IsNullOrEmpty(strstatus) ? strstatus.Equals("1") : (Boolean?) null;

            var dtfrom = Utils.Utils.ConvertDateFromString(strdtfrom);
            var dtto = Utils.Utils.ConvertDateFromString(strdtto);

            var data = PoolRusakRepository.GetReportPoolRusak(dtfrom, dtto, status);

            ViewBag.dtPoolRusak = data;
            ViewBag.dtfrom = dtfrom.HasValue ? dtfrom.Value.ToString("yyyy-MM-dd") : DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            ViewBag.dtto = dtto.HasValue ? dtto.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public ActionResult UpdateData(List<String> validates)
        {
            int result = 0;

            if (validates != null && validates.Count > 0)
            {
                foreach (string item in validates)
                {
                    var arrsplit = item.Split('_');
                    if (arrsplit.Length == 1)
                    {
                        string norusak = arrsplit[0];

                        int update = PoolRusakRepository.ValidatePoolRusak(norusak);
                        result += (update * -1);
                    }
                }
            }

            if (result != validates.Count)
            {
                throw new Exception("Sebagian data gagal di-update. Silakan coba kembali.");
            }

            return Redirect(Url.Action("UpdatePoolRusak", "Home"));
        }

        public ActionResult FormReportPoolUpdate()
        {
            string strdtfrom = Request.QueryString["tglFrom"];
            string strdtto = Request.QueryString["tglTo"];
            string strstatus = Request.QueryString["status"];
            Boolean? status = !String.IsNullOrEmpty(strstatus) ? strstatus.Equals("1") : (Boolean?)null;

            var dtfrom = Utils.Utils.ConvertDateFromString(strdtfrom);
            var dtto = Utils.Utils.ConvertDateFromString(strdtto);

            string rptTitle = "Report_Pool_Rusak_" + strdtfrom + "_" + strdtto;

            var data = PoolRusakRepository.GetReportPoolRusakUpdate(dtfrom, dtto, status);

            ViewBag.Title = rptTitle;
            ViewBag.dtPoolRusakV = data;
            ViewBag.dtfrom = dtfrom.HasValue ? dtfrom.Value.ToString("yyyy-MM-dd") : DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            ViewBag.dtto = dtto.HasValue ? dtto.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }
    }
}
