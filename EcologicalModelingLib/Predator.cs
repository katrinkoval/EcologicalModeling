
namespace EcologicalModelingLib
{
    public class Predator : AliveCell
    {
        const int DEFAULT_TIME_TO_FEED = 6;
        const int DEFAULT_TIME_TO_REPRODUCE = 6;
        const Image DEFAULT_IMAGE = Image.Predator;

        private int _timeToFeed;

        public Predator(ICellContainer owner, Coordinate coord, int timeToReproduce = DEFAULT_TIME_TO_REPRODUCE, int timeToFeed = DEFAULT_TIME_TO_FEED)
            : base(owner, coord, timeToReproduce, DEFAULT_IMAGE)
        {
            _timeToFeed = timeToFeed;
        }

        public Predator(Predator predator)
            :base(predator._owner, predator.CellCoordinate, predator._timeToReproduce, DEFAULT_IMAGE)
        {

            _timeToFeed = predator._timeToFeed;
        }

        public override Cell GetCopy()
        {
            return new Predator(this);
        }

        public override void Process()
        {
            if(IsTimeToFeed())
            {
                Die();               
            }
            else
            {
                Coordinate toCoord = GetPreyNeighborCoordinate();       //TODO: array Coordinate
                if(toCoord != CellCoordinate)
                {
                    _timeToFeed = DEFAULT_TIME_TO_FEED;
                    Move(CellCoordinate, toCoord);                      //TODO: return bool
                }
                else
                {
                    toCoord = GetEmptyNeighborCoordinate();
                    if (toCoord != CellCoordinate)
                    {
                        Move(CellCoordinate, toCoord);
                    }
                    _timeToFeed--;
                }
            }
        }

        private bool IsTimeToFeed()
        {
            return _timeToFeed <= 0;
        }
    }
}
