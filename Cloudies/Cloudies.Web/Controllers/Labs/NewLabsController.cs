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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ViewModelNewLab newLab)
        {
            Lab lab = new Lab();
            lab.Start_Time = newLab.Start_Time;
            lab.End_Time = newLab.End_Time;
            lab.Name = newLab.Name.Trim();
            lab.Time_Zone = "Asia/Calcutta";
            lab.Status = "Scheduled";
            lab.User_ID = 5;

            LabConfiguration labConfig = new LabConfiguration();
            labConfig.OS = newLab.OS.Trim();
            labConfig.VM_Count = newLab.VM_Count;
            labConfig.Hard_Disk = newLab.Hard_Disk.Trim();
            labConfig.VM_Type = newLab.VM_Type.Trim();
            labConfig.Networked = newLab.VMNetwork.Trim();

            IjepaiEntities db = new IjepaiEntities();
            db.LabConfigurations.Add(labConfig);
            db.SaveChanges();
            lab.Config_ID = labConfig.ID;
            db.Labs.Add(lab);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }

            return View("~/Views/MyLabs/LabDetail.cshtml", newLab);
        }

        [HttpPost]
        public JsonResult EditLab(ViewModelEditLab labProp)
        {
            IjepaiEntities db = new IjepaiEntities();
            Lab lab = db.Labs.Find(labProp.Lab_ID_For_Edit);
            lab.Name = labProp.Name.Trim();
            lab.Start_Time = labProp.Start_Time;
            lab.End_Time = labProp.End_Time;
            lab.LabConfiguration.Networked = labProp.VMNetwork.Trim();
            lab.LabConfiguration.OS = labProp.OS.Trim();
            lab.LabConfiguration.VM_Type = labProp.VM_Type.Trim();
            lab.LabConfiguration.VM_Count = labProp.VM_Count;

            db.Entry(lab).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(new { Status = 0, Message = "Lab updated succesfully." });
        }

        [HttpPost]
        public JsonResult EditLabParticipants(ViewModelEditParticipants newLabParticipants)
        {
            IjepaiEntities db = new IjepaiEntities();
            var participants = db.LabParticipants.Where(p => p.Lab_Id == newLabParticipants.Participants_Of_Lab);
            return Json(new { Status = 0, Message = "Participants updated successfully." });
        }

        [HttpPost]
        public JsonResult ExtendLab(ViewModelExtendLab labProp)
        {
            IjepaiEntities db = new IjepaiEntities();
            Lab lab = db.Labs.Find(labProp.Lab_ID_For_Extend);
            lab.End_Time = labProp.End_Time;
            db.SaveChanges();
            return Json(new { Status = 0, Message = "Lab extended successfully." });
        }

        [HttpPost]
        public JsonResult DeleteLab(int Lab_ID_For_Deletion)
        {
            IjepaiEntities db = new IjepaiEntities();
            db.Billings.Where(bill => bill.Lab_Id == Lab_ID_For_Deletion).ToList().ForEach(b => db.Billings.Remove(b));
            db.LabParticipants.Where(p => p.Lab_Id == Lab_ID_For_Deletion).ToList().ForEach(p => db.LabParticipants.Remove(p));

            Lab lab = db.Labs.Find(Lab_ID_For_Deletion);

            db.LabSoftwares.Where(s => s.Config_Id == lab.Config_ID).ToList().ForEach(s => db.LabSoftwares.Remove(s));
            db.LabConfigurations.Where(c => c.ID == lab.Config_ID).ToList().ForEach(c => db.LabConfigurations.Remove(c));
            db.Labs.Remove(lab);

            db.SaveChanges();


            return Json(new { Status = 0, Message = "Lab deleted successfully." });
        }

        public ActionResult BlankParticipantRow(int Count)
        {
            ViewBag.ParticipantNum = Count;
            return View("NewParticipantRow", new Participant());
        }
    }
}