
using EnYakınSatıcı.Core.Utilities.Results;
using EnYakınSatıcı.EntityLayer.Concrete;

namespace EnYakınSatıcı.BusinessLayer.Abstract;

public interface ICategoryService
{
    IDataResult<List<Category>> GetAll();
    IDataResult<Category> GetById(int id);
    IDataResult<Category> GetCategoryByProductId(int id);
    IResult Add(Category category);
}
