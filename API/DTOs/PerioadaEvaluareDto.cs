using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;

namespace API.DTOs
{
    public class PerioadaEvaluareDto
    {
        public Guid IdEtapaEvaluare { get; set; }
        public DateTime Perioada_evaluare_start { get; set; }
        public DateTime Perioada_evaluare_end { get; set; }
        public Guid AngajatId { get; set; }

        public Guid DenumireTabeleTemplateId { get; set; }
        public Guid NoteId { get; set; }
        
        public DenumireTabeleTemplateDto DenumireTabele { get; set; }   
        public NoteDto Note { get; set; }     
    }
}