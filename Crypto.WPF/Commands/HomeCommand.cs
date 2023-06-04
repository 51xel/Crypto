using Crypto.WPF.Stores;
using Crypto.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.Commands {
    public class HomeCommand : CommandBase {
        private ModalNavigationStore _modalNavigationStore;

        public HomeCommand(ModalNavigationStore modalNavigationStore){
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter) {
            _modalNavigationStore.CurrentViewModel = new TopCryptoViewModel(_modalNavigationStore);
        }
    }
}
