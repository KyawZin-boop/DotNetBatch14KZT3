using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniPosSystemKZT.RestApi.Features.POS;

[Table("tbl_product")]
public class ProductModel
{
    [Key]
    public string? ProductId { get; set; } = Guid.NewGuid().ToString();
    [Column("ProductName")]
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
}

public class ProductResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
