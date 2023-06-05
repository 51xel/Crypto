using CryptoLibrary;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels {
    public class DetailsGraphicViewModel : ViewModelBase {
        private Coin _coin;
        private PlotModel _plotModel;
        public PlotModel PlotModel {
            get {
                return _plotModel;
            }
            set {
                _plotModel = value;
                OnPropertyChanged(nameof(PlotModel));
            }
        }

        public DetailsGraphicViewModel(Coin coin){
            _coin = coin;

            UpdateGraphic();
        }

        private async void UpdateGraphic() {
            var list = await TopCryptoCommands.GetHistory(_coin.Id);

            if (list != null) {
                var prices = new List<decimal>();
                var dates = new List<DateTime>();

                foreach (var element in list) {
                    prices.Add(element.PriceUsd);
                    dates.Add(DateTimeOffset.FromUnixTimeMilliseconds(element.Time).LocalDateTime);
                }

                var lineSeries = new LineSeries { Color = OxyColor.Parse("#3bcfd4") };
                for (var i = 0; i < prices.Count; i++) {
                    var dataPoint = new DataPoint(DateTimeAxis.ToDouble(dates[i]), Convert.ToDouble(prices[i]));
                    lineSeries.Points.Add(dataPoint);
                }

                var model = new PlotModel { 
                    Background = OxyColor.Parse("#283152"),
                    TextColor = OxyColors.White,
                    PlotAreaBorderColor = OxyColors.Transparent,
                    PlotMargins = new OxyThickness(40.0, 0.0, 0.0, 20.0),
                };

                model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, TicklineColor = OxyColors.White });
                model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, TicklineColor = OxyColors.White });
                model.Series.Add(lineSeries);

                PlotModel = model;
            }
        }
    }
}
