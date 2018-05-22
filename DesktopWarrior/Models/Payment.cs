using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesktopWarrior.Models
{
    public class Payment
    {
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

        public string CardLastFour()
        {
            return "xxxx xxxx xxxx " + CardNumber.Substring(CardNumber.Length - 4);
        }
    }
}