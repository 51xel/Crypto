using Crypto.WPF.Stores;
using Crypto.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.Commands {
    public class HomeCommand : CommandBase {
        private NavigationStore _navigationStore;
        private AppThemeStore _themeStore;

        public HomeCommand(NavigationStore navigationStore, AppThemeStore themeStore) {
            _navigationStore = navigationStore;
            _themeStore = themeStore;
        }

        public override void Execute(object parameter) {
            _navigationStore.CurrentViewModel = new TopCryptoViewModel(_navigationStore, _themeStore);
        }
    }
}
