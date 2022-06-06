using System;
using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class ManageriDto
    {
        public Guid ManagerId { get; set; }
        public string ManagerNume { get; set; }
        public string Departament { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        //deoarece metoda era GetAge atunci executa metoda si returneaza valoarea in variabila Age
        //public DateTime Created { get; set; }
        public ICollection<AngajatiDto> Angajati { get; set; }

    }
}