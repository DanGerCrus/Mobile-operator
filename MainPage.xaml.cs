using Newtonsoft.Json;
using Operator.Models;

namespace Operator;

public partial class MainPage : ContentPage
{
	private HttpClient client = new HttpClient();
	private List<AbonentsInfo>AbonentsData= new List<AbonentsInfo>();

	public MainPage()
	{
		InitializeComponent();
		getData();
    }

	private async void getData() {
        var response = await client.GetAsync("http://localhost:64382/api/Abonents");
        var json = await response.Content.ReadAsStringAsync();
        var Data = JsonConvert.DeserializeObject<List<Models.AbonentsInfo>>(json);
		Abonents.ItemsSource = Data;
    }
	
	private async void delAbonent(int id)
	{
		await client.DeleteAsync($"http://localhost:64382/api/Abonents/{id}");
        
		getData();
    }

    private void deleteAbonent_Clicked(object sender, EventArgs e)
    {
		var item = (sender as Button).BindingContext as AbonentsInfo;
		if (item != null)
		{
			delAbonent(item.id_abonent);
		}
    }

    private async void changeAbonent_Clicked(object sender, EventArgs e)
    {
        var item = (sender as Button).BindingContext as AbonentsInfo;
        await Navigation.PushModalAsync(new StaffEditAdd(item));
    }

    private async void newAbonent_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new StaffEditAdd(null));
    }
}