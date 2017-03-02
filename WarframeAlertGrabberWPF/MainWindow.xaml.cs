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
using WarframeAlertGrabberWPF.Data.Repositories;
using WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs;

namespace WarframeAlertGrabberWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lblName.Content = "Warframe Alert Grabber";

            WarframeRepository WarRepo = new WarframeRepository();
            //richTextBox1.Text = WarRepo.getAllAlerts().ToString();

            List<WarframeItemDTO> loop = WarRepo.getAllAlerts();

            foreach (WarframeItemDTO temp in loop)
            {
                txtDisplay.Text += temp.ToString();
                txtDisplay.Text += "\n \n";
            }
        }

    }
}
