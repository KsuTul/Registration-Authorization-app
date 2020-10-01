using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace App.Views
{
    /// <summary>
    /// Interaction logic for ProgressBar.xaml
    /// </summary>
    public partial class ProgressBar : Window
    {
        public ProgressBar()
        {
            InitializeComponent();
            Window_ContentRendered();
        }

        private void Window_ContentRendered()
        {
            var worker = new BackgroundWorker {WorkerReportsProgress = true};
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker)?.ReportProgress(i);
                Thread.Sleep(50);
            }

            MessageBox.Show(" You are with us!");
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Progress.Value = e.ProgressPercentage;
        }
    }
}
