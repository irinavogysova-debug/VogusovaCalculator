using System.Windows;
using VogusovaCalculator.UI.ViewModels;

namespace VogusovaCalculator.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}