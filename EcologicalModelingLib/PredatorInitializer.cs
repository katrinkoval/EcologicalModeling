using System;

namespace EcologicalModelingLib
{
    public class PredatorInitializer : OceanFabricaInitializer
    {
        public PredatorInitializer(ICellContainer ocean)
              : base(ocean)
        {

        }

        public override Cell GetInitializeCell()
        {
            try
            {
                return new Predator(_owner, GetEmptyCellCoordinate());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
