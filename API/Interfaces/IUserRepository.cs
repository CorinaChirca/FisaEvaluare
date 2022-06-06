using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppManageri user);
        Task<bool> SaveAllAsync();
        //Task<IEnumerable<AppManager>> GetUsersAsync();
        //Task<AppManager> GetUserByIdAsync(int id);
        //Task<AppManager> GetUserByUsernameAsync(string username);

        Task<IEnumerable<ManageriDto>> GetManageriAsync();
        Task<ManageriDto> GetManagerByIdAsync(Guid managerId);  //string username

        Task<IEnumerable<AngajatiDto>> GetAngajatiAsync();
        Task<IEnumerable<AngajatiDto>> GetAngajatiByManagerIdAsync(Guid managerId);

        Task<IEnumerable<PerioadaEvaluareDto>> GetPerioadaEvaluareAsync();
        Task<IEnumerable<PerioadaEvaluareDto>> GetPerioadaEvaluareByAngajatIdAsync(Guid angajatId);

        Task<IEnumerable<DenumireTabeleTemplateDto>> GetDenumireTabeleTemplateAsync();
        Task<IEnumerable<DenumireTabeleTemplateDto>> GetDenumireTabeleTemplateByIdAsync(Guid id);
        Task<IEnumerable<DenumireTabeleTemplateDto>> GetDenumireTabeleTemplateByNameAsync(string name);
        

        Task<IEnumerable<DenumireCampuriTemplateDto>> GetDenumireCampuriTemplateAsync();
        Task<IEnumerable<DenumireCampuriTemplateDto>> GetDenumireCampuriTemplateByIdAsync(Guid id);

        Task<IEnumerable<NoteDto>> GetNoteAsync();
    }
}