using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;

            Produto p = new Produto
            {
                // Obtém os valores inseridos pelo usuário
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Categoria = txt_categoria.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            await App.Db.Update (p);
            // Mensagem de sucesso
            await DisplayAlertAsync("Sucesso!", "Registro Atualizado", "OK");
            // Redireciona o usuário para a página de visualização dos produtos
            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            // Mensagem de erro
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
}