using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace second_application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Вы действительно хотите выйти из приложения ? ", "Внимание!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form PreView = new Preview(MemForImage);
            PreView.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadImage(true);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LoadImage(false);
        }

        Image MemForImage;
        // функция загрузки изображения
        private void LoadImage(bool jpg)
        {
            // директория, которая будет выбрана как начальная в окне для выбора файла
            openFileDialog1.InitialDirectory = "c:";
            // если будем выбирать jpg файлы
            if (jpg)
            {
                openFileDialog1.Filter = "image (JPEG) files (*.jpg)|*.jpg|All files (*.*) | *.* ";
            }
            else
            {
                // устанавливаем формат файлов для загрузки - png
                openFileDialog1.Filter = "image (PNG) files (*.png)|*.png|All files (*.*) | *.* ";
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try // безопасная попытка
                {
                    // пытаемся загрузить файл с именем openFileDialog1.FileName - выбранный пользователем файл.
                    MemForImage = Image.FromFile(openFileDialog1.FileName);
                    // устанавливаем картинку в поле элемента PictureBox
                    pictureBox1.Image = MemForImage;
                }
                catch (Exception ex) // если попытка загрузки не удалась
                {
                    // выводим сообщение с причиной ошибки
                    MessageBox.Show("Не удалось загрузить файл: " + ex.Message);
                }
            }
        }

        private void вФорматеJPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage(true);
        }

        private void вФорматеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage(false);
        }
    }
}
