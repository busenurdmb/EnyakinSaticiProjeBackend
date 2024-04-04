// See https://aka.ms/new-console-template for more information
using En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework;
using EnYakınSatıcı.BusinessLayer.Abstract;
using EnYakınSatıcı.BusinessLayer.Concrete;

//CategoryTest();

//ProductTest();

//static void CategoryTest()
//{
//    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
//    foreach (var item in categoryManager.GetAll().Data)
//    {
//        Console.WriteLine(item.CategoryName);
//    }
//}

//static void ProductTest()
//{
//    //şuanlık newliyoruz IoC bununla yapıcaz 
//    ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
//    var result= productManager.GetProductDetails();
//    if(result.Success == true)
//    {
// foreach (var item in result.Data)
//    {
//        Console.WriteLine(item.ProductName+"/"+item.CategoryName);
//    }
//    }
//    else
//    {
//        Console.WriteLine(result.Message);
//    }
   
//}