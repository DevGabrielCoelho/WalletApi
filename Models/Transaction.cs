using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WalletApi.Enums;

namespace WalletApi.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string ToAccountId { get; set; } = string.Empty;
        [Required]
        public string FromAccountId { get; set; } = string.Empty;
        [Required]
        public string SenderIp { get; set; } = string.Empty;
        [Required]
        public string Geolocation { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public TransactionStatus Status { get; set; }
        [Required]
        [Precision(18,2)]
        public decimal Value { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Account ToAccount { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public Account FromAccount { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public Refunding Refunding { get; set; } = new();
        [Required]
        public string RefundingId { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Id: {Id}; ToAccountId: {ToAccountId}; FromAccountId: {FromAccountId}; RefundingId: {RefundingId}; Status: {Status}";
        }
    }
}