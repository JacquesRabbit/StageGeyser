namespace StageGeyser.Models {
    using System.Threading.Tasks;
    using Avalonia.Controls;
    using Avalonia.Controls.ApplicationLifetimes;
    public static class FileManager {

        public async static Task<string[]> Open() {
            OpenFileDialog dialog = new OpenFileDialog();
            if(App.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                return await dialog.ShowAsync(desktop.MainWindow);
            }
            else return null;
        }
    }
}