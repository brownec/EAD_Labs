using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextMessage.Models
{
    public class TextMsg
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Number must not be blank!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits long!")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits!")]
        [System.ComponentModel.DisplayName("To: ")]
        public String ToMobileNumber { get; set; }

        [Required(ErrorMessage="Message must not be blank!")]
        [StringLength(140, ErrorMessage="Message must be no more than 140 characters!")]
        [System.ComponentModel.DisplayName("Message: ")]
        public String Content { get; set; }
    }
}