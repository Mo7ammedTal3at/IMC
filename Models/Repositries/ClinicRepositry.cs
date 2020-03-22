using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositries
{
    public class ClinicRepositry : GenericRepository<Clinic>, IClinicRepositry
    {
        public ClinicRepositry(IUnitOfWork<IMCDbContext> unitOfWork)
: base(unitOfWork)
        {
        }
        public ClinicRepositry(IMCDbContext context)
        : base(context)
        {
        }


    }
}
