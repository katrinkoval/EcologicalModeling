
namespace EcologicalModelingLib
{
    public class Prey : AliveCell
    {
        const int DEFAULT_TIME_TO_REPRODUCE = 6;
        const Image DEFAULT_IMAGE = Image.Prey;


        public Prey(ICellContainer owner, Coordinate coord, int timeToReproduce = DEFAULT_TIME_TO_REPRODUCE)
            :base(owner, coord, timeToReproduce, DEFAULT_IMAGE)
        {
        }

        public Prey(Prey prey)
            : base(prey._owner, prey.CellCoordinate, prey.TimeToReproduce, DEFAULT_IMAGE)
        {
        }

        public int TimeToReproduce
        {
            get { return _timeToReproduce; }
        }

        public override Cell GetCopy()
        {
            return new Prey(this);
        }

        public override void Process()
        {
            Move(CellCoordinate, GetEmptyNeighborCoordinate());
        }

    }
}
