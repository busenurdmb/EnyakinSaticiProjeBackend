

using En_YakınSatıcı.DataAccesLayer.Abstract;
using En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework;
using EnYakınSatıcı.BusinessLayer.Abstract;
using EnYakınSatıcı.BusinessLayer.BusinessAspects.Autofac;
using EnYakınSatıcı.BusinessLayer.Constants;
using EnYakınSatıcı.Core.Utilities.Business;
using EnYakınSatıcı.Core.Utilities.Results;
using EnYakınSatıcı.EntityLayer.Concrete;

namespace EnYakınSatıcı.BusinessLayer.Concrete;
//business katmanı kime bağımlı veri erişime veri erişimde ef ,dapper,nheiber mix olur bağımlılı minimileze ediyoruz
//bapımlılığı constructer injection yapıyoruz
public class CategoryManager : ICategoryService
{
    ICategoryDal _categoyDal;

    public CategoryManager(ICategoryDal categoyDal)
    {
        _categoyDal = categoyDal;
        //bne categorymanager olarak veri erişim katmanına bağımlıyım ama biraz zayıf bağımlılığım var çünkü inetface referans üzerinden bağımmlığım o yüzden sen dataacces katmanında istediğin kadar at koşturabilirsin yeterki kurallarıma uy
    }

    [SecuredOperation("admin")]
    public IResult Add(Category category)
    {
    
        _categoyDal.Add(category);

        // return new Result(true,"ürün eklendi");
        return new SuccessResult(Messages.ProductAdded);
    }

    private IResult[] CheckIfProductCountCategoryCorrect(object categoryID)
    {
        throw new NotImplementedException();
    }
	//[SecuredOperation("admin")]
	public IDataResult<List<Category>> GetAll()
    {
        //iş kodları
        return new SuccessDataResult<List<Category>>(_categoyDal.GetAll());
    }

    public IDataResult<Category> GetById(int categoryid)
    {
        return new SuccessDataResult<Category>(_categoyDal.Get(c=>c.CategoryID == categoryid));
    }
}
