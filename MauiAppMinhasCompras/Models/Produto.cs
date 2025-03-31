using SQLite;

namespace MauiAppMinhasCompras.Models
{
    /// Classe de modelo para representar um produto no aplicativo
    public class Produto
    {
        string _descricao;

        // Configuração de chave primária com auto-incremento
        [PrimaryKey, AutoIncrement]

        /// Identificador único do produto
        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception(
                        "Por favor, preencha a descrição");
                }

                _descricao = value;
            }
        }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco; }
    } //Fecha Classe
}//Fecha namespace
