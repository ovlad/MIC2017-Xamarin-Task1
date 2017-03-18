using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StartInit
{
    class FistPage : StackLayout 
    {
        public static string _name;

        public FistPage()
        {

            Label title = new Label();
            title.Text = "What's your name?"; 
            title.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            title.TextColor = Color.FromHex("#eeeeee");

            Entry name = new Entry();
            name.Placeholder = "Name";
            name.TextColor = Color.FromHex("#eeeeee");
            name.PlaceholderColor = Color.FromHex("#eeeeee");

            Entry surname = new Entry();
            surname.Placeholder = "Surname";
            surname.TextColor = Color.FromHex("#eeeeee");
            surname.PlaceholderColor = Color.FromHex("#eeeeee");

            Children.Add(title);
            Children.Add(name);
            Children.Add(surname);

        }
    }
}
