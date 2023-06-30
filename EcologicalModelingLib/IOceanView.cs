using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModelingLib
{
    public interface IOceanView
    {
        Cell this[Coordinate coord] { set; }   

        Cell this[int x, int y] { set; }

        ICell GetCell(int x, int y);

        ICell GetCell(Coordinate coord);

        int NumberOfRows { get; }

        int NumberOfColumns { get; }

        bool IsEmpty(Coordinate coord);

        bool IsEmpty(int x, int y);
    }
}
