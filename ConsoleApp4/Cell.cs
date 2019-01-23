using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public struct Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool _isCell { get; set; }
    public bool _isVisited { get; set; }

    public Cell(int x, int y, bool isVisited = false, bool isCell = true)
    {
        X = x;
        Y = y;
        _isCell = isCell;
        _isVisited = isVisited;
    }
}

