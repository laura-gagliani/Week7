using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Day1118.NumeriComplessi
{
    class NumeroComplessoException : Exception
    {
        //posso mettere degli attributi

        public NumeroComplesso Dividendo { get; set; }
        public NumeroComplesso Divisore { get; set; }


        //possiamo implementare 4 costruttori

        public NumeroComplessoException()
        {

        }

        public NumeroComplessoException(string messaggio) : base(messaggio)
        {

        }

        public NumeroComplessoException(string messaggio, Exception innerException) :base (messaggio, innerException)
        {

        }

        protected NumeroComplessoException(SerializationInfo info, StreamingContext context ) :base (info, context)
        {

        }
        
    }
}
