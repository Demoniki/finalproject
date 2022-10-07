using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryyStoreApplication.Models
{
    public class RolesModel
    {
        [Key]
        public int RoleId { get; set; }
        public String RoleType { get; set; }
    }
}
