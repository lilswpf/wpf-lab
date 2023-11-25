using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfPractices.ViewModels
{
    partial class MainViewModel:ObservableObject
    {
        [ObservableProperty]
        private string helloText = "Hello World!";
    }
}
