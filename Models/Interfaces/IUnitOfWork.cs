using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IUnitOfWork<out TContext>
        where TContext : DbContext, new()
    {
        TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
