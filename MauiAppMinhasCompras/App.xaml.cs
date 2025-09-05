using MauiAppMinhasCompras.Helpers;
using System.Globalization;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper _db; //Campo

        public static SQLiteDataBaseHelper Db //Propriedade somente leitura
        {
            get
            {
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"banco_sqlite_compras.db3");

                    _db = new SQLiteDataBaseHelper(path);
                }
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
