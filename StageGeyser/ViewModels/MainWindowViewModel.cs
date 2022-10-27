namespace StageGeyser.ViewModels
{
    using ReactiveUI;
    using StageGeyser.Models;
    public class MainWindowViewModel : ViewModelBase
    {
        private string documentContent = "Open A File...";
        public string DocumentContent {
            get => documentContent;
            set => this.RaiseAndSetIfChanged(ref documentContent, value);
        }
        public MainWindowViewModel() {

        }
        public async void OpenFile() {
            DocumentContent = await FileManager.Open();
        }
    }
}
