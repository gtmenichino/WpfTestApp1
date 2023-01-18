using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://stackoverflow.com/questions/71681471/make-richtextbox-automatically-scroll-to-bottom-when-content-is-added

namespace TestWPF.CustomControls
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<LogMessage> LogMessages { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            this.LogMessages = new ObservableCollection<LogMessage>();



            WriteLine("Debug test message.", LogLevel.Debug);
            WriteLine("Info test message.", LogLevel.Info);

            Console.WriteLine("This is a test.  Writing to console.");

        }

        // To implement Write() to avoid line breaks, 
        // simply append the new message text to the previous message.
        public void WriteLine(string message, LogLevel logLevel)
        {
            var newMessage = new LogMessage(message, logLevel) { IsNewLine = true };
            this.LogMessages.Add(newMessage);
        }
    }
}
