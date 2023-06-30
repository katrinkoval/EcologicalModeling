using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModelingLib
{
    public struct Coordinate
    {
        const int MAX_X_COORDINATE = 70;
        const int MAX_Y_COORDINATE = 25;

        private int _x;
        private int _y;

        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                if(value < 0 || value >= MAX_X_COORDINATE)
                {
                    _x = 0;
                }
                else
                {
                    _x = value;
                }
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value < 0 || value >= MAX_Y_COORDINATE)
                {
                    _y = 0;
                }
                else
                {
                    _y = value;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate coordinate &&
                   _x == coordinate._x &&
                   _y == coordinate._y;
        }

        public override int GetHashCode()
        {
            return (_x << 16) ^ _y;
        }

        public static bool operator ==(Coordinate a, Coordinate b)
        {
            return (a.X == b.X) && (a.Y == b.Y);
        }

        public static bool operator !=(Coordinate a, Coordinate b)
        {
            return !(a==b);
        }
    }
}
