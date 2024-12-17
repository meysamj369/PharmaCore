using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PharmaCore.Models
{
   
    public class Section
    {
        public int SectionId { get; set; }
        public int ModualId { get; set; } // کلید خارجی
        public string SectionCode { get; set; }
        public string SectionName { get; set; }

       
        public Modual Modual { get; set; } // مرجع به ماژول

        public ICollection<UserAccessModualSection> UserAccessModualSections { get; set; }
    }
}