

using En_YakınSatıcı.DataAccesLayer.Abstract;
using EnYakınSatıcı.Core.DataAcces.EntityFramework;
using EnYakınSatıcı.EntityLayer.Concrete;
using EnYakınSatıcı.EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, EnYakınSatıcıContext>, IProductDal
{
    //IProductDal a diyorki merak etme az iöce kızdığın bütün operasyonlar şu arkadaşın içinde var zaten bende ondan inherit ediyorum dolayısıyla EfEntityRepository içinde IProductDalIN istediği imzalar oldupu için 
    //eFeNTİTYREPOSİTORYBASE İÇİNDE IPRODUCTDALIN İÇİNDEKİ  OPERASYONLAR OLDUĞU İÇİN BEN BU ARKADAŞI ÇÖZERSEM HERKES MUTLU OLUCAK.
    //IPRODUCDAL NİYE VAR?
    //BUSİNES IPRODUCTDALA BAĞLI 
    //ENTİTYFRAMWORK YAPIYORUZ BURDA EfEntityRepositoryBase<Product,EnYakınSatıcıContext> -->dataAcceste ef çalışıyoruz yarın dapper geçebilriz nhibernate geçebilirz sğl postql kullanabilriz
    //diyebilrizki  EfEntityRepositoryBase<Product,EnYakınSatıcıContext> repositorybase yaparım içerde onu kullanırım haklısınız ama şu söylenenden sonra değilsiz ıproductdal ürüne ait özel operasyonları koyucaz.ör üründetayları için üürncategory join atmak gibi sen bunu ıproductdal yazdıında productlar sana diyicekki beni implemete et.
    public List<ProductDetailDto> GetProductDetails()
    {
        using (EnYakınSatıcıContext context=new EnYakınSatıcıContext())
        {
            //ürünlerle categorileiri join yap p deki category id ile c deki categoyid eşitse
            var result = from p in context.Products
                         join c in context.Categories
                         on p.CategoryID equals c.CategoryID
                         select new ProductDetailDto { ProductId = p.ProductId, CategoryName = c.CategoryName, ProductName = p.Name, UnitInStock = p.UnitsInStock };
            return result.ToList();

        }
    }
}
