using System;
using System.ComponentModel.DataAnnotations;

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

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public EmailAddressAttribute Email { get; set; }
    }
}