using SQLite;  // Importa a biblioteca SQLite para mapeamento de banco de dados

namespace MauiAppMinhasCompras.Models  // Define o namespace do modelo "Produto"
{
    public class Produto
    {
        string _descricao;  // Campo privado para a descrição do produto

        [PrimaryKey, AutoIncrement]  // Define a chave primária com auto incremento
        public int Id { get; set; }  // Propriedade "Id" que identifica o produto

        // Propriedade "Descricao" com verificação de nulidade
        public string Descricao 
        { 
            get => _descricao;  // Retorna o valor da descrição
            set
            {
                // Se o valor for nulo, lança uma exceção informando que a descrição é obrigatória
                if(value == null) 
                {
                    throw new Exception("Por favor, preencha a descrição");
                }

                _descricao = value;  // Define o valor da descrição
            }
        }

        // Propriedade para armazenar a quantidade do produto
        public double Quantidade {  get; set; }

        // Propriedade para armazenar o preço unitário do produto
        public double Preco {  get; set; }

        // Propriedade "Total" que calcula o total multiplicando a quantidade pelo preço
        public double Total { get => Quantidade * Preco; }
    }
}
