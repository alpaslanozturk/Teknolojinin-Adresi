using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeknolojininAdresi.Core.Entities;

namespace TeknolojininAdresi.Entities.Concrete
{
    public class Orders : IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }

        public int UsersId { get; set; }
        public Users Users { get; set; }

        public int CartsId { get; set; }
        public Carts Carts { get; set; }
    }
}
