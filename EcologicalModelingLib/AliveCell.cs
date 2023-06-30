using System;

namespace EcologicalModelingLib
{
    public abstract class AliveCell : Cell, IAlive
    {
        protected int _timeToReproduce;
        protected int _defaultTimeToReproduce;
        
        public bool IsProcessed { get; set; }
        

        public AliveCell(ICellContainer owner, Coordinate coord, int timeToReproduce, Image image = Image.EmptyCell) 
                        : base(owner, coord, image)
        {
            _timeToReproduce = timeToReproduce;
            _defaultTimeToReproduce = timeToReproduce;
        }

        public void Die()
        {
            _owner[CellCoordinate] = null;
        }

        public bool Move(Coordinate fromCoord, Coordinate toCoord)
        {
            _timeToReproduce--;

            if (toCoord == fromCoord)
            {
                return false;
            }

           _owner[toCoord] = null;
            if (!_owner.Move(this, toCoord))
            {
                return false;
            }
            
            CellCoordinate = toCoord;

            if (_timeToReproduce <= 0)
            {
                Reproduce(fromCoord, this);
                

                if (_owner.GetCell(fromCoord) is IAlive)                 // if (_cells[j, k] != null && !(_cells[j, k] is Obstacle))
                {
                    ((IAlive)_owner.GetCell(fromCoord)).IsProcessed = true;
                }
            }

            return true;
        }

        abstract public void Process();

        public void Reproduce(Coordinate coord, Cell cell)
        {
            _timeToReproduce = _defaultTimeToReproduce;
            _owner[coord] = cell.GetCopy();
            cell.CellCoordinate = coord;
        }

    }
}
