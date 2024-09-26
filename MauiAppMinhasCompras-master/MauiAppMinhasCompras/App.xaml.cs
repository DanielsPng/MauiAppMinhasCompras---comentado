using MauiAppMinhasCompras.Helpers;  // Importa o namespace que contém a classe auxiliar "SQLiteDatabaseHelper"

namespace MauiAppMinhasCompras  // Define o namespace da aplicação
{
    public partial class App : Application  // Define a classe parcial "App" que herda de Application
    {
        static SQLiteDatabaseHelper _db;  // Declara uma variável estática para o banco de dados

        // Propriedade estática para acessar o banco de dados SQLite
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                // Se o banco de dados ainda não foi inicializado, cria uma nova instância
                if(_db == null)
                {
                    // Define o caminho onde o banco de dados será armazenado localmente
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),  // Obtém o diretório de dados de aplicação local
                        "banco_sqlite_compras.db3");  // Nomeia o arquivo do banco de dados

                    // Inicializa o banco de dados com o caminho especificado
                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;  // Retorna a instância do banco de dados
            }
        }

        public App()  // Construtor da classe "App"
        {
            InitializeComponent();  // Inicializa os componentes da aplicação

            // Define a página principal da aplicação
            // MainPage = new AppShell();  // (Comentado) Definiria uma estrutura de navegação baseada em AppShell
            MainPage = new NavigationPage(new Views.ListaProduto());  // Define "ListaProduto" como a página inicial com navegação
        }
    }
}
