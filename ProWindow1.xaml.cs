using EF_SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProAppModule2
{
    /// <summary>
    /// Interaction logic for ProWindow1.xaml
    /// </summary>
    public partial class ProWindow1 : ArcGIS.Desktop.Framework.Controls.ProWindow
    {
        public ProWindow1()
        {
            InitializeComponent();

            using (var context = new EF_SQL.Models.GeodataContext())
            {
                Parcel parcel =   context.Parcels.FirstOrDefault();
                parcelId.Text = parcel.Parcelname;
            }
        }

        private void updateparcel(object sender, RoutedEventArgs e)
        {
            using (var context = new EF_SQL.Models.GeodataContext())
            {
                List<Parcel> parcels = context.Parcels.Where(x => x.Parcelname != "Monkey").ToList();
                parcelId.Text = parcels.Last().Parcelname;
            }
        }

    }
}
