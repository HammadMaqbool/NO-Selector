using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Xaml;
using NO_Selector.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NO_Selector.viewmodel
{
    public partial class MainPageVM : BaseVM
    {

        [ObservableProperty]
        private string phonenumber;

        private void openWhatsApp()
        {
            if (!String.IsNullOrEmpty(Phonenumber))
            {
              
                string completelink = "https://wa.me/" + Phonenumber;
                Launcher.OpenAsync(completelink).Wait();
            }
        }


        private void DialerOpener()
        {
            if (!string.IsNullOrEmpty(Phonenumber))
            {
                if (PhoneDialer.Default.IsSupported)
                {
                    PhoneDialer.Default.Open(Phonenumber);
                }
            }
        }


        private void SMSOpener()
        {
            if (!string.IsNullOrEmpty(Phonenumber))
            {
                if (Sms.Default.IsComposeSupported)
                {
                    string SMS_Message = String.Empty;
                    var message = new SmsMessage(SMS_Message, Phonenumber);
                    Sms.ComposeAsync(message).Wait();

                }
            }
        }

        [RelayCommand]
        public async Task ActionDecider()
        {
            Vibration.Default.Vibrate();
            string result = await Shell.Current.DisplayActionSheet("Select Action", "Cancle", null, "Call", "SMS", "WhatsApp");

            if (result.Equals("Call"))
            {
                DialerOpener();
            }
            else if (result.Equals("SMS"))
            {
                SMSOpener();
            }
            else if (result.Equals("WhatsApp"))
            {
                openWhatsApp();
            }
        }
        [RelayCommand]
        public void Poopupopener()
        {

            var popups = new popup(new MainPageVM());
            Shell.Current.CurrentPage.ShowPopup(popups);
        }
        //this is the comment I am adding in code.
        [RelayCommand]
        public void ClearEntryCommand()
        {
            string Number = Phonenumber;
            string FinalResult = "";
            if (Number.Length > 0)
            {
               FinalResult = Number.Substring(0, Number.Length - 1);
            }
            Phonenumber = FinalResult;
        }
    }
}
