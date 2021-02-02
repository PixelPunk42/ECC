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

namespace ECC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DeviceContext deviceContext = new DeviceContext();
        private CollectionViewSource deviceViewSource;
        private DeviceRepository deviceRepo;
        public MainWindow()
        {
            InitializeComponent();
            deviceViewSource = (CollectionViewSource)FindResource(nameof(deviceViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs args)
        {
            deviceContext.Database.EnsureCreated();
            if (!deviceContext.Devices.Any())
            {
                DbSeed.Create();
            }
            deviceRepo = new DeviceRepository();

            deviceContext.Devices.Load();
            deviceViewSource.Source = deviceContext.Devices.Local.ToObservableCollection();
            deviceDataGrid.Items.Refresh();
        }

        /// <summary>
        /// Should update the view after adding or deleting entities.
        /// TODO: fix refreshing after delete operation
        /// </summary>
        private void UpdateGrid()
        {
            deviceContext.Devices.Load();
            deviceViewSource.Source = deviceContext.Devices.Local.ToObservableCollection();
            deviceDataGrid.Items.Refresh();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            Device device = (Device)((FrameworkElement)sender).DataContext;
            if (device != null)
            {
                deviceRepo.UpdateDevice(device);
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Device device = (Device)((FrameworkElement)sender).DataContext;
            if (device != null)
            {
                deviceRepo.DeleteDevice(device);
                UpdateGrid();
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            deviceRepo.AddDevice(TBLocation.Text, TBType.Text, TBDeviceHealth.Text, 
                TBLastUsed.Text, TBPrice.Text, TBColor.Text);
            ResetTextBoxes();
            UpdateGrid();
        }

        private void ResetTextBoxes()
        {
            TBLocation.Text = "";
            TBType.Text = "";
            TBDeviceHealth.Text = "";
            TBLastUsed.Text = "";
            TBPrice.Text = "";
            TBColor.Text = "";
        }
    }
}
