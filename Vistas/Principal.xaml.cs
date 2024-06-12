
using System.Windows.Input;

namespace Quantum.Vistas;

public partial class Principal : FlyoutPage
{
    public ICommand ToggleFlyoutCommand { get; }

    public Principal()
	{
		InitializeComponent();
        menuFlyout.collectionView.SelectionChanged += CollectionView_SelectionChanged;
        ToggleFlyoutCommand = new Command(() =>
        {
            try
            {
                IsPresented = !IsPresented;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error toggling flyout: {ex.Message}");
            }
        });
        BindingContext = this;

    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as Modelo.MenuFlyoutItem;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            IsPresented = false;
        }
    }

    private void OnMenuButtonClicked(object sender, EventArgs e)
    {

    }
}