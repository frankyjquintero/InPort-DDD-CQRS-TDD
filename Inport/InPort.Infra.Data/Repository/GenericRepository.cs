using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InPort.Domain.Core.Model;
using InPort.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InPort.Infra.Data.Repository
{
    public abstract class GenericRepository<T> where T : Entity
    {
        protected readonly InPortDbContext Context;
        

        protected GenericRepository(InPortDbContext context)
        {
            Context = context;
        }

        private static IQueryable<T> PrepareQuery(
            IQueryable<T> query,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null
        )
        {

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (take.HasValue)
                query = query.Take(Convert.ToInt32(take));

            return query;
        }

        #region Extras
        public  async Task<decimal?> SumAsync(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await ((IQueryable<decimal?>)query).SumAsync();
        }

        public  decimal? Sum(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return ((IQueryable<decimal?>)query).Sum();
        }

        public  async Task<int> CountAsync(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await query.CountAsync();
        }

        public  int Count(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return query.Count();
        }
        #endregion

        #region Get All
        public  IEnumerable<T> GetAll(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, take);

            return query.ToList();
        }

        public  async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, take);

            return await query.ToListAsync();
        }
        #endregion

    

        #region First
        public  T First(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy);

            return query.First();
        }

        public  async Task<T> FirstAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy);

            return await query.FirstAsync();
        }

        public  T FirstOrDefault(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy);

            return query.FirstOrDefault();
        }

        public  async Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy);

            return await query.FirstOrDefaultAsync();
        }
        #endregion

        #region Single
        public  T Single(
            Expression<Func<T, bool>> predicate
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return query.Single();
        }

        public  async Task<T> SingleAsync(
            Expression<Func<T, bool>> predicate
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await query.SingleAsync();
        }

        public  T SingleOrDefault(
            Expression<Func<T, bool>> predicate
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return query.SingleOrDefault();
        }

        public  async Task<T> SingleOrDefaultAsync(
            Expression<Func<T, bool>> predicate
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await query.SingleOrDefaultAsync();
        }
        #endregion

        #region Add
        public  void Add(T t)
        {
            Context.Add(t);
        }

        public  void Add(IEnumerable<T> t)
        {
            Context.AddRange(t);
        }

        public  async Task AddAsync(T t)
        {
            await Context.AddAsync(t);
        }

        public  async Task AddAsync(IEnumerable<T> t)
        {
            await Context.AddRangeAsync(t);
        }
        #endregion

        #region Remove
        public  void Remove(T t)
        {
            Context.Remove(t);
        }

        public  void Remove(IEnumerable<T> t)
        {
            Context.RemoveRange(t);
        }
        #endregion

        #region Update
        public  void Update(T t)
        {
            Context.Update(t);
        }

        public  void Update(IEnumerable<T> t)
        {
            Context.UpdateRange(t);
        }
        #endregion
    }
}
