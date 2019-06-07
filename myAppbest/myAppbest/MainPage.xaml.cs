using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace myAppbest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("myAppbest.Assets.Images.user.png", assembly);
        }


        void Button_Clicked(object sender, EventArgs events)
        {
            //sayHiLabel.Text = "Wel come, " + nameEntry.Text;
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            if (isEmailEmpty||isPasswordEmpty)
            {
                inputValidation.Text = "email or password is empty!";
            }
            else
            {
                // inputValidation.Text = "your email is "+emailEntry.Text+" and your password is "+passwordEntry.Text;
                var username = emailEntry.Text;
                var password = passwordEntry.Text;
                if (username != "zemi" || password != "zemiman")
                {
                    DisplayAlert("Failure", "Invalid username or password!", "Ok");
                }
                else
                {
                    Navigation.PushAsync(new homePage());

                }
                

            }
        }//end of Button_Clicked function:

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}
