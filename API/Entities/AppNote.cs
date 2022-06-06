using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Note")]
    public class AppNote
    {
        public Guid Id { get; set; }
        public string Nota { get; set; }

        public AppPerioadaEvaluare AppPerioadaEvaluare { get; set; } 
    }
}