using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        //pt ManageriController
        public async Task<ManageriDto> GetManagerByIdAsync(Guid managerId)
        {
            return await _context.Manageri
                .Where(x => x.ManagerId == managerId)
                .ProjectTo<ManageriDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ManageriDto>> GetManageriAsync()
        {
            return await _context.Manageri
                .ProjectTo<ManageriDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

/*
        public async Task<AppManager> GetUserByIdAsync(int id)
        {
            return await _context.Manageri.FindAsync(id);
        }

        public async Task<AppManager> GetUserByUsernameAsync(string username)
        {
            return await _context.Manageri
                .Include(p => p.Angajati)
                .SingleOrDefaultAsync(x => x.ManagerNume == username);
        }

        public async Task<IEnumerable<AppManager>> GetUsersAsync()
        {
            return await _context.Manageri
                .Include(p => p.Angajati)
                .ToListAsync();
        }
*/
        public async Task<bool> SaveAllAsync()
        {
            //daca au fost salvate modificarile
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppManageri user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
 
        //pt AngajatiController
        public async Task<IEnumerable<AngajatiDto>> GetAngajatiAsync()
        {
            return await _context.Angajati
                .ProjectTo<AngajatiDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<AngajatiDto>> GetAngajatiByManagerIdAsync(Guid managerId)
        {
            return await _context.Angajati
                .ProjectTo<AngajatiDto>(_mapper.ConfigurationProvider)
                .Where(i => i.ManagerId == managerId).ToListAsync();
        }

        //pt PerioadaEvaluareController
        public async Task<IEnumerable<PerioadaEvaluareDto>> GetPerioadaEvaluareAsync()
        {
            return await _context.PerioadaEvaluare
                .ProjectTo<PerioadaEvaluareDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<PerioadaEvaluareDto>> GetPerioadaEvaluareByAngajatIdAsync(Guid angajatId)
        {
            return await _context.PerioadaEvaluare
                .ProjectTo<PerioadaEvaluareDto>(_mapper.ConfigurationProvider)
                .Where(i => i.AngajatId == angajatId).ToListAsync();
        }


        //pt DenumireTabeleTemplateController
        public async Task<IEnumerable<DenumireTabeleTemplateDto>> GetDenumireTabeleTemplateAsync()
        {
            return await _context.DenumireTabeleTemplate
                //.Include(c => c.Note)
                //.SelectMany(c => c.Note, (x,y) => new { Note_id = x.Id, Note_nota = y.nota})
                //.FromSqlRaw("select p.id, denumire, idetapaevaluare, nota, n.id from Productivitate p, Note n")
                .ProjectTo<DenumireTabeleTemplateDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<DenumireTabeleTemplateDto>> GetDenumireTabeleTemplateByIdAsync(Guid id)
        {
            return await _context.DenumireTabeleTemplate
                .ProjectTo<DenumireTabeleTemplateDto>(_mapper.ConfigurationProvider)
                .Where(i => i.Id == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<DenumireTabeleTemplateDto>> GetDenumireTabeleTemplateByNameAsync(string name)
        {
            return await _context.DenumireTabeleTemplate
                .ProjectTo<DenumireTabeleTemplateDto>(_mapper.ConfigurationProvider)
                .Where(i => i.Denumire_tabele == name)
                .ToListAsync();
        }

        //pt DenumireCampuriTemplateController
        public async Task<IEnumerable<DenumireCampuriTemplateDto>> GetDenumireCampuriTemplateAsync()
        {
            return await _context.DenumireCampuriTemplate
                .ProjectTo<DenumireCampuriTemplateDto>(_mapper.ConfigurationProvider)
                .OrderBy(i => i.DenumireTabeleTemplateId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DenumireCampuriTemplateDto>> GetDenumireCampuriTemplateByIdAsync(Guid id)
        {
            return await _context.DenumireCampuriTemplate
                .ProjectTo<DenumireCampuriTemplateDto>(_mapper.ConfigurationProvider)
                .Where(i => i.DenumireTabeleTemplateId == id)
                .ToListAsync();
        }

        //pt NoteController
        public async Task<IEnumerable<NoteDto>> GetNoteAsync()
        {
            return await _context.Note
                .ProjectTo<NoteDto>(_mapper.ConfigurationProvider)
                //.Where(i => i.Nota != "0 - test")
                .OrderBy(i => i.Nota)
                .ToListAsync();
        }
    }
}