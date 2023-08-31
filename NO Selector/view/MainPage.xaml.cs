using NO_Selector.viewmodel;

namespace NO_Selector.view;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageVM mainpagevm)
    {
        InitializeComponent();
        BindingContext = mainpagevm;
    }

   
}

