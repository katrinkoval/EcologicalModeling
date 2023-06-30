
namespace EcologicalModelingLib
{
    public class ObstacleInitializer: OceanFabricaInitializer
    {
        public ObstacleInitializer(ICellContainer ocean)
              : base(ocean)
        {

        }

        public override Cell GetInitializeCell()
        {
            return new Obstacle(_owner, GetEmptyCellCoordinate());
            
        }
    }
}
