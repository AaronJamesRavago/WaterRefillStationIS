using System.Data.Entity;
using System.Windows;
using System.Windows.Media;
using Elysium;
using WaterRefillStation.DataLayer;
using System.Linq;

namespace WaterRefillStation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Database.SetInitializer<WaterRefillStationDbContext>(new DbInitializer());
            var dbContext = WaterRefillStation.DataLayer.WaterRefillStationDbContext.DbContext;
            dbContext.Database.Initialize(false);

            var mainwin = new WaterRefillStation.MainWindow();
            var login = new WaterRefillStation.View.LogInView();
            if (login.ShowDialog().Value == true)
            {
                mainwin.Show();
            }

        }

        private void StartupHandler(object sender, System.Windows.StartupEventArgs e)
        {
            this.Apply(Theme.Dark, AccentBrushes.Blue, Brushes.White);
        }
    }
}
