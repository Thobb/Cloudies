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
        [DisplayName("Lab Name")]
        public string Name { get; set; }
        [DisplayName("Number of VM's")]
        public int VM_Count { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Start Time")]
        public DateTime Start_Time { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("End Time")]
        public DateTime End_Time { get; set; }

        [DisplayName("OS")]
        public string OS { get; set; }
        [DisplayName("Softwares")]
        public ICollection<string> Softwares { get; set; }
        [DisplayName("VM Type")]
        public string VMType { get; set; }
        [DisplayName("VM RAM")]
        public string Ram{ get; set; }
        [DisplayName("VM HD Size")]
        public string Hard_Disk { get; set; }
        [DisplayName("VM Network")]
        public string VMNetwork { get; set; }

        [DisplayName("Username")]
        public string Username { get; set; }

        [DisplayName("Rights")]
        public string Permissions { get; set; }
    

    }
}