
namespace EcologicalModelingLib
{
    public class OceanInitializer
    {
        const int DEFAULT_NUM_OF_PREY = 2;
        const int DEFAULT_NUM_OF_PREDATORS = 1;
        const int DEFAULT_NUM_OF_OBSTACLES = 2;

        protected int _numOfPreys;
        protected int _numOfObstacles;
        protected int _numOfPredators;
        protected Ocean _ocean;

        public OceanInitializer(Ocean ocean, int numPreys = DEFAULT_NUM_OF_PREY
            , int numPredators = DEFAULT_NUM_OF_PREDATORS, int numObstacles = DEFAULT_NUM_OF_OBSTACLES)
        {
            if(IsValidValue(ocean, numPreys, numObstacles, numPredators))
            {
                _ocean = ocean;
                _numOfPreys = numPreys;
                _numOfObstacles = numObstacles;
                _numOfPredators = numPredators;
            }
            else
            {
                throw new InvalidEntitiesNumExeption("Invalid number of entities"
                        , numObstacles + numPredators + numPreys);
            }
        }

        public void InitializeOcean()
        {
            AddEntities(_ocean, _numOfPreys, new PreyInitializer(_ocean));
            AddEntities(_ocean, _numOfPredators, new PredatorInitializer(_ocean));
            AddEntities(_ocean, _numOfObstacles, new ObstacleInitializer(_ocean));
        }

        private bool IsValidValue(Ocean ocean, int numPreys, int numPredators, int numObstacles)
        {
            return (numObstacles + numPredators + numPreys) < (ocean.NumberOfColumns * ocean.NumberOfRows);
        }

        static public void AddEntities(ICellContainer owner, int num, OceanFabricaInitializer oceanInitializer)
        {
            for (int i = 0; i < num; i++)
            {
                Cell newEntity = oceanInitializer.GetInitializeCell();
                owner[newEntity.CellCoordinate] = newEntity;
            }
        }
    }
}
