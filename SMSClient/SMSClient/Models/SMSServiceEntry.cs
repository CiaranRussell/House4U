using System;
using System.IO;
using System.Text.Json.Serialization;

namespace SMSService.Models
{
    public class SMSServiceEntry
    {
        public string SenderNumber { get; set; }

        public string ReceiverNumber { get; set; }

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

        public void LogSMSMessage()
        {
            logger.LogMessage("Sender: " +SenderNumber + " | Receiver: " +ReceiverNumber+" | Message: " +Message+ " | ");
        }

        public override string ToString()
        {
            return String.Format("Sender: {0} | Receiver: {1} | Message {2}",SenderNumber,ReceiverNumber,Message);
        }  

    }


    public interface ILogger
    { 
        void LogMessage(string message);
        
    }

    public class FileLogger : ILogger
    { 
        
        string filename = @"C:\Users\Ciaran.Russell\LogFile.txt";

        public void LogMessage(string message)
        {
            
            File.AppendAllText(filename, DateTime.Now.ToShortTimeString() + ": " + message);
            
        }

        
    }


}
