using Sat.Recruitment.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Sat.Recruitment.Repository.Inteface

{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        bool Exist(Expression<Func<T, bool>> predicate);

    }
}
