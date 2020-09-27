using PosSystem.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosSystem.Models
{
    /// <summary>
    /// User is an entity that represents user of POS System.
    /// </summary>
    public class User
    {
        [Key]
        [Required]
        [Column(DatabaseConstant.USER_ID)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [Column(DatabaseConstant.USER_NAME)]
        [StringLength(DatabaseConstant.MAX_LENGTH)]
        public string UserName { get; set; }

        [Required]
        [Column(DatabaseConstant.USER_EMAIL_ID)]
        [StringLength(DatabaseConstant.MAX_LENGTH)]
        [DataType(DataType.EmailAddress, ErrorMessage = DatabaseConstant.INVALID_EMAIL_MESSAGE)]
        public string UserEmailId { get; set; }

        [Required]
        [Column(DatabaseConstant.PASSWORD)]
        [StringLength(DatabaseConstant.MAX_LENGTH)]
        public string Password { get; set; }
    }
}
