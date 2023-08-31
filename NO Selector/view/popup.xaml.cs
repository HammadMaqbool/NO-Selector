namespace NO_Selector.view;

using CommunityToolkit.Maui.Views;
using NO_Selector.viewmodel;

public partial class popup :Popup
{
    

    public popup(MainPageVM mainpagevm)
	{
		InitializeComponent();
		BindingContext= mainpagevm;
	}
}