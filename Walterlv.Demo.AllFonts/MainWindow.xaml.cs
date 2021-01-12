using System.Windows;
using System.Windows.Threading;

namespace Walterlv.Demo.AllFonts
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            InitializeComponent();
        }

        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), "UnhandledException");
        }
    }
}
