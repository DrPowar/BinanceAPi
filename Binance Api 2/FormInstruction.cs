using System;
using System.Drawing;
using System.Windows.Forms;

namespace Binance_Api_2
{
    public partial class FormInstruction : Form
    {
        public FormInstruction()
        {
            InitializeComponent();
        }
        int list = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e) // кнопка яка відповідає за перегортання на наступну сторінку
        {
            if (list < 3)
            {
                list++;
            }
            try
            {
                switch (list)
                {
                    case (0):
                        {
                            pictureBox2.Image = Image.FromFile("D:\\1 Лабараторні\\Курсові\\2 курсова\\Скріншоти до інструкції\\1.png");
                            pictureBox2.Location = new Point(398, 124);
                            pictureBox2.Size = new Size(199, 258);
                            break;
                        }
                    case (1):
                        {
                            pictureBox2.Image = Image.FromFile("D:\\1 Лабараторні\\Курсові\\2 курсова\\Скріншоти до інструкції\\2.png");
                            pictureBox2.Location = new Point(292, 124);
                            pictureBox2.Size = new Size(305, 190);
                            label2.Text = "Якщо ви натиснете на кнопку\nCrypto List, то перед вами з'явиться\nменю доступних криптовалют,\nякщо ви оберете одну з них то\nвас автоматично перекине на\nформу Crypto Info.";
                            break;
                        }
                    case (2):
                        {
                            pictureBox2.Image = Image.FromFile("D:\\1 Лабараторні\\Курсові\\2 курсова\\Скріншоти до інструкції\\3.png");
                            pictureBox2.Location = new Point(275, 150);
                            pictureBox2.Size = new Size(322, 196);
                            label2.Text = "На формі Crypto List\nє декілька основних\nелеменітв, перше це\nназва криптовалюти яку ви\nобрали, друге це ціна\nкриптовалюти та процент\nна скільки вона змінилася\nза останні 24 години, третє\nполе позначає кнопку для\nвиходу з форми.";
                            break;
                        }
                    case (3):
                        {
                            list = 3;
                            pictureBox2.Image = Image.FromFile("D:\\1 Лабараторні\\Курсові\\2 курсова\\Скріншоти до інструкції\\4.png");
                            pictureBox2.Location = new Point(275, 150);
                            pictureBox2.Size = new Size(322, 196);
                            label2.Location = new Point(44, 140);
                            label2.Text = "На формі Trend також\nє декілька елементів,\nперший це назва форми,\nдругий і основний це\nсписок криптовалют які\nвиросли найбільше за\nостанні 24 години, і\nтретій елемент це кнопка\nвийти з форми. Також\nслід знати, що при натисканні\nна кнопку Trend слід\nтрохи зачекати, для того\nщоб сервер надіслав данні.";
                            break;
                        }
                }
            }
            catch 
            {
                string message = "Зображення не знайдено!";
                string caption = "Помилка виведення зображення";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        private void label4_Click(object sender, EventArgs e) // кнопка яка відповідає за повернення на попередню сторінку
        {
            if (list > 0)
            {
                list--;
            }
            switch (list)
            {
                case (0):
                    {
                        pictureBox2.Image = Image.FromFile("D:\\1 Лабараторні\\Курсові\\2 курсова\\Скріншоти до інструкції\\1.png");
                        label2.Text = "Коли ви тільки відкриваєте\nпрограму в ній є 4 основних кнопки:\nCRYPTO LIST, TREND, INSTRUCTION, EXIT.\nКожна з них відкриває окрему форму,\nокрім кнопки EXIT, вона закриває\nпрограму.Щоб дізнатися більш детально\nпро кожну форму натисніть Далі...";
                        pictureBox2.Location = new Point(398, 124);
                        pictureBox2.Size = new Size(199, 258);
                        break;
                    }
                case (1):
                    {
                        pictureBox2.Image = Image.FromFile("D:\\1 Лабараторні\\Курсові\\2 курсова\\Скріншоти до інструкції\\2.png");
                        pictureBox2.Location = new Point(292, 124);
                        pictureBox2.Size = new Size(305, 190);
                        label2.Text = "Якщо ви натиснете на кнопку\nCrypto List, то перед вами з'явиться\nменю доступних криптовалют,\nякщо ви оберете одну з них то\nвас автоматично перекине на\nформу Crypto Info.";
                        break;
                    }
                case (2):
                    {
                        pictureBox2.Image = Image.FromFile("D:\\1 Лабараторні\\Курсові\\2 курсова\\Скріншоти до інструкції\\3.png");
                        pictureBox2.Location = new Point(275, 150);
                        pictureBox2.Size = new Size(322, 196);
                        label2.Text = "На формі Crypto List\nє декілька основних\nелеменітв, перше це\nназва криптовалюти яку ви\nобрали, друге це ціна\nкриптовалюти та процент\nна скільки вона змінилася\nза останні 24 години, третє\nполе позначає кнопку для\nвиходу з форми.";
                        break;
                    }
            }
        }
        private void FormInstruction_Load(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(398, 124);
            pictureBox2.Size = new Size(199, 258);
        }
    }
}
