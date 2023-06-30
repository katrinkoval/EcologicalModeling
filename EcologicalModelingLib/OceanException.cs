using System;

namespace EcologicalModelingLib
{
    public class OceanException: Exception 
    {
        public OceanException()
              : base()
        {

        }

        public OceanException(string message)
           : base(message)
        {

        }

        public OceanException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
