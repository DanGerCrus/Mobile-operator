using Newtonsoft.Json;
using Operator.Pages;

namespace Operator;

public partial class LoginPage : ContentPage
{
    readonly HttpClient client = new();

    public LoginPage()
	{
		InitializeComponent();
	}
    
    private async void Auth_Clicked(object sender, EventArgs e)
    {
        var response = await client.GetAsync("http://localhost:64382/api/Staffs");
        var json = await response.Content.ReadAsStringAsync();
        var staff = JsonConvert.DeserializeObject<List<Models.Auth>>(json);
        var first = staff.FirstOrDefault(x => x.email == login.Text && x.password == password.Text);
       
		if (first != null)
		{

		await Navigation.PushModalAsync(new MainPage());		
			
		}
		else
		{
            await DisplayAlert("Уведомление", "Неверный логин или пароль", "Ok!");
        }
    }    
}