using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace Binance_Api_2
{
    public partial class CryptoInfo : Form
    {
        private double price_ticker = 0;
        private double temp_price_ticker = 0;
        private string symbol_name = " ";
        private double change_percent = 0;

        public CryptoInfo()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int tick = 1;
        private async void timer1_Tick(object sender, EventArgs e) //таймер для постійного онвлення даних
        {
            if (tick % 3 == 0 || tick == 2)
            {
                try // головна структура даної форми, вона створює запит для API після чого отримує відповідь та виводить дані на форму
                {
                    await Task.Run(() =>
                    {
                        BinanceResponseMainFunction(symbol_name, "https://api.binance.com/api/v3/ticker/price?symbol=",
                            "https://api.binance.com/api/v3/ticker/24hr?symbol=", label2, label1,
                            label3, label4, label7);
                    });
                    price_ticker = Convert.ToDouble(label1.Text);
                    change_percent = Convert.ToDouble(label3.Text);
                    label3.Text = change_percent.ToString() + " %";
                }
                catch // обробка виключення у випадку якщо дані від сереверу не отримані
                {
                    timer1.Enabled = false;
                    string message = "Дані не отримані!";
                    string caption = "Помилка сервера";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }

            label1.ForeColor = ColorChanger(temp_price_ticker, price_ticker);
            label3.ForeColor = ColorChanger(change_percent);
            temp_price_ticker = price_ticker;
            tick++;
        }

        private Color ColorChanger(double temp_price_ticker, double price_tickert)
        {
            if (price_ticker > temp_price_ticker)
            {
                return Color.FromArgb(14, 203, 129);

            }
            else if (price_ticker < temp_price_ticker)
            {
                return Color.FromArgb(246, 70, 93);
            }
            else
            {
                return Color.FromArgb(234, 236, 239);
            }
        }

        private Color ColorChanger(double change_percent)
        {
            if (change_percent > 0)
            {
                return Color.FromArgb(14, 203, 129);
            }
            else
            {
                return Color.FromArgb(246, 70, 93);
            }
        }

        private void BinanceResponseMainFunction(string symbol_name, string source_price_url,
            string source_priceChange_url, Label name, Label price, Label priceChangePercent,
            Label volume, Label weightedAvgPrice)
        {
            BinanceResponse PriceBinanceResponse = new BinanceResponse();
            BinanceResponse PriceChangeBinanceResponse = new BinanceResponse();

            symbol_name = Form1.symbol_name;
            var PriceRequest = new GetHttpAPIResponse(source_price_url + symbol_name);
            var PriceChangePercentRequest = new GetHttpAPIResponse(source_priceChange_url + symbol_name);
            PriceRequest.Run();
            PriceChangePercentRequest.Run();
            PriceBinanceResponse = JsonConvert.DeserializeObject<BinanceResponse>(PriceRequest.Response);
            PriceChangeBinanceResponse = JsonConvert.DeserializeObject<BinanceResponse>(PriceChangePercentRequest.Response);

            if (name.InvokeRequired)
            {
                name.Invoke(new MethodInvoker(delegate
                {
                    name.Text = symbol_name;
                }));
            }
            else
            {
                name.Text = symbol_name;
            }

            if (price.InvokeRequired)
            {
                price.Invoke(new MethodInvoker(delegate
                {
                    price.Text = PriceBinanceResponse.price.ToString();
                }));
            }
            else
            {
                price.Text = PriceBinanceResponse.price.ToString();
            }

            if (priceChangePercent.InvokeRequired)
            {
                priceChangePercent.Invoke(new MethodInvoker(delegate
                {
                    priceChangePercent.Text = PriceChangeBinanceResponse.priceChangePercent.ToString();
                }));
            }
            else
            {
                priceChangePercent.Text = PriceChangeBinanceResponse.priceChangePercent.ToString();
            }

            if (volume.InvokeRequired)
            {
                volume.Invoke(new MethodInvoker(delegate
                {
                    volume.Text = Math.Round(PriceChangeBinanceResponse.volume, 2).ToString();
                }));
            }
            else
            {
                volume.Text = Math.Round(PriceChangeBinanceResponse.volume, 2).ToString();
            }

            if (weightedAvgPrice.InvokeRequired)
            {
                weightedAvgPrice.Invoke(new MethodInvoker(delegate
                {
                    weightedAvgPrice.Text = Math.Round(PriceChangeBinanceResponse.weightedAvgPrice, 2).ToString();
                }));
            }
            else
            {
                weightedAvgPrice.Text = Math.Round(PriceChangeBinanceResponse.weightedAvgPrice, 2).ToString();
            }
        }
    }
}
