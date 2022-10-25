using Avalonia.Controls;
using System;
namespace StageGeyser
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void OpenFile(){
            Console.WriteLine("Hello, World!");
        }
    }
}