using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StartInit
{
    class SecondPage : StackLayout
    {
        public SecondPage()
        {
            VerticalOptions = LayoutOptions.Center;
            HorizontalOptions = LayoutOptions.CenterAndExpand;

            string n = FistPage._name;
            
            Label title = new Label();
            title.Text = "We need more!";
            title.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));

            Switch switcher = new Switch();
            switcher.HorizontalOptions = LayoutOptions.Center;
            
            switcher.Toggled += (s, e) => 
            {
                if (e.Value == true)
                    title.RotateXTo(180, 700, Easing.CubicOut);
                else
                    title.RotateXTo(0, 700, Easing.CubicOut);
            };

            Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
            {
                { "Aqua", Color.Aqua }, { "Black", Color.Black },
                { "Blue", Color.Blue }, { "Fucshia", Color.Fuchsia },
                { "Gray", Color.Gray }, { "Green", Color.Green },
                { "Lime", Color.Lime }, { "Maroon", Color.Maroon },
                { "Navy", Color.Navy }, { "Olive", Color.Olive },
                { "Purple", Color.Purple }, { "Red", Color.Red },
                { "Silver", Color.Silver }, { "Teal", Color.Teal },
                { "White", Color.White }, { "Yellow", Color.Yellow }
            };

            Picker picker = new Picker();
            picker.Title = "Color";
            picker.VerticalOptions = LayoutOptions.CenterAndExpand;

            foreach (string colorName in nameToColor.Keys)
            {
                picker.Items.Add(colorName);
            }

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    title.TextColor = Color.Default;
                }
                else
                {
                    string colorName = picker.Items[picker.SelectedIndex];
                    title.TextColor = nameToColor[colorName];
                }
            };

            Children.Add(title);
            Children.Add(switcher);
            Children.Add(picker);

        }
    }
}
