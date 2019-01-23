using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ConsoleApp4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Maze maze = new Maze(40, 20);
            maze.CreateMaze();
            maze.DrawGrid();
            Console.ReadKey();*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
