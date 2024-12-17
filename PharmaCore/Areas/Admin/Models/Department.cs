using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaCore.Models
{
    
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }
        public ICollection<User> Users { get; set; } // مجموعه کاربران

    }
}