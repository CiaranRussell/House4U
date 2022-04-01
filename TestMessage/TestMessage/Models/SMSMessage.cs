using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestMessage.Models
{
    public class SMSMessage
    {
        [Required(ErrorMessage ="Need a Number!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone Number must be 10 digits")]
        [DisplayName("To")]
        public string ToMobileNumber { get; set; }

        [Required(ErrorMessage = "Message must not be blank")]
        [StringLength(140, ErrorMessage = "Max Message 140 Characters")]
        [DisplayName("Message")]
        public string Content { get; set; }


    }
}
