using EnYakınSatıcı.Core;

namespace EnYakınSatıcı.EntityLayer.DTOs;

public class ProductDetailDto:IDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public short UnitInStock { get; set; }
}
