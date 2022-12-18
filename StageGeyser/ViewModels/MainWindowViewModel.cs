using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;

namespace StageGeyser.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string documentContent = "TempContent";
        public string DocumentContent {
            get => documentContent;
            set => this.RaiseAndSetIfChanged(ref documentContent, value);
        }
        public async void OpenFile() {
            OpenFileDialog dialog = new OpenFileDialog();
            string[]? filePathsNullable = null;
            string filePath = "";
            if(App.Current != null && App.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                filePathsNullable = await dialog.ShowAsync(desktop.MainWindow);
            }
            if(filePathsNullable != null) {
                filePath = filePathsNullable[0];
            }
            this.DocumentContent = filePath;
        }
    }
}
