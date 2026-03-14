using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        /* O campo só é atribuído no momento da declaração ou dentro da construção da classe,
        garantindo que a conexão do banco de dados não seja substituída acidentalmente */
        readonly SQLiteAsyncConnection _conn;

        // Inicializa a conexão com o banco de dados e cria a tabela "Produto"
        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait(); // Cria a tabela. O "Wait()" faz o código esperar a criação da tabela
        }

        // Insere um novo produto e retorna o número de linhas afetadas
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        // Atualiza um produto existente com base no ID e retorna uma lista de produtos
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Produto>(
            sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        // Exclui um produto pelo ID e retorna o número de linhas afetadas
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Consulta o banco de dados e retorna uma lista de todos os produtos
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync(); // Equivalente a "SELECT * FROM Produto" em SQL
        }
        
        // Busca por produtos cuja descrição contenha a string "q" e retorna uma lista de produtos correspondentes
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";
            return _conn.QueryAsync<Produto>(sql);
        }
    }
}