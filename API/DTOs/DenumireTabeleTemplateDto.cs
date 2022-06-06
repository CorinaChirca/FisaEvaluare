using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class DenumireTabeleTemplateDto
    {
        public Guid Id { get; set; }
        public string Denumire_tabele { get; set; }

        //public Guid DenumireTabeleTemplateId { get; set; }
        public ICollection<DenumireCampuriTemplateDto> DenumireCampuriTemplate { get; set; }
    }
}