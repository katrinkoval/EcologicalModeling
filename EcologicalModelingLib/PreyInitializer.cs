using System;

namespace EcologicalModelingLib
{
    public class PreyInitializer : OceanFabricaInitializer
    {
        public PreyInitializer(ICellContainer ocean)
            : base(ocean)
        { 

        }

        public override Cell GetInitializeCell()
        {
            try
            {
                return new Prey(_owner, GetEmptyCellCoordinate());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
