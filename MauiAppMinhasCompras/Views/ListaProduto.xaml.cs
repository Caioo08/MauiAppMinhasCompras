using System.Collections.ObjectModel;
using Java.Lang;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();
        lst_produtos.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();

            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex) {
            await DisplayAlert("Ops", ex.Message, "OK");
        }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
           
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {

    }

    private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void lst_produtos_Refreshing(object sender, EventArgs e)
    {

    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}