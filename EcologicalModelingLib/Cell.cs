
namespace EcologicalModelingLib
{
    public abstract class Cell: ICell
    {
        const Image DEFAULT_IMAGE = Image.EmptyCell;

        private Coordinate _cellCoordinate;
        protected readonly ICellContainer _owner;  
        private Image _image;

        public Cell(ICellContainer owner, Coordinate coord, Image image = DEFAULT_IMAGE)
        {
            _image = image;
            _cellCoordinate = coord;
            _owner = owner;
        }

        public Cell(Cell anotherCell)
            :this(anotherCell._owner, anotherCell._cellCoordinate, anotherCell._image)
        {
        }

        public Coordinate CellCoordinate
        {
            get
            {
                return _cellCoordinate;
            }
            set
            {
                _cellCoordinate = value;
            }
        }

        public abstract Cell GetCopy();

        public Image CellImage
        {   
            get
            {
                return _image;
            }
        }

       
        public Coordinate GetEmptyNeighborCoordinate()
        {
            Coordinate neighbor = CellCoordinate;

            if (GetNorthCell() == null)
            {
                neighbor = GetNorthCellCoordinate();
            }
            else if (GetSouthCell() == null)
            {
                neighbor = GetSouthCellCoordinate();
            }
            else if (GetWestCell() == null)
            {
                neighbor = GetWestCellCoordinate();
            }
            else if (GetEastCell() == null)
            {
                neighbor = GetEastCellCoordinate();
            }

            return neighbor;
        }

        public Coordinate GetPreyNeighborCoordinate()
        {
            return GetNeighborWithImage(Image.Prey).CellCoordinate;
        }

        public ICell GetNeighborWithImage(Image image)
        {
            ICell neighbor = (ICell)this;

            if(GetNorthCell() != null && GetNorthCell().CellImage == image)
            {
                neighbor = GetNorthCell();
            }
            else if(GetSouthCell() != null && GetSouthCell().CellImage == image)
            {
                neighbor = GetSouthCell();
            }
            else if (GetWestCell() != null && GetWestCell().CellImage == image)
            {
                neighbor = GetWestCell();
            }
            else if (GetEastCell() != null && GetEastCell().CellImage == image)
            {
                neighbor = GetEastCell();
            }

            return neighbor;
        }

        public ICell GetNorthCell()      // ^
        {
            return _owner.GetCell(GetNorthCellCoordinate());
        }
        public ICell GetSouthCell()      // v
        {
            return _owner.GetCell(GetSouthCellCoordinate());
        }
        public ICell GetWestCell()       // <
        {
            return _owner.GetCell(GetWestCellCoordinate());
        }

        public ICell GetEastCell()       // >
        {
            return _owner.GetCell(GetEastCellCoordinate());
        }

        public Coordinate GetNorthCellCoordinate()      // ^
        {
            int x = (_cellCoordinate.X > 0) ? (_cellCoordinate.X - 1) : (_cellCoordinate.X);//(_owner.NumberOfRows - 1);
            return new Coordinate(x, _cellCoordinate.Y);
        }

        public Coordinate GetSouthCellCoordinate()      // v
        {
            int x = (_cellCoordinate.X < _owner.NumberOfRows - 1) ? (_cellCoordinate.X + 1) : (_cellCoordinate.X);//: 0;
            return new Coordinate(x, _cellCoordinate.Y);
        }

        public Coordinate GetWestCellCoordinate()       // <
        {
            int y = (_cellCoordinate.Y > 0) ? (_cellCoordinate.Y - 1) : _cellCoordinate.Y;//(_owner.NumberOfColumns - 1);
            return new Coordinate(_cellCoordinate.X, y);
        }

        public Coordinate GetEastCellCoordinate()       // >
        {
            int y = (_cellCoordinate.Y < _owner.NumberOfColumns - 1) ? (_cellCoordinate.Y + 1) : _cellCoordinate.Y;//0;
            return new Coordinate(_cellCoordinate.X, y);
        }

    }
}
