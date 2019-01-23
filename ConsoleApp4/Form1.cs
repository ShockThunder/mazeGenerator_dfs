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

        private int Xmin, Ymin, CellWid, CellHgt;

        private void button1_Click(object sender, EventArgs e)
        {
            int wid = int.Parse(txtWidth.Text);
            int hgt = int.Parse(txtHeight.Text);

            //вычисляем ширину одной ячейки, чтобы автомасштабировать полученную картинку
            CellWid = picMaze.ClientSize.Width / (wid + 2);
            CellHgt = picMaze.ClientSize.Height / (hgt + 2);
            if (CellWid > CellHgt) CellWid = CellHgt;
            else CellHgt = CellWid;
            Xmin = (picMaze.ClientSize.Width - wid * CellWid) / 2;
            Ymin = (picMaze.ClientSize.Height - hgt * CellHgt) / 2;


            Maze maze = new Maze(wid, hgt);
            maze.CreateMaze();
            DrawMaze();


            void DrawMaze()
            {

                
                Bitmap bm = new Bitmap(
                    picMaze.ClientSize.Width,
                    picMaze.ClientSize.Height);
                Brush whiteBrush = new SolidBrush(Color.White);
                Brush blackBrush = new SolidBrush(Color.Black);
                
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    for (var i = 0; i < maze._cells.GetUpperBound(0); i++)
                        for (var j = 0; j < maze._cells.GetUpperBound(1); j++)
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

                    gr.FillRectangle(new SolidBrush(Color.Green),                                   //заливаем старт зеленым
                        new Rectangle(new Point(maze.start.X * CellWid, maze.start.Y * CellWid), 
                        new Size(CellWid, CellWid)));
                    gr.FillRectangle(new SolidBrush(Color.Red),                                    //а финиш красным
                        new Rectangle(new Point(maze.finish.X * CellWid, maze.finish.Y * CellWid),
                        new Size(CellWid, CellWid)));
                }

                picMaze.Image = bm; //отображаем картинку

            }
        }
    }
}
