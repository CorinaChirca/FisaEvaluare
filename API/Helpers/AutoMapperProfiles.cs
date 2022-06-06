using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //.ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FirstName + " " + c.LastName))
            //.ForMember(d => d.TotalContacts, opt => opt.MapFrom(c => c.Contacts.Count())

            //sursa, destinatia
            CreateMap<AppManageri, ManageriDto>(); 
            CreateMap<AppAngajati, AngajatiDto>();
            CreateMap<AppDenumireTabeleTemplate, DenumireTabeleTemplateDto>(); 
            CreateMap<AppDenumireCampuriTemplate, DenumireCampuriTemplateDto>(); 
            CreateMap<AppNote, NoteDto>(); 

            CreateMap<AppPerioadaEvaluare, PerioadaEvaluareDto>()
                .ForMember(x => x.AngajatId, 
                   cd => cd.MapFrom(map => map.AngajatId)); //daca nu au aceeasi denumire atunci trebuie mapat, spus ce camp in ce camp merge din appPerioadaEvaluare in PerioadaEvaluareDto
            CreateMap<AppDenumireTabeleTemplate, DenumireTabeleTemplateDto>()
                .ForMember(x => x.Id, cd => cd.MapFrom(map => map.Id));
            CreateMap<AppDenumireCampuriTemplate, DenumireCampuriTemplateDto>()
                .ForMember(x => x.Id, cd => cd.MapFrom(map => map.Id));
        }
    }
}