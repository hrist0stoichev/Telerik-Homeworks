//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace World.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class continent
    {
        public continent()
        {
            this.countries = new HashSet<country>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<country> countries { get; set; }
    }
}