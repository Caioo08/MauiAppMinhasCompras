using System.Globalization;
using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;
        /// Propriedade estática para acesso ao banco de dados
        /// Implementa o padrão Singleton garantindo uma única instância do banco
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    // Define o caminho do arquivo do banco de dados SQLite
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                    // Inicializa o helper do banco de dados com o caminho definido
                    _db = new SQLiteDatabaseHelper(path);                            
                }
                return _db;
            }
        }

        public App()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            // Define a página inicial como ListaProduto dentro de uma NavigationPage
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
