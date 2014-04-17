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
            var labs = _db.Labs.Select(lab => new { lab.ID, lab.Name, lab.Time_Zone, lab.Start_Time, lab.End_Time, lab.Status, lab.LabConfiguration.VM_Count, lab.LabConfiguration.Hard_Disk, lab.LabConfiguration.OS, lab.LabConfiguration.VM_Type});
            return JsonConvert.SerializeObject(new { records = labs.Count(), rows = labs}, new IsoDateTimeConverter());
        }

        public JsonResult getParticipants(int id)
        {
            var participants = _db.LabParticipants.Where(p => p.Lab_Id == id).Select(p => new { p.Email_Address, p.First_Name, p.Last_Name, p.Role });
            return Json(new {records = participants.Count(), rows = participants}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getLabData()
        {
            return Json(new { foo = "bar", baz = "buzz" }, JsonRequestBehavior.AllowGet);
        }
	}
}