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
    
    public partial class SoftwareList
    {
        public SoftwareList()
        {
            this.LabSoftwares = new HashSet<LabSoftware>();
        }
    
        public int ID { get; set; }
        public string Software_Name { get; set; }
    
        public virtual ICollection<LabSoftware> LabSoftwares { get; set; }
    }
}