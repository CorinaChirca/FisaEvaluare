using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;

namespace API.DTOs
{
    public class AngajatiDto
    {
        public Guid AngajatId { get; set; }
        public string AngajatNume { get; set; }
        [Column("ManagerId")]//denumesc coloana AppManagerId simplu ManagerId
        public Guid ManagerId { get; set; }
        public ICollection<PerioadaEvaluareDto> PerioadaEvaluare { get; set; }
    }
}