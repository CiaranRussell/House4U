using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SMSService.Models
{
    public class SMSServiceEntry
    {   [Required]
        [Phone]
        public string SenderNumber { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(140)]
        public string ReceiverNumber { get; set; }
        [Required]
        [Phone]
        public string Message { get; set; }

        public ILogger logger;

        public SMSServiceEntry(ILogger logobj, string _sendnum, string _receivenum, string _message)
        {
            this.logger = logobj;
            SenderNumber = _sendnum;
            ReceiverNumber = _receivenum;
            Message = _message;
        }

        [JsonConstructor]
        public SMSServiceEntry() { }
    }

    

}
