using IMC.Domain.DomainModels;
using IMC.Domain.Interfaces;
using IMC.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IMC.Domain.Repositries
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
