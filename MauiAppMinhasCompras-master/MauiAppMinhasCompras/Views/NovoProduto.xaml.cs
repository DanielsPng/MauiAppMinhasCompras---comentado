using MauiAppMinhasCompras.Models;  // Importa o namespace contendo o modelo de dados "Produto"

namespace MauiAppMinhasCompras.Views;  // Define o namespace da página "NovoProduto"

public partial class NovoProduto : ContentPage  // Define a classe parcial "NovoProduto" que herda de ContentPage
{
    public NovoProduto()  // Construtor da classe "NovoProduto"
    {
        InitializeComponent();  // Inicializa os componentes visuais da página
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)  // Evento assíncrono chamado quando o item da toolbar é clicado
    {
        try
        {
            // Cria uma nova instância de Produto e preenche suas propriedades com os valores inseridos nos campos de entrada
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,  // Atribui o valor do campo de texto para a descrição do produto
                Quantidade = Convert.ToDouble(txt_quantidade.Text),  // Converte o texto de quantidade para double e atribui à quantidade do produto
                Preco = Convert.ToDouble(txt_preco.Text)  // Converte o texto do preço para double e atribui ao preço do produto
            };

            // Insere o novo produto no banco de dados
            await App.Db.Insert(p);

            // Exibe um alerta informando que o produto foi inserido com sucesso
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

        } catch(Exception ex)  // Captura qualquer exceção que possa ocorrer
        {
            // Exibe um alerta informando que ocorreu um erro, exibindo a mensagem da exceção
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
