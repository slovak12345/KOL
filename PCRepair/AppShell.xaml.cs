using PCRepair.Views;
using Xamarin.Forms;

namespace PCRepair
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MyRequestEntryPage), typeof(MyRequestEntryPage));
        }
    }
}