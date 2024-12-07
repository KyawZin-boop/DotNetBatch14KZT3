using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniPosSystemKZT.RestApi.Features.POS;

[Table("tbl_sale")]
public class SaleModel
{
    [Key]
    [Column("SaleId")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int? Quantity { get; set; }
    public decimal? Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}

public class SaleResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
