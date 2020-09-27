using PosSystem.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PosSystem.Models
{
    /// <summary>
    /// Product is an entity that represents user of POS System Item.
    /// </summary>
    public class Product
    {
        [Key]
        [Required]
        [Column(DatabaseConstant.PRODUCT_ID)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [Column(DatabaseConstant.PRODUCT_NAME)]
        [StringLength(DatabaseConstant.MAX_LENGTH)]
        public string ProductName { get; set; }

        [Required]
        [Column(DatabaseConstant.UNIT_PRICE)]
        public double UnitPrice { get; set; }

        [Required]
        [Column(DatabaseConstant.AVAILABLE_QUANTITY)]
        public int AvailableQuantity { get; set; }

        [Required]
        [Column(DatabaseConstant.IMAGE_URL)]
        public string ImageUrl { get; set; }

        [Required]
        [Column(DatabaseConstant.CATEGORY)]
        public int Category { get; set; }
    }
}
