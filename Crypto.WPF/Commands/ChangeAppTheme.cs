using Crypto.WPF.Stores;
using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.Commands {
    public class ChangeAppTheme : AsyncCommandBase {
        private AppThemeStore _appThemeStore;

        public ChangeAppTheme(AppThemeStore appThemeStore){
            _appThemeStore = appThemeStore;
        }

        public override async Task ExecuteAsync(object parameter) {
            if (_appThemeStore.Theme == AppThemeState.Dark) {
                _appThemeStore.Theme = AppThemeState.Light;
            }else if (_appThemeStore.Theme == AppThemeState.Light) {
                _appThemeStore.Theme = AppThemeState.Dark;
            }
        }
    }
}
