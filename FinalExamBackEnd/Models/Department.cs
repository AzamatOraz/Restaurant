using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FinalExamBackEnd.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Department")]
        public string DepName { get; set; }
    }
}