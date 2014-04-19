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


            try
            {
                db.SaveChanges();
                lab.Config_ID = labConfig.ID;
                db.Labs.Add(lab);
                db.SaveChanges();
                StoreParticipants(newLab.Participants, lab.ID);
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }

            return View("~/Views/MyLabs/Index.cshtml");
        }

        public int StoreParticipants(ICollection<Participant> Participants, int Participants_Of_Lab)
        {
            IjepaiEntities db = new IjepaiEntities();
            db.LabParticipants.Where(p => p.Lab_Id == Participants_Of_Lab).ToList().ForEach(p => db.LabParticipants.Remove(p));
            if (Participants != null)
            {
                foreach (Participant participant in Participants)
                {
                    if (participant.Username != null)
                    {
                        LabParticipant labParticipant = new LabParticipant();
                        labParticipant.Email_Address = participant.Username.Trim();
                        if(participant.First_Name != null) labParticipant.First_Name = participant.First_Name.Trim();
                        if(participant.Last_Name != null) labParticipant.Last_Name = participant.Last_Name.Trim();
                        labParticipant.Role = participant.Role.Trim();
                        labParticipant.Lab_Id = Participants_Of_Lab;
                        db.LabParticipants.Add(labParticipant);
                        db.SaveChanges();
                    }
                }
            }
            return 0;
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