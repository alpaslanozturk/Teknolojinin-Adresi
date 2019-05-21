using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeknolojininAdresi.Entities.Concrete
{
    public class Users
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        public int RolesId { get; set; }
        public Roles Roles { get; set; }

        public ICollection<Orders> Orders { get; set; }
        public ICollection<Carts> Carts { get; set; }
    }
}
