using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

// https://stackoverflow.com/questions/71681471/make-richtextbox-automatically-scroll-to-bottom-when-content-is-added

namespace TestWPF.CustomControls
{
    /// <summary>
    /// Interaction logic for LogMessageBox.xaml
    /// </summary>
    public partial class LogMessageBox : UserControl
    {


        public IList<object> LogMessagesSource
        {
            get => (IList<object>)GetValue(LogMessagesSourceProperty);
            set => SetValue(LogMessagesSourceProperty, value);
        }

        public static readonly DependencyProperty LogMessagesSourceProperty = DependencyProperty.Register(
          "LogMessagesSource",
          typeof(IList<object>),
          typeof(LogMessageBox),
          new PropertyMetadata(default(IList<object>), OnLogMessagesSourceChanged));

        public LogMessageBox()
        {
            InitializeComponent();

        }

        private static void OnLogMessagesSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
          => (d as LogMessageBox).OnLogMessagesSourceChanged(e.OldValue as IList<object>, e.NewValue as IList<object>);

        // Listen to CollectionChanged events 
        // in order to always keep the last and latest item in view.
        protected virtual void OnLogMessagesSourceChanged(IList<object> oldMessages, IList<object> newMessages)
        {
            if (oldMessages is INotifyCollectionChanged oldObservableCollection)
            {
                oldObservableCollection.CollectionChanged -= OnLogMessageCollectionChanged;
            }
            if (newMessages is INotifyCollectionChanged newObservableCollection)
            {
                newObservableCollection.CollectionChanged += OnLogMessageCollectionChanged;
            }
        }

        private void OnLogMessageCollectionChanged(object sender = null, NotifyCollectionChangedEventArgs e = null)
        {
            object lastMessageItem = this.LogMessagesSource.LastOrDefault();
            ListBox listBox = this.Output;
            Dispatcher.InvokeAsync(
              () => listBox.ScrollIntoView(lastMessageItem),
              DispatcherPriority.Background);
        }


    }
}
