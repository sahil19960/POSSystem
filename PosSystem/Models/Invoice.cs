using PosSystem.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosSystem.Models
{
    public class Invoice
    {
        [Key]
        [Required]
        [Column(DatabaseConstant.INVOICE_NUMBER)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNumber { get; set; }

        public User EmployeeId { get; set; }

        [Required]
        [Column(DatabaseConstant.DATE_OF_SALE)]
        public DateTime DateOfSale { get; set; }

        [Required]
        [Column(DatabaseConstant.DISCOUNT)]
        public double Discount { get; set; }

        [Required]
        [Column(DatabaseConstant.VAT)]
        public double Vat { get; set; }
    }
}
