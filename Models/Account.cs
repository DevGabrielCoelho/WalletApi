using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WalletApi.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Precision(18,2)]
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [NotMapped]
        [JsonIgnore]
        public User User { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Transaction> IncomingTransactions { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public List<Transaction> OutgoingTransactions { get; set; } = new();

        public override string ToString()
        {
            return $"Id: {Id}; UserId: {UserId}";
        }
    }
}