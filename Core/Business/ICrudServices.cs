using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;

namespace Core.Business
{
    public interface ICrudServices<T>
    where T : class, IEntity, new()
    {
        IDataResult<List<T>> GetAllService();
        IDataResult<T> GetById(int id);
        IResult AddService(T entity);
        IResult UpdateService(T entity);
        IResult DeleteService(T entity);
    }
}