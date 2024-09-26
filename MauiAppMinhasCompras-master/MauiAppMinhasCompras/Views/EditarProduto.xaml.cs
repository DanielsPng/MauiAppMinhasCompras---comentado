using MauiAppMinhasCompras.Models;  // Importa o namespace contendo o modelo de dados "Produto"

namespace MauiAppMinhasCompras.Views;  // Define o namespace da página "EditarProduto"

public partial class EditarProduto : ContentPage  // Define a classe parcial EditarProduto que herda de ContentPage (representa a interface de uma página)
{
    public EditarProduto()  // Construtor da classe EditarProduto
    {
        InitializeComponent();  // Inicializa os componentes visuais da página
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)  // Evento assíncrono que é chamado quando um item de toolbar é clicado
    {
        try
        {
            // Faz o casting do contexto de binding para um objeto do tipo Produto
            Produto produto_anexado = BindingContext as Produto;

            // Cria uma nova instância de Produto, copiando os valores do produto atual e atualizando as propriedades com os novos dados inseridos
            Produto p = new Produto
            {
                Id = produto_anexado.Id,  // Mantém o Id do produto original
                Descricao = txt_descricao.Text,  // Atualiza a descrição com o texto do campo de entrada
                Quantidade = Convert.ToDouble(txt_quantidade.Text),  // Converte o texto da quantidade para um valor numérico e atualiza
                Preco = Convert.ToDouble(txt_preco.Text)  // Converte o texto do preço para um valor numérico e atualiza
            };

            // Atualiza o produto no banco de dados usando o método Update do banco de dados definido no App
            await App.Db.Update(p);

            // Exibe um alerta indicando sucesso na atualização
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");

            // Retorna para a página anterior na pilha de navegação
            await Navigation.PopAsync();
        }
        catch (Exception ex)  // Caso ocorra alguma exceção
        {
            // Exibe um alerta indicando que ocorreu um erro, exibindo a mensagem da exceção
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
