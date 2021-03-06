﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_CustomerApi.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        T Get(int id);
        
        IEnumerable<T> GetAll();
        
    }
}
