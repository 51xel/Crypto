using Crypto.WPF.Commands;
using Crypto.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.WPF.ViewModels{
    public class TopCryptoViewModel : ViewModelBase {
        DisplayedCoinsStore DisplayedCoinsStore { get; }

        public TopCryptoListingViewModel TopCryptoListingViewModel { get; }
        public TopCryptoSearchingViewModel TopCryptoSearchingViewModel { get; }

        private AppThemeStore _appThemeStore;
        public AppThemeState Theme {
            get { 
                return _appThemeStore.Theme; 
            }
        }

        public ICommand ChangeAppTheme { get; }

        public TopCryptoViewModel(NavigationStore navigationStore, AppThemeStore appThemeStore) {
            DisplayedCoinsStore = new DisplayedCoinsStore();

            TopCryptoListingViewModel = new TopCryptoListingViewModel(DisplayedCoinsStore, navigationStore, appThemeStore);
            TopCryptoSearchingViewModel = new TopCryptoSearchingViewModel(DisplayedCoinsStore);

            _appThemeStore = appThemeStore;

            _appThemeStore.AppThemeChanged += AppThemeChanged;

            ChangeAppTheme = new ChangeAppTheme(appThemeStore);
        }

        private void AppThemeChanged() {
            OnPropertyChanged(nameof(Theme));
        }

        protected override void Dispose() {
            _appThemeStore.AppThemeChanged -= AppThemeChanged;
        }
    }
}
