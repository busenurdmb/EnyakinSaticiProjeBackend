

using En_YakınSatıcı.DataAccesLayer.Abstract;
using EnYakınSatıcı.Core.DataAcces.EntityFramework;
using EnYakınSatıcı.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework;

public class EfCategoryDal :EfEntityRepositoryBase<Category,EnYakınSatıcıContext>,ICategoryDal
{
  
}
