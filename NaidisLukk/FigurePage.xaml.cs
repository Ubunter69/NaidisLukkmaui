using Microsoft.Maui.Controls.Shapes;

namespace NaidisLukk;

public partial class FigurePage : ContentPage
{
    BoxView boxView;
    Ellipse pall;
    Polygon kolmnurk;

    Random rnd = new Random();
    HorizontalStackLayout hsl;
    List<string> nuppud = new List<string>() { "Tagasi", "AvaLeht", "Edasi" };
    VerticalStackLayout vsl;

    public FigurePage()
    {//BoxView kasutamine
        int r = rnd.Next(256);
        int g = rnd.Next(256);
        int b = rnd.Next(256);
        boxView = new BoxView
        {
            Color = Color.FromRgb(r, g, b),
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor=Color.FromRgba(0,0,0,0),// teeb läbipaist, sab peale tekst panna
            CornerRadius = 30,

        };
        TapGestureRecognizer tap = new TapGestureRecognizer();
        boxView.GestureRecognizers.Add(tap);
        tap.Tapped += (sender, e) =>
        {
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
            boxView.Color = Color.FromRgb(r, g, b);
            boxView.WidthRequest = boxView.Width + 20;
            boxView.HeightRequest = boxView.Height + 30;
            if (boxView.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width)
            {
                boxView.WidthRequest = 200;
                boxView.HeightRequest = 200;
            }

        };
        //Ellipse kasutamine
        pall = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill=new SolidColorBrush(Color.FromRgb(r,g,b)),
            Stroke = Colors.BlanchedAlmond,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        pall.GestureRecognizers.Add(tap);
        //Polygon kasutamine
        kolmnurk = new Polygon
        {
            Points = new PointCollection
            {
                new Point(0, 200),//vasak all
                new Point(100, 0),//Keskel
                new Point(200, 200)// parem all
            },
            Fill = new SolidColorBrush(Color.FromRgb(r, g, b)),// kujundi värv brush'i abil
            Stroke = Colors.BlanchedAlmond,//äärise värv
            StrokeThickness = 5,//äärise pikkus
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        TapGestureRecognizer tap_kolmnurk = new TapGestureRecognizer();
        //tap_kolmnurk.NumberOfTapsRequired = 2;
        boxView.GestureRecognizers.Add(tap);
        tap_kolmnurk.Tapped += (sender, e) =>
        {

            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
            boxView.Color = Color.FromRgb(r, g, b);
            boxView.WidthRequest = boxView.Width + 20;
            boxView.HeightRequest = boxView.Height + 30;
            if (boxView.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width)
            {
                boxView.WidthRequest = 200;
                boxView.HeightRequest = 200;
            }
        };




        hsl = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };
        for (int j = 0; j < nuppud.Count; j++)
        {
            Button nupp = new Button
            {
                Text = nuppud[j],
                FontSize = 18,
                FontFamily = "Luckyrookie",
                TextColor = Colors.Olive,
                BackgroundColor = Colors.LightCyan,
                CornerRadius = 10,
                HeightRequest = 40,
                ZIndex = j
            };
            hsl.Add(nupp);
            nupp.Clicked += Liikumine;
        }
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { boxView, hsl, pall},
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }
    private void Liikumine(object? sender, EventArgs e)
    {
        Button nupp = sender as Button;
        if (nupp.ZIndex == 0)
        {
            Navigation.PopAsync();

        }
        else if (nupp.ZIndex == 1)
        {
            Navigation.PopToRootAsync();
        }
        else if (nupp.ZIndex == 2)
        {
            Navigation.PushAsync(new FigurePage()); //Siia lisame uue lehe et edasi liikuda 
        }
    }
}