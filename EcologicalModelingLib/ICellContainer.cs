
namespace EcologicalModelingLib
{
    public interface ICellContainer : IOceanView
    {
        bool Move(Cell cell, Coordinate coord);

        bool HasEmptyCell();

    }
}
