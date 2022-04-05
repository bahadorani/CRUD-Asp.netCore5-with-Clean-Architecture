using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Customer:BaseEntity
    {

        [Required(ErrorMessage = "Please enter your First name")]
        [StringLength(10)]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter your Last name")]
        [StringLength(20)]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter your Date Of Birth")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number")]
        [Display(Name = "Phone")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the AccountNo")]
        [RegularExpression(@"^\d{9,18}$", ErrorMessage = "Please Enter only Numbers")]
        [StringLength(18, ErrorMessage = "The BankAccountNo must be 8-18 numbers only.", MinimumLength = 8)]
        public string BankAccountNumber { get; set; }

    }
}
