using Cloudies.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cloudies.Web.Controllers.Labs
{
    public class NewLabsController : Controller
    {
        //
        // GET: /NewLabs/
        [HttpGet]
        public ActionResult NewLab()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewLab(ViewModelNewLab newLab)
        {
            Lab lab = new Lab();
            lab.Start_Time = newLab.Start_Time;
            lab.End_Time = newLab.End_Time;
            lab.Name = newLab.Name;
            lab.Time_Zone = "Asia/Calcutta";
            lab.User_ID = 1;

            LabConfiguration labConfig = new LabConfiguration();
            labConfig.OS = newLab.OS;
            labConfig.RAM = newLab.Ram;
            labConfig.VM_Count = newLab.VM_Count;
            labConfig.Hard_Disk = newLab.Hard_Disk;

            IjepaiEntities db = new IjepaiEntities();
            db.LabConfigurations.Add(labConfig);
            lab.Config_ID = labConfig.ID;
            db.Labs.Add(lab);
            db.SaveChanges();

            return View("~/Views/MyLabs/LabDetail.cshtml", newLab);
        }
	}
}