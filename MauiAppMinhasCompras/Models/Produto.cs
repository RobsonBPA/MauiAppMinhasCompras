using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        String _descricao;
        String _categoria;
        double _quantidade;
        double _preco;

        String msg = "Por favor, preencha";

        // Id
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Descrição/Nome
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception($"{msg} a descrição.");
                }

                _descricao = value;
            }
        }

        // Categoria
        public string Categoria
        {
            get => _categoria;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{msg} a categoria.");
                }

                _categoria = value;
            }
        }

        // Quantidade
        public double Quantidade
        {
            get => _quantidade;
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"{msg} a quantidade.");
                }

            _quantidade = value;
            }
        }

        // Preço
        public double Preco
        {
            get => _preco;
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"{msg} o preço.");
                }
                _preco = value;
            }
        }

        // Total
        public double Total { get => Quantidade * Preco; }
    }
}