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

namespace Crypto.WPF.Views {
    /// <summary>
    /// Interaction logic for TopCryptoView.xaml
    /// </summary>
    public partial class TopCryptoView : UserControl {
        private class Pl {
            public string Name { get; set; }
            public int Price { get; set; }
        }
        public TopCryptoView() {
            InitializeComponent();

            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
            test.List.Items.Add(new Pl {Name = "Bitcoin", Price = 2165465 });
        }
    }
}
