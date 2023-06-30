namespace EcologicalModelingLib
{
    public class Obstacle : Cell
    {
        const Image DEFAULT_IMAGE = Image.Obstacles;

        public Obstacle(ICellContainer owner, Coordinate coord)
            : base(owner, coord, DEFAULT_IMAGE)
        {
        }

        public Obstacle(Obstacle obstacle)
           : base(obstacle._owner, obstacle.CellCoordinate, DEFAULT_IMAGE)
        {
        }

        public override Cell GetCopy()
        {
            return new Obstacle(this);
        }
    }
}
