using System.ComponentModel.DataAnnotations;
using VaporStore;
using VaporStore.Data.Models.Enums;

public class UserCardImportModel
{
    [Required]
    [RegularExpression(GlobalConstants.CardValidation)]
    public string Number { get; set; }

    [Required]
    [RegularExpression(GlobalConstants.CvcValidation)]
    public string CVC { get; set; }

    [Required]
    public CardType? Type { get; set; }
}
