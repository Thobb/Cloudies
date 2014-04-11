using Cloudies.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cloudies.Web.Controllers.Labs
{
    public class MyLabsController : Controller
    {

        private IjepaiEntities _db = new IjepaiEntities();

        //
        // GET: /MyLabs/
        public ActionResult Index()
        {
            return View();
        }

        public string getLabs(Object Sender, EventArgs e)
        {
            var labs = _db.Labs.Select(lab => new { lab.Name, lab.Time_Zone, lab.Start_Time, lab.End_Time});
            return JsonConvert.SerializeObject(new { records = labs.Count(), rows = labs}, new IsoDateTimeConverter());
        }

        public JsonResult getLabData()
        {
            return Json(new { foo = "bar", baz = "buzz" }, JsonRequestBehavior.AllowGet);
        }
	}
}