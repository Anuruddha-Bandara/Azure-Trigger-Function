﻿using HttpTriggerFun.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HttpTriggerFun.Services.Interfaces
{
    public interface IService<T> where T : class, IEntity
    {
        public Task<T> GetById(string id);

        public Task<IEnumerable<T>> GetAll();

        public Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);

        public Task<T> Create(T entity);

        public Task<T> Update(T entity);

        public Task Delete(string id);
    }
}
