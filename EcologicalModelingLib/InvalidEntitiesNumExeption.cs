using System;

namespace EcologicalModelingLib
{
    public class InvalidEntitiesNumExeption: OceanException
    {
        private float NumOfEntities
        {
            get;
        }

        public InvalidEntitiesNumExeption(int numOfEntities)
             : base()
        {
            NumOfEntities = numOfEntities;
        }

        public InvalidEntitiesNumExeption(string message, int numOfEntities)
           : base(message)
        {
            NumOfEntities = numOfEntities;
        }

        public InvalidEntitiesNumExeption(string message, Exception innerException, int numOfEntities)
            : base(message, innerException)
        {
            NumOfEntities = numOfEntities;
        }

        public override string ToString()
        {
            return Message + " Num of entities = " + NumOfEntities;
        }

    }
}
