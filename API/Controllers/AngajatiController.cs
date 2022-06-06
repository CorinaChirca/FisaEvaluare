using System;
using System.Collections.Generic;
using System.Linq;
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
    [Authorize]
    public class AngajatiController: BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AngajatiController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        //returnez toti angajatii(deci o lista)
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ManageriDto>>> GetAngajati()
        {
            var users = await _userRepository.GetAngajatiAsync();
            return Ok(users);
        }

        //returnez toti angajatii unui anumit manager
        [HttpGet("getangajatibymanagerid/{managerId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AngajatiDto>>> GetAngajatiByManagerId(Guid managerId)
        {
            var users = await _userRepository.GetAngajatiByManagerIdAsync(managerId);
            return Ok(users);
        }

    }
}