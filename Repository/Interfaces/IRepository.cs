using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository
    {
        void Create<T1, T2>(T1 entity) where T1 : class where T2 : class;
        void Delete<T1>(T1 entity) where T1 : class;
        List<T2> GetAll<T1, T2>() where T1 : class where T2 : class;
        T2 GetById<T1, T2>(Guid id) where T1 : class where T2 : class;
        void Update<T1>(T1 entity) where T1 : class;
    }
}