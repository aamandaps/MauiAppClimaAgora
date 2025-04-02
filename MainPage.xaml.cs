using MauiAppClimaAgora.Models;
using MauiAppClimaAgora.Services;


namespace MauiAppClimaAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
          
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                { 
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        lbl_resp.Text = dados_previsao;

                        dados_previsao = $"Descrição: " +
                                         $"Latitude: t.{lat} \n" +
                                         $"Longitude: t.{lon} \n" +
                                         $"Visibilidade:t.{visibility} \n " +
                                         $"Temperatura mínima:  t.{temp_min} \n" +
                                         $"Temperatura máxima: t.{temp_max} \n" +
                                         $"Velocidade do vento: t.{speed} \n" +
                                         $"Nascer do sol: t.{sunrise} \n" +
                                         $"Pôr do sol: t.{sunset} \n";
                    }
                    else 
                    {
                        lbl_resp.Text = "Sem dados de previsão";
                    }


                }
                else
                {
                    lbl_res.Text = "Preencha o campo cidade";
                }
                    

            } catch(Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }

}
