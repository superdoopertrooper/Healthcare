﻿using Hospital.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data
{
    class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        internal DbContext _dbContext;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = dBContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindByKey(Expression<Func<TEntity,bool> > predicate)
        {
            IEnumerable<TEntity> results = _dbSet.AsNoTracking().Where(predicate).ToList();
            return results;
        }

        public void DBLOg()
        {
             _dbContext.Database.Log("");
        }

        
    }
}
