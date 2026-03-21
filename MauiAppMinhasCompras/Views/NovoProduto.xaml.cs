using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto p = new Produto
			{
				// Obtém os valores inseridos pelo usuário
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};

			await App.Db.Insert(p);
			// Mensagem de sucesso
			await DisplayAlertAsync("Sucesso!", "Registro inserido", "OK");
            // Redireciona o usuário para a página de visualização dos produtos
            await Navigation.PopAsync();

        } catch (Exception ex)
		{
			// Mensagem de erro
			await DisplayAlertAsync("Ops", ex.Message, "OK");
		}
    }
}