using DesktopWarrior.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesktopWarrior.Models
{
    public class Checkout
    {
        [DisplayName("First")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Street")]
        public string Address { get; set; }
        [Required]
        [ZipValid]
        public int? Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [DisplayName("Select payment method")]
        public string PaymentMethod { get; set; }

        [DisplayName("Card number")]
        [Required]
        public string CardNumber { get; set; }
        [DisplayName("Expire month")]
        [Required]
        public int? ExpMonth { get; set; }
        [DisplayName("Expire year")]
        [Required]
        public int? ExpYear { get; set; }
        [DisplayName("Control number")]
        [Required]
        public int? ControlNumber { get; set; }
    }
}