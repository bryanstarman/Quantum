
using System.Windows.Input;

namespace Quantum.Vistas;

public partial class Principal : FlyoutPage
{
    public ICommand ToggleFlyoutCommand { get; }

    public Principal()
	{
		InitializeComponent();
      
    }
}