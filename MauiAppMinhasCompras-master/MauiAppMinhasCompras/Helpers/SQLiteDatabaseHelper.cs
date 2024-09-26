using MauiAppMinhasCompras.Models;  // Importa o namespace do modelo "Produto"
using SQLite;  // Importa a biblioteca SQLite para interações com o banco de dados

namespace MauiAppMinhasCompras.Helpers  // Define o namespace para o helper do banco de dados
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;  // Conexão assíncrona com o banco de dados

        // Construtor que inicializa a conexão e cria a tabela "Produto"
        public SQLiteDatabaseHelper(string path) 
        { 
            _conn = new SQLiteAsyncConnection(path);  // Inicializa a conexão com o banco de dados
            _conn.CreateTableAsync<Produto>().Wait();  // Cria a tabela para a classe "Produto"
        }

        // Método para inserir um novo produto no banco de dados
        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);  // Insere o produto de forma assíncrona
        }

        // Método para atualizar um produto existente
        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";  // Comando SQL para atualização

            return _conn.QueryAsync<Produto>(  // Executa o comando de atualização
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        // Método para deletar um produto pelo ID
        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);  // Deleta o produto de forma assíncrona
        }

        // Método para obter todos os produtos do banco de dados
        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();  // Retorna a lista de produtos de forma assíncrona
        }

        // Método para buscar produtos pelo nome
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";  // Comando SQL para busca

            return _conn.QueryAsync<Produto>(sql);  // Executa a busca e retorna os produtos encontrados
        }
    }
}
