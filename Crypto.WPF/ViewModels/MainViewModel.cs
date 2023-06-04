using Crypto.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels {
    public class MainViewModel : ViewModelBase{
        private readonly ModalNavigationStore _modalNavigationStore;
        public ViewModelBase CurrentViewModel => _modalNavigationStore.CurrentViewModel;

        public MainViewModel(ModalNavigationStore modalNavigationStore) {
            _modalNavigationStore = modalNavigationStore;

            _modalNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged() {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        protected override void Dispose() {
            _modalNavigationStore.CurrentViewModelChanged -= OnCurrentViewModelChanged;

            base.Dispose();
        }
    }
}
