using PosSystem.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PosSystem.Models
{
    public class ItemInSalesTransaction
    {
        [Key]
        [Required]
        [Column(DatabaseConstant.TRANSACTION_ID)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        public Invoice InvoiceReferenceNumber { get; set; }

        public Product ProductReferenceId { get; set; }

        [Required]
        [Column(DatabaseConstant.CONSUMED_QUANTITY)]
        public int ConsumedQuantity { get; set; }

        [Required]
        [Column(DatabaseConstant.TOTAL_PRICE)]
        public double TotalPrice { get; set; }
    }
}
