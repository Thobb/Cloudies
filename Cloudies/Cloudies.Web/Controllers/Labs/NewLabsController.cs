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
            lab.Name = newLab.Name;
            lab.Time_Zone = "Asia/Calcutta";
            lab.User_ID = 5;

            LabConfiguration labConfig = new LabConfiguration();
            labConfig.OS = newLab.OS;
            labConfig.VM_Count = newLab.VM_Count;
            labConfig.Hard_Disk = newLab.Hard_Disk;
            labConfig.VM_Type = newLab.VM_Type;
            labConfig.Networked = newLab.VMNetwork;

            IjepaiEntities db = new IjepaiEntities();
            db.LabConfigurations.Add(labConfig);
            lab.Config_ID = labConfig.ID;
            db.Labs.Add(lab);

            foreach (var participant in newLab.Participants)
            {
                LabParticipant labParticipant = new LabParticipant();
                labParticipant.Email_Address = participant.Username;
                labParticipant.First_Name = participant.First_Name;
                labParticipant.Last_Name = participant.Last_Name;
                labParticipant.Role = participant.Role;
                labParticipant.Lab_Id = labConfig.ID;
                db.LabParticipants.Add(labParticipant);
            }

            db.SaveChanges();

            return View("~/Views/MyLabs/LabDetail.cshtml", newLab);
        }

        public ActionResult BlankParticipantRow(int Count)
        {
            ViewBag.ParticipantNum = Count;
            return View("NewParticipantRow", new Participant());
        }
	}
}