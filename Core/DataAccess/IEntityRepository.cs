using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint - generic kısıt
    //class : referans tip
    //IEntity : IEntity olabilir ya da IEntity implemente eden bir nesne olabilir
    //new() : new lenebilir olmalı

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //farklı filtreler yazmamızı sağlar. alışveriş sitesi gibi
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);  //default public olduğu için public yazılmaz
        void Update(T entity);
        void Delete(T entity);
    }
}