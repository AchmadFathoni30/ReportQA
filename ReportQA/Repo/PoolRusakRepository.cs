using ReportQA.Models.DTEKA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportQA.Repo
{
    public class PoolRusakRepository
    {
        public static List<PoolRusak_Result> GetReportPoolRusak(DateTime? dtfrom, DateTime? dtto, Boolean? status)
        {
            dtfrom = dtfrom.HasValue ? dtfrom.Value : DateTime.Now.AddDays(-1);
            dtto = dtto.HasValue ? dtto.Value : DateTime.Now.AddDays(-1);

            using (DTEKAEntities db = new DTEKAEntities())
            {
                var dtpoolrusak = db.PoolRusak(dtfrom.Value, dtto.Value, status);
                return dtpoolrusak.ToList();
            }
        }

        public static int ValidatePoolRusak(string norusak)
        {
            using (DTEKAEntities db = new DTEKAEntities())
            {
                return db.PoolRusakInsertValidate(norusak);
            }
        }

        public static List<PoolRusakV_Result> GetReportPoolRusakUpdate(DateTime? dtfrom, DateTime? dtto, Boolean? status)
        {
            dtfrom = dtfrom.HasValue ? dtfrom.Value : DateTime.Now.AddDays(-1);
            dtto = dtto.HasValue ? dtto.Value : DateTime.Now.AddDays(-1);

            using (DTEKAEntities db = new DTEKAEntities())
            {
                var dtpoolrusakV = db.PoolRusakV(dtfrom.Value, dtto.Value, status);
                return dtpoolrusakV.ToList();
            }
        }
    }
}