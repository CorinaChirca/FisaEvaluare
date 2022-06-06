using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SalveazaDatele : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public SalveazaDatele(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("saveData")]
        public async Task<ActionResult<PerioadaEvaluareDto>> SaveData(PerioadaEvaluareDto perEvalDto)
        {
            if (await PerEvalExists(perEvalDto.AngajatId, perEvalDto.Perioada_evaluare_start, perEvalDto.Perioada_evaluare_end)) 
                return BadRequest("Perioada se suprapune cu una existenta");

            var user = new AppPerioadaEvaluare
            {
                Id = new Guid(),
                Perioada_evaluare_start = perEvalDto.Perioada_evaluare_start,
                Perioada_evaluare_end = perEvalDto.Perioada_evaluare_end,
                AngajatId = perEvalDto.AngajatId
            };

            _context.PerioadaEvaluare.Add(user);
            await _context.SaveChangesAsync();

            return new PerioadaEvaluareDto
            {
                IdEtapaEvaluare = new Guid(),
                Perioada_evaluare_start = perEvalDto.Perioada_evaluare_start,
                Perioada_evaluare_end = perEvalDto.Perioada_evaluare_end,
                AngajatId = perEvalDto.AngajatId
            };
        }

        private async Task<bool> PerEvalExists(Guid angajatId, DateTime per_inceput, DateTime per_sfarsit)
        {
            //verifica daca perioada introdusa pentru un anumit user se suprapune cu perioada evaluata deja existenta in baza
            return await _context.PerioadaEvaluare.AnyAsync(
                x => x.AngajatId == angajatId  
                    && ((x.Perioada_evaluare_start < per_inceput && x.Perioada_evaluare_end > per_sfarsit ) 
                    || (per_inceput > x.Perioada_evaluare_start && x.Perioada_evaluare_end > per_inceput)
                    || (per_sfarsit > x.Perioada_evaluare_start && x.Perioada_evaluare_end > per_sfarsit)
                    || (per_inceput < x.Perioada_evaluare_start && x.Perioada_evaluare_end < per_sfarsit))
            );
        }
    }
}