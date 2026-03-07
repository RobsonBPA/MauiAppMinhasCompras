namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
            // Redireciona o usuário para a página de cadastro de produto
            Navigation.PushAsync(new Views.NovoProduto());
		} catch (Exception ex)
		{
            // Mensagem de erro
            DisplayAlertAsync("Ops", ex.Message, "OK");
		}
    }
}