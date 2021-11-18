using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1117.Contravvenzioni
{
    interface IDbManager<T>

    {
        public List<T> GetAll();

        public List<T> GetByVigileId(int id);

        public List<T> GetByVeicoloId(string id);



    
    }
}
