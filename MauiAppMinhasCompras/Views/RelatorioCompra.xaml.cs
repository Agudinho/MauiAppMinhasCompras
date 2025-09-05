namespace MauiAppMinhasCompras.Views { 

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
      await CarregarRelatorioAsync();
    }

    private async Task CarregarRelatorioAsync()
    {
        var produtos = await App.Db.GetAll();

        var relatorio = produtos
                .GroupBy(p => p.Categoria ?? "Outros")
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Sum(p => p.Total)
                })
                .ToList();

            listaRelatorio.ItemsSource = relatorio;
    }
}

}