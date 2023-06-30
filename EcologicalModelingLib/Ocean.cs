
namespace EcologicalModelingLib
{
    public class Ocean : ICellContainer, IOceanView
    {
        const int DEFAULT_NUM_OF_ROWS = 4;
        const int DEFAULT_NUM_OF_COLS = 4;

        private readonly Cell[,] _cells;

        public Ocean()
            : this(DEFAULT_NUM_OF_ROWS, DEFAULT_NUM_OF_COLS)
        {

        }

        public Ocean(int numOfRows, int numOfColumns)
        {
            _cells = new Cell[numOfRows, numOfColumns];
            AddEmptyCells();
        }

        public Ocean(Ocean anotherOcean)
        {
            _cells = new Cell[anotherOcean.NumberOfRows, anotherOcean.NumberOfColumns];

            for (int i = 0; i < _cells.GetLength(1); i++)
            {
                for (int j = 0; j < _cells.GetLength(0); j++)
                {
                    _cells[i, j] = anotherOcean._cells[i, j].GetCopy();
                }
            }
        }
        public int NumberOfColumns
        {
            get
            {
                return _cells.GetLength(1);
            }
        }

        public int NumberOfRows
        {
            get
            {
                return _cells.GetLength(0);
            }
        }

        public Cell this [Coordinate coord]
        {
            set
            {
                _cells[coord.X, coord.Y] = value;
            }
        }

        public Cell this[int x, int y]
        {
            set
            {
                _cells[x, y] = value;
            }
        }

        public ICell GetCell(Coordinate coord)
        {
            return GetCell(coord.X, coord.Y);
        }

        public ICell GetCell(int x, int y)
        {
            return (ICell)_cells[x, y];
        }

        public bool IsEmpty(Coordinate coord)
        {
            bool result = false;

            if(_cells[coord.X, coord.Y] == null)
            {
                result = true;
            }

            return result;
        }

        public bool IsEmpty(int x, int y)
        {
            bool result = false;

            if (_cells[x, y] == null)
            {
                result = true;
            }

            return result;
        }

        private void AddEmptyCells()
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                   _cells[i, j] = null;
                }
            }
        }


        public bool HasEmptyCell()
        {           
            for (int i = 0; i < _cells.GetLength(1); i++)
            {
                for (int j = 0; j < _cells.GetLength(0); j++)
                {
                    if(_cells[i, j] == null || IsEmpty(_cells[i, j].CellCoordinate))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Move(Cell cell, Coordinate coord)
        {
            bool result = false;

            if (IsEmpty(coord))
            {
                this[cell.CellCoordinate] = null;
                cell.CellCoordinate = coord;
                _cells[coord.X, coord.Y] = cell;
                if (_cells[coord.X, coord.Y] is IAlive)                 // if (_cells[j, k] != null && !(_cells[j, k] is Obstacle))
                {
                    ((IAlive)_cells[coord.X, coord.Y]).IsProcessed = true;
                }
                result = true;
            }

            return result;

        }

        public void Run()
        {
            UnProcessedCells();
            for (int j = 0; j < NumberOfRows; j++)
            {
                 for (int k = 0; k < NumberOfColumns; k++)
                 {
                    if (_cells[j, k] is IAlive && !((IAlive)_cells[j, k]).IsProcessed)                 // if (_cells[j, k] != null && !(_cells[j, k] is Obstacle))
                    {
                        ((IAlive)_cells[j, k]).Process();
                    }

                    //((IAlive)_cells[j, k])?.Process();
                }                        
            }
        }

        private void UnProcessedCells()
        {
            for (int j = 0; j < NumberOfRows; j++)
            {
                for (int k = 0; k < NumberOfColumns; k++)
                {
                    if (_cells[j, k] != null && _cells[j, k] is IAlive)
                    {
                        ((IAlive)_cells[j, k]).IsProcessed = false;
                    }
                }
            }
        }

    }
}
