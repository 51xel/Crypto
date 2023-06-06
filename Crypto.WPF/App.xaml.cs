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
        private readonly NavigationStore _navigationStore;
        private readonly AppThemeStore _appThemeStore;

        private AppThemeState _startTheme = AppThemeState.Dark;

        public App() {
            _navigationStore = new NavigationStore();
            _appThemeStore = new AppThemeStore();
        }

        protected override void OnStartup(StartupEventArgs e) {
            _navigationStore.CurrentViewModel = new TopCryptoViewModel(_navigationStore, _appThemeStore);

            _appThemeStore.Theme = _startTheme;

            MainWindow = new MainWindow() {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
