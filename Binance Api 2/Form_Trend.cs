using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Binance_Api_2
{
    public partial class Form_Trend : Form
    {
        public Form_Trend()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Trend_Load(object sender, EventArgs e) // головна подія яка отримує список криптовалют від сервера та фльтрує його
        {
            try
            {
                using (WebClient w = new WebClient())
                {
                    string[] symbols = new string[10];
                    double[] mas = new double[10] { -100, -100, -100, -100, -100, -100, -100, -100, -100, -100 };
                    var json = w.DownloadString("https://api.binance.com/api/v3/ticker/24hr");
                    var coins = JsonConvert.DeserializeObject<BinanceResponse[]>(json);
                    for (int i = 0; i < coins.Length; i++) // зовнішній цикл який проходить по всьому списку криптовалют
                    {
                        for (int j = 0; j < mas.Length; j++) // внутрішній цикл який проходить по масиву з 10 елементів, та вставляє нові значення
                        {
                            if (coins[i].priceChangePercent > mas[j] && coins[i].symbol.Contains("USDT") && coins[i].priceChangePercent != 0 && !coins[i].symbol.Contains("DOWN"))
                            {
                                mas[j] = coins[i].priceChangePercent;
                                symbols[j] = coins[i].symbol;
                                break;
                            }
                        }
                    }
                    label1.Text = $"1. {symbols[0]}";
                    label12.Text = $"{mas[0].ToString()} %";
                    if (mas[0] > 0) // структура яка відповідає за зміну коліру елементів Label
                    {
                        label1.ForeColor = Color.FromArgb(14, 203, 129);
                        label12.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label1.ForeColor = Color.FromArgb(246, 70, 93);
                        label12.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label2.Text = $"2. {symbols[1]}";
                    label13.Text = $"{mas[1].ToString()} %";
                    if (mas[1] > 0)
                    {
                        label2.ForeColor = Color.FromArgb(14, 203, 129);
                        label13.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label2.ForeColor = Color.FromArgb(246, 70, 93);
                        label13.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label3.Text = $"3. {symbols[2]}";
                    label14.Text = $"{mas[2].ToString()} %";
                    if (mas[2] > 0)
                    {
                        label3.ForeColor = Color.FromArgb(14, 203, 129);
                        label14.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label3.ForeColor = Color.FromArgb(246, 70, 93);
                        label14.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label4.Text = $"4. {symbols[3]}";
                    label15.Text = $"{mas[3].ToString()} %";
                    if (mas[3] > 0)
                    {
                        label4.ForeColor = Color.FromArgb(14, 203, 129);
                        label15.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label4.ForeColor = Color.FromArgb(246, 70, 93);
                        label15.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label5.Text = $"5. {symbols[4]}";
                    label16.Text = $"{mas[4].ToString()} %";
                    if (mas[4] > 0)
                    {
                        label5.ForeColor = Color.FromArgb(14, 203, 129);
                        label16.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label5.ForeColor = Color.FromArgb(246, 70, 93);
                        label16.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label6.Text = $"6. {symbols[5]}";
                    label17.Text = $"{mas[5].ToString()} %";
                    if (mas[5] > 0)
                    {
                        label6.ForeColor = Color.FromArgb(14, 203, 129);
                        label17.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label6.ForeColor = Color.FromArgb(246, 70, 93);
                        label17.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label7.Text = $"7. {symbols[6]}";
                    label18.Text = $"{mas[6].ToString()} %";
                    if (mas[6] > 0)
                    {
                        label7.ForeColor = Color.FromArgb(14, 203, 129);
                        label18.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label7.ForeColor = Color.FromArgb(246, 70, 93);
                        label18.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label8.Text = $"8. {symbols[7]}";
                    label19.Text = $"{mas[7].ToString()} %";
                    if (mas[7] > 0)
                    {
                        label8.ForeColor = Color.FromArgb(14, 203, 129);
                        label19.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label8.ForeColor = Color.FromArgb(246, 70, 93);
                        label19.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label9.Text = $"9. {symbols[8]}";
                    label20.Text = $"{mas[8].ToString()} %";
                    if (mas[8] > 0)
                    {
                        label9.ForeColor = Color.FromArgb(14, 203, 129);
                        label20.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label9.ForeColor = Color.FromArgb(246, 70, 93);
                        label20.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                    label10.Text = $"10. {symbols[9]}";
                    label21.Text = $"{mas[9].ToString()} %";
                    if (mas[9] > 0)
                    {
                        label10.ForeColor = Color.FromArgb(14, 203, 129);
                        label21.ForeColor = Color.FromArgb(14, 203, 129);
                    }
                    else
                    {
                        label10.ForeColor = Color.FromArgb(246, 70, 93);
                        label21.ForeColor = Color.FromArgb(246, 70, 93);
                    }
                }
            }
            catch (Exception)
            {
                string message = "Дані не отримані!";
                string caption = "Помилка сервера";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            } // обробка виключення у випадку коли дані не отримані
            
        }
    }
}
