//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Company.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.EmployeesProjects = new HashSet<EmployeesProject>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<EmployeesProject> EmployeesProjects { get; set; }
    }
}
