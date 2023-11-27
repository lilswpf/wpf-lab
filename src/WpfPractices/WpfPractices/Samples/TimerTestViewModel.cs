using System.Timers;
using System.Windows.Input;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfPractices.Samples
{
    partial class TimerTestViewModel : ObservableObject
    {
        private Timer timer;

        public TimerTestViewModel()
        {
            TotalSeconds = 5;
            StartCommand = new RelayCommand(StartTimer);
            ResetCommand = new RelayCommand(ResetTimer);
        }

        [ObservableProperty]
        private string message;

        [ObservableProperty]
        private double totalSeconds;

        public ICommand StartCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        private void StartTimer()
        {
            if (timer != null)
            {
                timer.Stop();
            }
            timer = new Timer(TotalSeconds * 1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false;
            timer.Start();
            Message = "timer start.";
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                Message = "timer stop.";
            });
        }

        private void ResetTimer()
        {
            if (timer != null)
            {
                timer.Interval = TotalSeconds * 1000;
            }
        }
    }
}
