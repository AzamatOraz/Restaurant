using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExamBackEnd.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [Required, MaxLength(20), Index(IsUnique = true)]
        public string Mail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped, Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Password does not match")]
        public string RePassword { get; set; }
        [Required]
        public int Accumulation { get; set; }
        [Required]
        public int Manager_ID { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public virtual Staff Manager { get; set; }
    }
}