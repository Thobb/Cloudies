//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cloudies.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lab
    {
        public Lab()
        {
            this.Billings = new HashSet<Billing>();
            this.LabParticipants = new HashSet<LabParticipant>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Time_Zone { get; set; }
        public System.DateTime Start_Time { get; set; }
        public System.DateTime End_Time { get; set; }
        public int Config_ID { get; set; }
        public int User_ID { get; set; }
        public string Status { get; set; }
        public string HKey { get; set; }
    
        public virtual ICollection<Billing> Billings { get; set; }
        public virtual LabConfiguration LabConfiguration { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<LabParticipant> LabParticipants { get; set; }
    }
}
