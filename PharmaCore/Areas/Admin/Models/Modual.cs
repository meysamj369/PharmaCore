using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PharmaCore.Models
{
   
    public class Modual
    {
        public int ModualId { get; set; }
        public string ModualName { get; set; }

        public ICollection<UserAccessModual> UserAccessModuals { get; set; } // لیست کاربران ماژول

        public ICollection<Section> Sections { get; set; } // لیستی از سکشنها

        public ICollection<UserAccessModualSection> UserAccessModualSections { get; set; }
    }
}