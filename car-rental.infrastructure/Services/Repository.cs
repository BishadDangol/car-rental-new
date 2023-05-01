using car_rental.application.Common.Interface;
using car_rental.application.DTOs;
using car_rental.infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.infrastructure.Services
{
    public class Repository<Entity> : IRepository<Entity>  where Entity : class
    {
        private readonly ApplicationDbContext _context;

        private DbSet<Entity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        public virtual void Add(Entity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(Entity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual Entity Get(Guid Id)
        {
            return _dbSet.Find(Id);
        }

        public virtual List<Entity> GetAll()
        {
            IQueryable<Entity> query = _dbSet;

            return query.ToList();
        }

        public Entity GetByString(string Id)
        {
            return _dbSet.Find(Id);

        }
        public Entity GetFirstOrDefault(Expression<Func<Entity, bool>> filter)
        {
            IQueryable<Entity> query = _dbSet;

            query = query.Where(filter);

            return query.FirstOrDefault();
        }
    }
}
