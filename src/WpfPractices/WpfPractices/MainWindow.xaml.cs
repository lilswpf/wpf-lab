using System;
using WpfPractices.Views;

namespace WpfPractices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            NonClientAreaContent = new NonClientAreaContent();
        }
    }
}
