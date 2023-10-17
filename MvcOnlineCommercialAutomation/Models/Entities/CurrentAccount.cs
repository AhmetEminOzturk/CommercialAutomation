using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class CurrentAccount
    {
        [Key]
        public int CurrentAccountID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="En fazla 30 karakter yazabilirsiniz")]
        public string CurrentAccountName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string CurrentAccountSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CurrentAccountCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentAccountMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CurrentAccountPassword { get; set; }

        public bool Status { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}