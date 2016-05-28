using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExamBackEnd.Models
{
    public class Staff
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [Required, MaxLength(20), Index(IsUnique = true)]
        public string Mail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped, Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Password does not match")]
        public string RePassword { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        public int Manager_ID { get; set; }
        public int Department_ID { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public virtual Department Department { get; set; }
        
    }
}