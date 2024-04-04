using En_YakınSatıcı.DataAccesLayer.Abstract;
using EnYakınSatıcı.BusinessLayer.Abstract;
using EnYakınSatıcı.BusinessLayer.BusinessAspects.Autofac;
using EnYakınSatıcı.BusinessLayer.Constants;
using EnYakınSatıcı.BusinessLayer.ValidationRules.FluentValidation;
using EnYakınSatıcı.Core.Aspect.Autofac.Performance;
using EnYakınSatıcı.Core.Aspect.Autofac.Transaction;
using EnYakınSatıcı.Core.Aspect.Autofac.Validation;
using EnYakınSatıcı.Core.Aspects.Autofac.Caching;
using EnYakınSatıcı.Core.Utilities.Business;
using EnYakınSatıcı.Core.Utilities.Results;
using EnYakınSatıcı.EntityLayer.Concrete;
using EnYakınSatıcı.EntityLayer.DTOs;

namespace EnYakınSatıcı.BusinessLayer.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _productDal;
        //***-> bir entitymanager kendisi hariç başka dalı enjecte edemez
        //neden?
        //kurala yönetim spnraısnda ve diye yeni kurallar getirdi sen bunu 3 5 yerde ıcategorydal enjecte ettin çalıştı ama sen bu kuraı 3 5 yerde kullanıyorsan ek kural geldiğinde napıcaz
        //herkes kendi methodlarını yazar servis dememizin nedeni bir kere yaz //ona ait kuralları oraya koy başkası bunu kullanmak istiyorsa direkt bunu kullansın
        //bir manager içerisinde kendi dalı hariç başka bir dal ınjection yapamayız
        //ama bunun yerine categorydal değilde başka bir servisi ınjecte ediyoruz iş kuralı kıa bile küçük bile olsa
        /// <summary>
        /// /category tablosunu ilgilendiren bir kural olduğu için üründen bağımsız bir kuralı başka bir servisi enjecte ederken bu yöntemi kullanmalıyım
        /// </summary>
        /// <param name="productDal"></param>
        /// <param name="categoryDal"></param>
      // ICategoryDal _categoryDal;->bu yanlış
      ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            
            _categoryService = categoryService;
        }

        //add methodunu ProducVALİADATORU KULLANARAK DOĞRULA DİYOR
        [SecuredOperation("admin,product.add")]
        [ValidationAspect(typeof(ProductValidator))]

        public IResult Add(Product product)
        {
          IResult result=  BusinessRules.Run(CheckIfProductCountCategoryCorrect(product.CategoryID),CheckIfProductNameExists(product.Name),CheckIfCategoryLimitExceded());
            if(result!=null)
            {
                return result;
            }
            //business code
            _productDal.Add(product);

            // return new Result(true,"ürün eklendi");
            return new SuccessResult(Messages.ProductAdded);

        }

       /* [CacheAspect] *///key,value

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 36)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),"ürünler listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p=>p.CategoryID== id)); 
        }

        public IDataResult<List<Product>> GetAllUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }
        //[CacheAspect]
        [PerformanceAspect(1)]
        
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            
            _productDal.Update(product);
            return new SuccessResult();
        }
  
        public IResult Delete(Product product)
        {

            _productDal.Delete(product);
            return new SuccessResult();
        }
        private IResult CheckIfProductCountCategoryCorrect(int CategoryID)
        {
            //bir kategoride en fazla 10 ürün olabilir
            //select count(*) from products where categoryıd=1
            var result = _productDal.GetAll(p => p.CategoryID == CategoryID).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProduntCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            //any varmı
            var result = _productDal.GetAll(p=>p.Name == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameInvalidAlreadyExists);
            }
            return new SuccessResult();
            
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count >= 15) {

                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAllByAdminId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UserId == id));
        }
        [TransactionScopeAspect]
        public IResult AddTransactionanTest(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUptaded);
        }

        //public IDataResult<int> GetCategoryIdByProductId(int productId)
        //{
        //    return new SuccessDataResult<int>(_productDal.Get(x=>x.ProductId==productId).CategoryID);
        //}
    }
}
