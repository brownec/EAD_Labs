using System;
using System.ComponentModel.DataAnnotations;

/* Build an ASP.Net MVC application which allows a user to send a text message. 
 * A text message has a destination mobile phone number (10 digits) and content (max 140 characters). 
 * A text message should be a model class. 
 * Use model validation attributes as you see fit */

namespace Task1.Models
{
    public class TextMessage
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Number must not be blank!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits long")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits long")]
        [System.ComponentModel.DisplayName("To")]
        public String ToMobileNumber { get; set; }

        [Required(ErrorMessage = "Message must not be blank!")]
        [StringLength(140, ErrorMessage = "Message must be no more than 140 characters long")]
        [System.ComponentModel.DisplayName("Message")]
        public String Content { get; set; }
    }
}