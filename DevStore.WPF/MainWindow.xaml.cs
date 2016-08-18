using System.Windows;

namespace DevStore.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Teste();
        }

        public void Teste()
        {
            this.textBox.Text = "Teste";
        }
   
    }
}
