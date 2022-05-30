using Sat.Recruitment.Domain;
using Sat.Recruitment.Repository.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository.DAO
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Context _context;
        public Repository(Context context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CreateAsync(IEnumerable<T> entity)
        {
            _context.AddRange(entity);
            var response = await _context.SaveChangesAsync();
            return response;
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }
    }
}
