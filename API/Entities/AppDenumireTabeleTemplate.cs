using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.DTOs;

namespace API.Entities
{
    [Table("DenumireTabeleTemplate")]
    public class AppDenumireTabeleTemplate
    {
        [Key]
        public Guid Id { get; set; }
        public string Denumire_tabele { get; set; }

        public AppPerioadaEvaluare AppPerioadaEvaluare { get; set; } 

        public ICollection<AppDenumireCampuriTemplate> DenumireCampuriTemplate { get; set; } 
    }
}