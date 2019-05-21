using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeknolojininAdresi.Core.Entities;

namespace TeknolojininAdresi.Entities.Concrete
{
    public class Roles : IEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string Role { get; set; }

        public ICollection<Users> Users { get; set; }

    }
}
