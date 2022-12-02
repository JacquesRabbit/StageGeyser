namespace StageGeyser.ViewModels
{
    using ReactiveUI;
    using System.Collections.Generic;
    using StageGeyser.Models;
    using StageGeyser.Geyser;
    using Avalonia.Controls;
    public class MainWindowViewModel : ViewModelBase
    {
        private GeyserDocument currentDocument;
        public MainWindowViewModel() {
            currentDocument = new GeyserDocument();
        }
    }
}
