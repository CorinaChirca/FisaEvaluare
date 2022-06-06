
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Angajati")]
    public class AppAngajati
    {
        [Key]
        public Guid AngajatId { get; set; }
        public string AngajatNume { get; set; }

        public AppManageri AppManageri { get; set; }          
        public Guid ManagerId { get; set; }
        
        public ICollection<AppPerioadaEvaluare> PerioadaEvaluare { get; set; }

    }
}