using En_YakınSatıcı.Core.Abstract;
using EnYakınSatıcı.EntityLayer.Concrete;
using EnYakınSatıcı.EntityLayer.DTOs;

namespace En_YakınSatıcı.DataAccesLayer.Abstract;

//sen bir entityrepositorysin çalışma tipin productır.
//sen entityrepositoryi product için yapılandırdın demektir.
public interface IProductDal:IEntityRepository<Product>
{
    List<ProductDetailDto> GetProductDetails();
}
