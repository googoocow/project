//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhaseTwo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contractor
    {
        public Contractor()
        {
            this.Posts = new HashSet<Post>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Nullable<int> jobsposted { get; set; }
        public Nullable<int> hirerate { get; set; }
    
        public virtual ICollection<Post> Posts { get; set; }
    }
}