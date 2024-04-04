using Core.Entities.Concrete;
using EnYakınSatıcı.Core.Entities;


namespace EnYakınSatıcı.EntityLayer.Concrete;

public class Product:IEntity
{
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public short UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
    public int CategoryID { get; set; }
public string imageUrl { get; set; }

      //////public Category Category{ get; set; }
      //////public User User{ get; set; }




}
