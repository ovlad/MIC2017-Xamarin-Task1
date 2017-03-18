using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StartInit
{
    class MainPage : ContentPage
    {
        const int PADDING = 16;
        const int DEFAULT_BTN_MARGIN_LEFT = -4;
        const int DEFAULT_BTN_MARGIN_TOP = -6;
        const int DEFAULT_BTN_MARGIN_RIGHT = -4;
        const int DEFAULT_BTN_MARGIN_BOTTOM = -6;
        const int NR_PANELS = 3;
        const int DOT_SIZE = PADDING / 2;

        int currentPanelIndex;

        public MainPage()
        {
            currentPanelIndex = 0;

            AbsoluteLayout panels = new AbsoluteLayout();
            panels.BackgroundColor = Color.FromHex("#3598D9");
            panels.HorizontalOptions = LayoutOptions.FillAndExpand;
            panels.VerticalOptions = LayoutOptions.FillAndExpand;

            FistPage firstPage = new FistPage();
            SecondPage secondPage = new SecondPage();
            ThirdPage thirdPage = new ThirdPage();

            AbsoluteLayout.SetLayoutFlags(firstPage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(firstPage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(secondPage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(secondPage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(thirdPage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(thirdPage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            StackLayout[] stackLayoutArr = new StackLayout[NR_PANELS];

            stackLayoutArr[0] = firstPage;
            stackLayoutArr[1] = secondPage;
            stackLayoutArr[2] = thirdPage;

            firstPage.Opacity = 0;
            secondPage.Opacity = 0;
            thirdPage.Opacity = 0;
            firstPage.IsVisible = false;
            secondPage.IsVisible = false;
            thirdPage.IsVisible = false;

            panels.Children.Add(firstPage);
            panels.Children.Add(secondPage);
            panels.Children.Add(thirdPage);

            Grid dotsGrid = new Grid();
            dotsGrid.ColumnSpacing = PADDING;
            dotsGrid.RowSpacing = 0;            
            dotsGrid.HorizontalOptions = LayoutOptions.Center;

            for (int i = 0; i < NR_PANELS; i++)
                dotsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });

            for (int i = 0; i < NR_PANELS; i++)
            {
                Button dot = new Button();
                dot.BackgroundColor = Color.FromHex("#3598D9");
                dot.BorderRadius = DOT_SIZE / 2;
                dot.HeightRequest = DOT_SIZE;
                dot.WidthRequest = DOT_SIZE;
                dot.Margin = new Thickness(0, 4, 0, 4);

                if (i == 0)
                {
                    makeBig(dot);
                    enter(firstPage);
                }

                dotsGrid.Children.Add(dot, i, 0);
            }

            Button btnPrev = new Button();
            btnPrev.Margin = new Thickness(DEFAULT_BTN_MARGIN_LEFT, DEFAULT_BTN_MARGIN_TOP, DEFAULT_BTN_MARGIN_RIGHT, DEFAULT_BTN_MARGIN_BOTTOM);
            btnPrev.Text = "Back";
            btnPrev.Clicked += (s, e) => 
            {
                int aux = currentPanelIndex - 1;
                aux = aux < 0 ? NR_PANELS + aux : aux;
                int indexOfDotToMakeBig = aux % NR_PANELS;
                int count = 0;

                IEnumerator<View> iterator = dotsGrid.Children.GetEnumerator();
                while (iterator.MoveNext())
                {
                    if (count % NR_PANELS == currentPanelIndex)
                    {
                        makeSmall((Button)iterator.Current);
                        exit(stackLayoutArr[currentPanelIndex]);
                    }
                    else if (count == indexOfDotToMakeBig)
                    {
                        makeBig((Button)iterator.Current);
                        enter(stackLayoutArr[indexOfDotToMakeBig]);
                    }

                    count++;
                }

                currentPanelIndex = indexOfDotToMakeBig;
            };

            Button btnNext = new Button();
            btnNext.Margin = new Thickness(DEFAULT_BTN_MARGIN_LEFT, DEFAULT_BTN_MARGIN_TOP, DEFAULT_BTN_MARGIN_RIGHT, DEFAULT_BTN_MARGIN_BOTTOM);
            btnNext.Text = "Next";
            btnNext.Clicked += (s, e) =>
            {
                int indexOfDotToMakeBig = (currentPanelIndex + 1) % NR_PANELS;
                int count = 0;

                IEnumerator<View> iterator = dotsGrid.Children.GetEnumerator();
                while (iterator.MoveNext())
                {
                    if (count % NR_PANELS == currentPanelIndex)
                    {
                        makeSmall((Button)iterator.Current);
                        exit(stackLayoutArr[currentPanelIndex]);
                    }
                    else if (count == indexOfDotToMakeBig)
                    {
                        makeBig((Button)iterator.Current);
                        enter(stackLayoutArr[indexOfDotToMakeBig]);
                    }
                        
                    count++;
                }

                currentPanelIndex = indexOfDotToMakeBig;
            };


            Grid buttomButtonsGrid = new Grid();
            buttomButtonsGrid.ColumnSpacing = PADDING;
            buttomButtonsGrid.RowSpacing = 0;
            buttomButtonsGrid.Padding = new Thickness(0, PADDING, 0, 0);
            buttomButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            buttomButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            buttomButtonsGrid.Children.Add(btnPrev, 0, 0);
            buttomButtonsGrid.Children.Add(btnNext, 1, 0);

            Grid bottomGrid = new Grid();
            bottomGrid.ColumnSpacing = 0;
            bottomGrid.RowSpacing = 0;
            bottomGrid.Padding = PADDING;
            bottomGrid.BackgroundColor = Color.FromHex("#eeeeee");
            bottomGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            bottomGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            
            bottomGrid.Children.Add(dotsGrid, 0, 0);
            bottomGrid.Children.Add(buttomButtonsGrid, 0, 1);

            Grid mainGrid = new Grid();
            mainGrid.ColumnSpacing = 0;
            mainGrid.RowSpacing = 0;
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            mainGrid.Children.Add(panels, 0, 0);
            mainGrid.Children.Add(bottomGrid, 0, 1);

            Content = mainGrid;
        }

        public void makeSmall(Button dot)
        {
            dot.ScaleTo(1, 300, Easing.CubicInOut);
        }

        public void makeBig(Button dot)
        {
            dot.ScaleTo(1.75, 300, Easing.CubicInOut);
        }

        public void enter(StackLayout page)
        {
            page.IsVisible = true;
            page.FadeTo(1, 300, Easing.CubicInOut);
        }

        public void exit(StackLayout page)
        {
            page.FadeTo(0, 300, Easing.CubicInOut);
            page.IsVisible = false;
        }
  
    }

}
