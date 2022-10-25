namespace StageGeyser.ViewModels
{
    using ReactiveUI;
    using StageGeyser.Models;
    public class MainWindowViewModel : ViewModelBase
    {
        private const string V = "";
        private string documentContent = "Aplle";
        public string DocumentContent {
            get => documentContent;
            set => this.RaiseAndSetIfChanged(ref documentContent, value);
        }
        public MainWindowViewModel() {

        }
        public async void OpenFile() {
            string[] documentLines = await FileManager.Open();
            DocumentContent = "";
            foreach (string item in documentLines)
            {
                DocumentContent += item;
            }
        }
    }
}
