using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniPosSystemKZT.RestApi.Features.POS;

[Table("tbl_category")]

public class CategoryModel
{
    [Key]
    public string? CategoryId { get; set; } = Guid.NewGuid().ToString();
    public string? CategoryName { get; set; }
    public string? CategoryCode { get; set; }
}

public class CategoryResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}