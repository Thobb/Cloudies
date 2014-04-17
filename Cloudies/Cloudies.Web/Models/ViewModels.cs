using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cloudies.Web.Models
{
    public class ViewModelNewLab
    {
        [Required]
        [DisplayName("Lab Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Number of VM's")]
        public int VM_Count { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Start Time")]
        public DateTime Start_Time { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("End Time")]
        public DateTime End_Time { get; set; }

        [Required]
        [DisplayName("OS")]
        public string OS { get; set; }
        [DisplayName("Softwares")]
        public ICollection<string> Softwares { get; set; }
        [Required]
        [DisplayName("VM Type")]
        public string VM_Type { get; set; }
        [Required]
        [DisplayName("VM HD Size")]
        public string Hard_Disk { get; set; }
        [Required]
        [DisplayName("VM Network")]
        public string VMNetwork { get; set; }

    }

    public class Participant
    {
        [DisplayName("Username")]
        public string Username { get; set; }

        [DisplayName("First name")]
        public string First_Name { get; set; }

        [DisplayName("Last Name")]
        public string Last_Name { get; set; }

        [DisplayName("Role")]
        public string Role { get; set; }
    }

    public class ViewModelExtendLab
    {
        [Required]
        public int Lab_ID_For_Extend { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("End Time")]
        public DateTime End_Time { get; set; }
    }

    public class ViewModelEditLab
    {
        [Required]
        public int Lab_ID_For_Edit { get; set; }
        [Required]
        [DisplayName("Lab Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Number of VM's")]
        public int VM_Count { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Start Time")]
        public DateTime Start_Time { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("End Time")]
        public DateTime End_Time { get; set; }

        [Required]
        [DisplayName("OS")]
        public string OS { get; set; }
        [DisplayName("Softwares")]
        public ICollection<string> Softwares { get; set; }
        [Required]
        [DisplayName("VM Type")]
        public string VM_Type { get; set; }
        [Required]
        [DisplayName("VM HD Size")]
        public string Hard_Disk { get; set; }
        [Required]
        [DisplayName("VM Network")]
        public string VMNetwork { get; set; }
    }

    public class ViewModelEditParticipants
    {
        public int Participants_Of_Lab { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}