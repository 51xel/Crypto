using Crypto.WPF.Stores;
using Crypto.WPF.ViewModels;
using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Crypto.WPF {
    public partial class App : Application {
        private readonly ModalNavigationStore _modalNavigationStore;

        public App() {
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e) {
            _modalNavigationStore.CurrentViewModel = new TopCryptoViewModel(_modalNavigationStore);

            MainWindow = new MainWindow() {
                DataContext = new MainViewModel(_modalNavigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
