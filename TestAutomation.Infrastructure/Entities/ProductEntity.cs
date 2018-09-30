using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAutomation.Infrastructure.Entities
{
    public class ProductEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriceTaxIncluded { get; set; }
        public int PriceTaxExcluded { get; set; }
    }
}