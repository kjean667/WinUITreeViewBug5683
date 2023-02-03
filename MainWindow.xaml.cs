using Microsoft.UI.Xaml;

namespace WinUITreeViewBug5683
{
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; private set; }

        public MainWindow()
        {
            ViewModel = new MainViewModel();
            this.InitializeComponent();
        }
    }
}
