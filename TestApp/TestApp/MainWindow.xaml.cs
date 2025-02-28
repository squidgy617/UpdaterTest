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
using Velopack;
using Velopack.Sources;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        public async void Update()
        {
            try
            {
                var mgr = new UpdateManager(new GithubSource("https://github.com/squidgy617/UpdaterTest", null, false));

                var newVersion = await mgr.CheckForUpdatesAsync();
                if (newVersion == null)
                {
                    return;
                }

                await mgr.DownloadUpdatesAsync(newVersion);

                mgr.ApplyUpdatesAndRestart(newVersion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
