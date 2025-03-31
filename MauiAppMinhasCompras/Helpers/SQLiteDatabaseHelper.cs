using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    /// Classe auxiliar para operações do banco de dados SQLite
    /// Gerencia todas as interações com o banco de dados da aplicação
    public class SQLiteDatabaseHelper
    {
        // Conexão assíncrona com o banco de dados SQLite
        readonly SQLiteAsyncConnection _conn;

        /// Construtor que inicializa a conexão e cria a tabela se não existir
        public SQLiteDatabaseHelper(string path)
        {
            // Inicializa a conexão assíncrona com o banco de dados
            _conn = new SQLiteAsyncConnection(path);
            // Cria a tabela Produto se não existir
            _conn.CreateTableAsync<Produto>().Wait();
        }

        /// Insere um novo produto no banco de dados
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        /// Atualiza um produto existente no banco de dados
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto " +
                "SET Descricao=?,Quantidade=?,Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        /// Remove um produto do banco de dados
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        /// Obtém todos os produtos do banco de dados
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        /// Busca produtos pela descrição
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
