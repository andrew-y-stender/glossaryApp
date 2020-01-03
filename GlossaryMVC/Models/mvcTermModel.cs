using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlossaryMVC.Models
{
    public class mvcTermModel
    {
        public int TermID { get; set; }
        [Required(ErrorMessage = "Term is Required")]
        public string TermName { get; set; }
        [Required(ErrorMessage = "Definition is Required")]
        public string TermDefinition { get; set; }
    }
}