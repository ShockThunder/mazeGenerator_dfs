using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ConsoleApp4
{
    class Maze
    {
        public readonly Cell[,] _cells;
        public int _width;
        public int _height;
        public Stack<Cell> _path = new Stack<Cell>();
        public List<Cell> _solve = new List<Cell>();
        public List<Cell> _visited = new List<Cell>();
        public List<Cell> _neighbours = new List<Cell>();
        public Random rnd = new Random();
        public Cell start;
        public Cell finish;

        public Maze(int width, int height)
        {
            start = new Cell(1, 1, true, true);
            finish = new Cell(width - 3, height - 3, true, true);


            _width = width;
            _height = height;
            _cells = new Cell[width, height];
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    if ((i % 2 != 0 && j % 2 != 0) && (i < _width - 1 && j < _height - 1)) //если ячейка нечетная по х и по у и не выходит за пределы лабиринта
                    {
                        _cells[i, j] = new Cell(i, j); //то это клетка (по умолчанию)
                    }
                    else
                    {

                        _cells[i, j] = new Cell(i, j, false, false);
                    }
            _path.Push(start);
            _cells[start.X, start.Y] = start;
        }

        public void SolveMaze()
        {
            bool flag = false; //флаг достижения финиша
            foreach (Cell c in _cells)
            {
                if (_cells[c.X, c.Y]._isCell == true)
                {
                    _cells[c.X, c.Y]._isVisited = false;
                }
            }

            _path.Clear();
            _path.Push(start);

            while (_path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                if (_path.Peek().X == finish.X && _path.Peek().Y == finish.Y)
                {
                    flag = true;
                }

                if (!flag)
                {
                    _neighbours.Clear();
                    GetNeighboursSolve(_path.Peek());
                    if (_neighbours.Count != 0)
                    {
                        Cell nextCell = ChooseNeighbour(_neighbours);
                        nextCell._isVisited = true; //делаем текущую клетку посещенной
                        _cells[nextCell.X, nextCell.Y]._isVisited = true; //и в общем массиве
                        _path.Push(nextCell); //затем добавляем её в стек
                        _visited.Add(_path.Peek());
                    }
                    else
                    {
                        _path.Pop();
                    }
                }
                else
                {
                    _solve.Add(_path.Peek());
                    _path.Pop();
                }
            }
        }


        public void CreateMaze()
        {
            _cells[start.X, start.Y] = start;
            while (_path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                _neighbours.Clear();
                GetNeighbours(_path.Peek());
                if (_neighbours.Count != 0)
                {
                    Cell nextCell = ChooseNeighbour(_neighbours);
                    RemoveWall(_path.Peek(), nextCell);
                    nextCell._isVisited = true; //делаем текущую клетку посещенной
                    _cells[nextCell.X, nextCell.Y]._isVisited = true; //и в общем массиве
                    _path.Push(nextCell); //затем добавляем её в стек

                }
                else
                {
                    _path.Pop();
                }

            }
        }

        public void DrawGrid()
        {
            Console.CursorVisible = false;
            for (var i = 0; i < _cells.GetUpperBound(0); i++)
                for (var j = 0; j < _cells.GetUpperBound(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    if (_cells[i, j]._isCell)
                    {

                        Console.Write(" ");
                    }
                    else
                    {

                        Console.Write("#");
                    }
                }
            Console.SetCursorPosition(start.X, start.Y);
            Console.Write("i");
            Console.SetCursorPosition(finish.X, finish.Y);
            Console.Write("o");
        }


        private void GetNeighbours(Cell localcell) // Получаем соседа текущей клетки
        {

            int x = localcell.X;
            int y = localcell.Y;
            const int distance = 2;
            Cell[] possibleNeighbours = new[] // Список всех возможных соседeй
            {
                new Cell(x, y - distance), // Up
                new Cell(x + distance, y), // Right
                new Cell(x, y + distance), // Down
                new Cell(x - distance, y) // Left
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                Cell curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < _width && curNeighbour.Y > 0 && curNeighbour.Y < _height)
                {// Если сосед не выходит за стенки лабиринта
                    if (_cells[curNeighbour.X, curNeighbour.Y]._isCell && !_cells[curNeighbour.X, curNeighbour.Y]._isVisited)
                    { // А также является клеткой и непосещен
                        _neighbours.Add(curNeighbour);
                    }// добавляем соседа в Лист соседей
                }
            }

        }

        private void GetNeighboursSolve(Cell localcell) // Получаем соседа текущей клетки
        {

            int x = localcell.X;
            int y = localcell.Y;
            const int distance = 1;
            Cell[] possibleNeighbours = new[] // Список всех возможных соседeй
            {
                new Cell(x, y - distance), // Up
                new Cell(x + distance, y), // Right
                new Cell(x, y + distance), // Down
                new Cell(x - distance, y) // Left
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                Cell curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < _width && curNeighbour.Y > 0 && curNeighbour.Y < _height)
                {// Если сосед не выходит за стенки лабиринта
                    if (_cells[curNeighbour.X, curNeighbour.Y]._isCell && !_cells[curNeighbour.X, curNeighbour.Y]._isVisited)
                    { // А также является клеткой и непосещен
                        _neighbours.Add(curNeighbour);
                    }// добавляем соседа в Лист соседей
                }
            }

        }

        private Cell ChooseNeighbour(List<Cell> neighbours) //выбор случайного соседа
        {

            int r = rnd.Next(neighbours.Count);
            return neighbours[r];

        }

        private void RemoveWall(Cell first, Cell second)
        {
            int xDiff = second.X - first.X;
            int yDiff = second.Y - first.Y;
            int addX = (xDiff != 0) ? xDiff / Math.Abs(xDiff) : 0; // Узнаем направление удаления стены
            int addY = (yDiff != 0) ? yDiff / Math.Abs(yDiff) : 0;

            // Координаты удаленной стены
            _cells[first.X + addX, first.Y + addY]._isCell = true; //обращаем стену в клетку
            _cells[first.X + addX, first.Y + addY]._isVisited = true; //и делаем ее посещенной
            second._isVisited = true; //делаем клетку посещенной
            _cells[second.X, second.Y] = second;

        }
    }
}
