using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class DenumireCampuriTemplateDto
    {
        public Guid Id { get; set; }
        public string Denumire_campuri { get; set; } 

        public Guid DenumireTabeleTemplateId { get; set; }
    }
}