namespace StageGeyser.Models {
    using System.Threading.Tasks;
    using System.IO;
    using Avalonia.Controls;
    using Avalonia.Controls.ApplicationLifetimes;
    public static class FileManager {

        public async static Task<string> Open() {
            OpenFileDialog dialog = new OpenFileDialog();
            if((App.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)) {
                string[] paths = await dialog.ShowAsync(desktop.MainWindow);
                string fileContent = await File.ReadAllTextAsync(paths[0]);
                if(fileContent != null) {
                return fileContent;
                }
            }
            return "";
        }
    }
}