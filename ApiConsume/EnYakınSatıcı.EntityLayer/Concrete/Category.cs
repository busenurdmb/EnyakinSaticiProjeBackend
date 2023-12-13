using EnYakınSatıcı.Core.Entities;


namespace EnYakınSatıcı.EntityLayer.Concrete;

public class Category:IEntity
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public bool Status { get; set; }

    //public List<Product> Products { get; set; }
}
