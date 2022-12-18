using Operator.Models;
using System.Text;
using System.Text.Json;

namespace Operator;

public partial class StaffEditAdd : ContentPage
{
	private HttpClient client= new HttpClient();
	private AbonentsInfo abonent = new AbonentsInfo();
	public StaffEditAdd(AbonentsInfo abonents)
	{
		InitializeComponent();

		if (abonents != null)
		{
            abonent = abonents;
            Name.Text = abonents.Name;
            LastName.Text = abonents.LastName;
            MiddleName.Text = abonents.MiddleName;

        }
		else
		{
			Save.Text = "Создать";
		}
	}

    private async void OtmenaButton_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushModalAsync(new MainPage());
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
		if(Save.Text=="Сохранить"){
            abonent.Name=Name.Text;
            abonent.LastName = LastName.Text;
            abonent.MiddleName = MiddleName.Text;
            var newPostJson = JsonSerializer.Serialize(abonent);
            var body = new StringContent(newPostJson, Encoding.UTF8, "application/json");
            await client.PutAsync("http://localhost:64382/api/Abonents",body);
            await DisplayAlert("Уведомление", "Изменения успешно сохранены", "Ok!");
            await Navigation.PushModalAsync(new MainPage());
        }else
        {
            abonent.Name = Name.Text;
            abonent.LastName = LastName.Text;
            abonent.MiddleName = MiddleName.Text;
            var newPostJson = JsonSerializer.Serialize(abonent);
            var body = new StringContent(newPostJson, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:64382/api/Abonents", body);
            await DisplayAlert("Уведомление", "Пользователь создан", "Ok!");
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}