
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ViewModels
{
    public class TaskItemViewModel : BaseViewModel
    {
        private readonly CancellationTokenSource cts_ = new();
        public ICommand NavigateToTasksCommand { get; }


        private int taskId;

        public int TaskId
        {
            get => taskId;
            set
            {
                if (taskId != value)
                {
                    taskId = value;
                    OnPropertyChanged(nameof(TaskId));
                }
            }
        }

        private double progress;

        public double Progress
        {
            get => progress;
            set
            {
                if (progress != value)
                {
                    progress = value;
                    OnPropertyChanged(nameof(Progress));
                    OnPropertyChanged(nameof(StatusText));
                }
            }
        }

        public string StatusText =>
            $"{Progress * 100:F0}%";

        private bool isCancelEnabled = true;

        public bool IsCancelEnabled
        {
            get => isCancelEnabled;
            set
            {
                if (isCancelEnabled != value)
                {
                    isCancelEnabled = value;
                    OnPropertyChanged(nameof(IsCancelEnabled));
                }
            }
        }

        public ICommand CancelCommand { get; }

        public TaskItemViewModel()
        {
            CancelCommand = new Command(() =>
            {
                cts_.Cancel();
                IsCancelEnabled = false;
            });
            NavigateToTasksCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("TaskPage");
            });
        }

        public async Task<bool> RunAsync()
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    cts_.Token.ThrowIfCancellationRequested();

                    Progress = i / 100.0;

                    await Task.Delay(50, cts_.Token);
                }

                IsCancelEnabled = false;
                return true;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            finally
            {
                cts_.Dispose();
            }
        }
    }
}
