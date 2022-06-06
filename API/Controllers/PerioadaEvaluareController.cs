using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PerioadaEvaluareController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public PerioadaEvaluareController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PerioadaEvaluareDto>>> GetPerioadaEvaluare()
        {
            var users = await _userRepository.GetPerioadaEvaluareAsync();
            return Ok(users);
        }

        [HttpGet("getperioadaevaluarebyangajatid/{idEtapaEvaluare}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PerioadaEvaluareDto>>> GetPerioadaEvaluareByAngajatId(Guid angajatId)
        {
            var users = await _userRepository.GetPerioadaEvaluareByAngajatIdAsync(angajatId);
            return Ok(users);
        }
    }
}