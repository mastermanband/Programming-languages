using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp_HitTheKeys
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Contains(e.KeyCode)) //Проверка на правильность нажатия.
            {
                listBox1.Items.Remove(e.KeyCode); //удаление буквы из listBox`а
                listBox1.Refresh();
                if (timer1.Interval > 400) timer1.Interval -= 10;
                if (timer1.Interval > 250) timer1.Interval -= 7;
                if (timer1.Interval > 100) timer1.Interval -= 2;
                difficultyProgressBar.Value = 800 - timer1.Interval;//Заполнение ProgressBar`а
                stats.Update(true); //Обновляем статистику.
            }
            else
            {
                stats.Update(false);
            }
            correctLabel.Text = "Correct: " + stats.Correct;
            missedLabel.Text = "Missed " + stats.Missed;
            totalLabel.Text = "Total " + stats.Total;
            accuracyLabel.Text = "Accuracy: " + stats.Accuracy + "%";
        }
    }
}
