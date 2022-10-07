using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryyStoreApplication.Models
{
    public class UserAccountModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
        public String PhoneNumber { get; set; }
        
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RolesModel RolesModel { get;set;}
    }
}
