using System;

namespace EcologicalModelingLib
{
    public abstract class OceanFabricaInitializer
    {
        protected readonly ICellContainer _owner;

        public OceanFabricaInitializer(ICellContainer ocean)
        {
            _owner = ocean;
        }

        public abstract Cell GetInitializeCell();

        public Coordinate GetEmptyCellCoordinate()
        {   
            int x, y;
            Random rnd = new Random();
            do
            {
                x  = rnd.Next(0, _owner.NumberOfRows);
                y = rnd.Next(0, _owner.NumberOfColumns);
            } while (!_owner.IsEmpty(x, y));    //TODO: инвариант цикла

            return new Coordinate(x, y);
        
        }
    }
}
