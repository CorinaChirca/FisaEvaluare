using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class AppManageri
    {
        [Key]
        public Guid ManagerId { get; set; }
        public string ManagerNume { get; set; }
        public string Departament { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        public ICollection<AppAngajati> Angajati { get; set; }
    }
}