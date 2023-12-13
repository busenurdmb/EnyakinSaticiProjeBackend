
using EnYakınSatıcı.Core.Entities;
using System.Linq.Expressions;

namespace En_YakınSatıcı.Core.Abstract;
//class:referans tip olucak(int falan yazamaz)
//IEntity:gidip farklı bir class yazmasın ya IEntity yada ıentityden implmenet olan bir nesne olabilir
//new():new'lenebilir olmalı eğer bunu yapmasak T yerien IEnity yazılabilrdi
public interface IEntityRepository<T> where T : class,IEntity,new()
{
    List<T> GetAll(Expression<Func<T, bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
