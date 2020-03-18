using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IClinicRepositry
    {
        IEnumerable<Clinic> GetAll();  
        Clinic GetById(int id);  


    }
}
