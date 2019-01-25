using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CellWid, CellHgt;

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как...";
            //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
            savedialog.OverwritePrompt = true;
            //отображать ли предупреждение, если пользователь указывает несуществующий путь
            savedialog.CheckPathExists = true;
            //список форматов файла, отображаемый в поле "Тип файла"
            savedialog.Filter = "Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            //отображается ли кнопка "Справка" в диалоговом окне
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
            {
                try
                {
                    picMaze.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {

            //bool checkDim = Int32.TryParse(txtWidth.Text, out int result);
            int wid = 0;
            int hgt = 0;

            //Добавим проверку на корректность введенных размеров
                try
                {
                    wid = int.Parse(txtWidth.Text);
                    hgt = int.Parse(txtHeight.Text);
                }
                catch (System.FormatException)
                {
                    string message = "Размерность должна быть числом, больше 0.";
                    string caption = "Ошибка ввода размерности";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                txtWidth.Text = "10";
                txtHeight.Text = "10";
                return;
                }

            int oddW = 0;
            int oddH = 0;

            //Обрабатываем случай с нечетными размерами
            if (wid % 2 != 0)
            {
                oddW = 1;
            }
            if (hgt % 2 != 0)
            {
                oddH = 1;
            }

            //вычисляем ширину одной ячейки, чтобы автомасштабировать полученную картинку
            CellWid = picMaze.ClientSize.Width / (wid + 2);
            CellHgt = picMaze.ClientSize.Height / (hgt + 2);

            //Установим минимальный размер ячейки, чтобы глаза не выпадывали
            int CellMin = 30;
            if(CellWid < CellMin)
            {
                CellWid = CellMin;
                CellHgt = CellWid;
            }
            else if(CellHgt < CellMin)
            {
                CellHgt = CellMin;
                CellWid = CellHgt;
            }
            else if (CellWid > CellHgt) CellWid = CellHgt;
            else CellHgt = CellWid;


            Maze maze = new Maze(wid, hgt);

            //обрабатываем прорисовку финиша при нечетных размерах
            maze.finish.X = maze.finish.X + oddW;
            maze.finish.Y = maze.finish.Y + oddH;
            maze.CreateMaze();
            DrawMaze();


            void DrawMaze()
            {

                //создаем битмап так, чтобы захватить и финиш и стенку за ним
                Bitmap bm = new Bitmap(
                    CellWid*(maze.finish.X + 2),
                    CellHgt*(maze.finish.Y + 2));

                Brush whiteBrush = new SolidBrush(Color.White);
                Brush blackBrush = new SolidBrush(Color.Black);
                
                using (Graphics gr = Graphics.FromImage(bm))
                {

                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    for (var i = 0; i < maze._cells.GetUpperBound(0) + oddW; i++)
                        for (var j = 0; j < maze._cells.GetUpperBound(1) + oddH; j++)
                        {
                            Point point = new Point(i*CellWid, j*CellWid);
                            Size size = new Size(CellWid, CellWid);
                            Rectangle rec = new Rectangle(point, size);
                            if (maze._cells[i, j]._isCell)
                            {
                                gr.FillRectangle(whiteBrush, rec);
                            }
                            else
                            {

                                gr.FillRectangle(blackBrush, rec);
                            }
                        }

                    gr.FillRectangle(new SolidBrush(Color.Green),    //заливаем старт зеленым
                        new Rectangle(new Point(maze.start.X * CellWid, maze.start.Y * CellWid), 
                        new Size(CellWid, CellWid)));
                    gr.FillRectangle(new SolidBrush(Color.Red),       //а финиш красным
                        new Rectangle(new Point(maze.finish.X * CellWid, maze.finish.Y * CellWid), 
                        new Size(CellWid, CellWid)));
                }

                picMaze.Image = bm; //отображаем картинку

            }
        }
    }
}
