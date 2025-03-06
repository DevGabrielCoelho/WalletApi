using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WalletApi.Models
{
    public class Refunding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string TransactionId { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string CreatedBy { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [NotMapped]
        [JsonIgnore]
        public Transaction Transaction { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}; TransactionId: {TransactionId}";
        }
    }
}