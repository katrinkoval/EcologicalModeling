
namespace EcologicalModelingLib
{
    public interface IAlive
    {
        bool IsProcessed { get; set; }

        bool Move(Coordinate from, Coordinate to);

        void Reproduce(Coordinate coord, Cell cell);

        void Die();

        void Process();
    }
}
