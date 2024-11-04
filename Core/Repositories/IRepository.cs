using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntiy, TId> where TEntiy : Entity<TId>, new()
    {
        List<TEntiy> GetAll(Expression<Func<TEntiy, bool>>? filter = null, bool enableAutoInclude = true);
        TEntiy? GetById(TId id);

        TEntiy? Update(TEntiy entity);

        TEntiy? Add(TEntiy entity);

        TEntiy? Remove(TEntiy entity);
    }
}
