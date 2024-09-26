using MauiAppMinhasCompras.Models;  // Importa o namespace que contém o modelo de dados "Produto"
using System.Collections.ObjectModel;  // Importa a classe ObservableCollection para criar uma coleção observável de produtos

namespace MauiAppMinhasCompras.Views;  // Define o namespace da página "ListaProduto"

public partial class ListaProduto : ContentPage  // Define a classe parcial "ListaProduto", que herda de ContentPage (representa uma página de interface)
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();  // Cria uma coleção observável de produtos que será usada como a fonte de dados da lista

    public ListaProduto()  // Construtor da classe ListaProduto
    {
        InitializeComponent();  // Inicializa os componentes visuais da página

        lst_produtos.ItemsSource = lista;  // Define a coleção "lista" como a fonte de dados para o controle de lista "lst_produtos"
    }

    protected async override void OnAppearing()  // Evento chamado quando a página aparece na tela
    {
        try
        {
            lista.Clear();  // Limpa a coleção de produtos para garantir que não haja duplicatas

            List<Produto> tmp = await App.Db.GetAll();  // Busca todos os produtos do banco de dados

            tmp.ForEach(i => lista.Add(i));  // Adiciona cada produto recuperado à coleção observável
        }
        catch (Exception ex)  // Captura qualquer exceção que possa ocorrer
        {
            await DisplayAlert("Ops", ex.Message, "OK");  // Exibe um alerta com a mensagem de erro
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)  // Evento chamado quando o item da toolbar é clicado
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());  // Navega para a página de criação de um novo produto
        }
        catch (Exception ex)  // Captura qualquer exceção que possa ocorrer
        {
            DisplayAlert("Ops", ex.Message, "OK");
