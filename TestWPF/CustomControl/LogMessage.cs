using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.CustomControls
{
    // If plnanning to modify existing messages e.g. in order to append text,
    // the Message property must have a set() and must raise the PropertyChanged event.
    // For now, this isn't wired up, because the text will not be changed once it is added.
    public class LogMessage : INotifyPropertyChanged
    {

        public LogMessage(string message, LogLevel logLevel)
        {
            this.Message = message;
            this.LogLevel = logLevel;
            
        }
        public string Message { get; }
        public LogLevel LogLevel { get; }
        public bool IsNewLine { get; set; } = true;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
