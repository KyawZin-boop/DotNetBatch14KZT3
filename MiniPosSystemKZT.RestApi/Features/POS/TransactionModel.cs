using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniPosSystemKZT.RestApi.Features.POS;

[Table("tbl_transaction")]
public class TransactionModel
{
    [Key]
    [Column("TransactionId")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? ProductId { get; set; }
    public int? Quantity { get; set; }
    public decimal? Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string? PaymentMethod { get; set; }
}

public class TransactionRequestModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
