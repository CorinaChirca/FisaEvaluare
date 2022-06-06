using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.DTOs;

namespace API.Entities
{
    [Table("DenumireCampuriTemplate")]
    public class AppDenumireCampuriTemplate
    {
        [Key]
        public Guid Id { get; set; }
        public string Denumire_campuri { get; set; }

        public Guid DenumireTabeleTemplateId { get; set; }
        public AppDenumireTabeleTemplate AppDenumireTabeleTemplate { get; set; }
    }
}