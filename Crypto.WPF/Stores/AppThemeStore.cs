using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Crypto.WPF.Stores {
    public enum AppThemeState {
        Dark,
        Light
    }

    public class AppThemeStore {
        private ResourceDictionary _theme;
        private AppThemeState _themeState;
        public AppThemeState Theme {
            get { 
                return _themeState; 
            }
            set {
                _themeState = value;

                SetTheme(_themeState);

                AppThemeChanged?.Invoke();
            }
        }

        public event Action AppThemeChanged;

        private void SetTheme(AppThemeState appThemeState) {
            App.Current.Resources.Clear();

            switch (appThemeState) {
                case AppThemeState.Dark:
                    _theme = new ResourceDictionary {
                        Source = new Uri("Themes/Dark.xaml", UriKind.Relative)
                    };
                    App.Current.Resources.MergedDictionaries.Add(_theme);
                    break;
                case AppThemeState.Light:
                    _theme = new ResourceDictionary {
                        Source = new Uri("Themes/Light.xaml", UriKind.Relative)
                    };
                    App.Current.Resources.MergedDictionaries.Add(_theme);
                    break;
            }
        }
    }
}
