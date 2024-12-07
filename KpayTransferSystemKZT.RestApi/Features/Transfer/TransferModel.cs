using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KpayTransferSystemKZT.RestApi.Features.Transfer;

[Table("tbl_transaction")]
public class TransferModel
{
    [Key]
    public string? TransactionId { get; set; } = Guid.NewGuid().ToString();
    public string? FromMobileNo { get; set; }
    public string? ToMobileNo { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? Date {  get; set; }
    public string? Notes { get; set; }
}

public class TransferRequestModel
{
    public string? FromMobileNo { get; set; }
    public string? ToMobileNo { get; set; }
    public decimal? Amount { get; set; }
    public string? Password { get; set; }
    public string? Notes { get; set; }
}

public class TransferResponseModel
{
    public bool? IsSuccess { get; set; }
    public string? Message { get; set; }
}
