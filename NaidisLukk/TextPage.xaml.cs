using static System.Net.Mime.MediaTypeNames;

namespace NaidisLukk;

public partial class TextPage : ContentPage
{
	Label lbl;
	Editor editor;
	HorizontalStackLayout hsl;
	List<string> nuppud = new List<string>() { "Tagasi", "AvaLeht", "Edasi" }; 
	VerticalStackLayout vsl;
	public TextPage(int i)
	{
		lbl = new Label
		{
			Text = "Pealkiri",
			FontSize = 36,
			FontFamily = "Luckyfield",
			TextColor = Colors.Black,
			HorizontalOptions = LayoutOptions.Center,
			FontAttributes = FontAttributes.Bold
		};
		editor = new Editor
		{
			Placeholder = "Sisesta Tekst...",
			PlaceholderColor = Colors.Blue,
			FontSize = 18,
			FontAttributes = FontAttributes.Italic,
			HorizontalOptions= LayoutOptions.Center,
		};
		editor.TextChanged += (sender, e) =>
		{
			lbl.Text = editor.Text;
		};

		hsl = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };
		for (int j = 0;j < nuppud.Count; j++)
		{
			Button nupp = new Button
			{
				Text = nuppud[j],
				FontSize = 18,
				FontFamily = "Luckyrookie",
				TextColor = Colors.SkyBlue,
				BackgroundColor = Colors.Green,
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
			Children = {lbl ,editor,hsl},
			HorizontalOptions=LayoutOptions.Center
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
			Navigation.PushAsync(new FigurePage());
		}
    }
}