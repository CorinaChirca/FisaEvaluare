using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.DTOs;

namespace API.Entities
{
    [Table("PerioadaEvaluare")]
    public class AppPerioadaEvaluare
    {       
        [Key]
        public Guid Id { get; set; }
        public DateTime Perioada_evaluare_start { get; set; }
        public DateTime Perioada_evaluare_end { get; set; }

        public AppAngajati AppAngajati { get; set; }
        public Guid AngajatId { get; set; }

        [ForeignKey("Note")]
        public Guid NoteId { get; set; }
        [ForeignKey("DenumireTabeleTemplate")]
        public Guid DenumireTabeleTemplateId { get; set; }

        
        public AppDenumireTabeleTemplate DenumireTabeleTemplate { get; set; }
        public AppNote Note { get; set; }
    }
}