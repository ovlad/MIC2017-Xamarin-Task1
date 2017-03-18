using Xamarin.Forms;

namespace StartInit
{
    class ThirdPage : StackLayout
    {
        public ThirdPage()
        {
            VerticalOptions = LayoutOptions.Center;
            HorizontalOptions = LayoutOptions.Center;

            Image img = new Image();
            img.Aspect = Aspect.AspectFit;
            img.Source = ImageSource.FromFile("Icon.png");

            Label label = new Label();
            label.HorizontalOptions = LayoutOptions.Center;
            label.Text = "0";

            Slider slider = new Slider();
            slider.HorizontalOptions = LayoutOptions.Center;
            slider.WidthRequest = 200;
            slider.Minimum = 0;
            slider.Maximum = 100;
            slider.Value = 0;
            slider.ValueChanged += (s, e) =>
            {
                label.Text = e.NewValue.ToString();
            };

            Children.Add(img);
            Children.Add(slider);
            Children.Add(label);
        }
    }
}
