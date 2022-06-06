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
    public class DenumireTabeleTemplateController: BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DenumireTabeleTemplateController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DenumireTabeleTemplateDto>>> GetDenumireTabeleTemplate()
        {
            var users = await _userRepository.GetDenumireTabeleTemplateAsync();
            return Ok(users);
        }

        [HttpGet("getdenumiretabeletemplatebyid/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DenumireTabeleTemplateDto>>> GetDenumireTabeleTemplateById(Guid id)
        {
            var users = await _userRepository.GetDenumireTabeleTemplateByIdAsync(id);
            return Ok(users);
        }

        [HttpGet("getdenumiretabeletemplatebyname/{name}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DenumireTabeleTemplateDto>>> GetDenumireTabeleTemplateByName(string name)
        {
            var users = await _userRepository.GetDenumireTabeleTemplateByNameAsync(name);
            return Ok(users);
        }

    }
}