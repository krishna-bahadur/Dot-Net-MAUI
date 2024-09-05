using MyFirstMauiApp.ViewModel;

namespace MyFirstMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
    }

}
