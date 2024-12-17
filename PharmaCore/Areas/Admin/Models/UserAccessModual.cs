using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PharmaCore.Models
{
    
    public class UserAccessModual
    {
        public int UserAccessModuleId { get; set; }
        public int UserId { get; set; }
        public int ModualId { get; set; }
        public bool? CanEnter { get; set; }

        public User User { get; set; } // مرجع کاربر
        public Modual Modual { get; set; } // مرجع ماژول


    }
}