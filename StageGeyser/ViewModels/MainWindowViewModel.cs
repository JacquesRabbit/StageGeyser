using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using StageGeyser.SGXML;
using StageGeyser.Geyser;
namespace StageGeyser.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        Script? script;
        private Control documentContent = new Control();
        public Control DocumentContent {
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
            this.script = new Script(SGXMLParser.ReadFile(filePath));
            this.DocumentContent = script.GenerateControl();
            
        }
    }
}
