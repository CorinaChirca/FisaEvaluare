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
    public class ManageriController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public ManageriController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        //returnez toti userii(deci o lista)
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ManageriDto>>> GetManageri()
        {
            var users = await _userRepository.GetManageriAsync();
            return Ok(users);
        }


        // api/users/getmemberasync/3
        //returnez doar un user
        [HttpGet("getmanagerbyid/{managerId}")]
        [AllowAnonymous]
        //[Authorize]
        //[HttpGet("{username}")]
        public async Task<ActionResult<ManageriDto>> GetManagerById(Guid managerId)
        {
            return await _userRepository.GetManagerByIdAsync(managerId);
        }
    }
}