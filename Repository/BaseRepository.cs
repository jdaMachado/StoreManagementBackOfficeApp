using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BaseRepository : IRepository
    {
        public AutoMap _mapper;


        public T2 GetById<T1, T2>(Guid id) where T1 : class where T2 : class
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var entity = dbContext.Set<T1>().Find(id);

                    return _mapper.Mapping<T1, T2>(entity);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }


        public List<T2> GetAll<T1, T2>() where T1 : class where T2 : class
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var entities = dbContext.Set<T1>().ToList();
                    var newList = new List<T2>();

                    foreach (var i in entities) {
                        var dto = _mapper.Mapping<T1, T2>(i);
                        newList.Add(dto); 
                    }
                    
                    return newList;

                }
                catch (Exception e)
                {

                    throw;
                }

            }
        }

        public void Create<T1, T2>(T1 dto) where T1 : class where T2 : class
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var entity = _mapper.Mapping<T1, T2>(dto);
                    dbContext.Set<T2>().Add(entity);
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }

            }
        }

        public void Update<T>(T entity) where T : class
        {
            using (var dbContext = new Context())
            {
                try
                {
                    dbContext.Entry(entity).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            using (var dbContext = new Context())
            {
                try
                {
                    dbContext.Set<T>().Remove(entity);
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
    }
}
