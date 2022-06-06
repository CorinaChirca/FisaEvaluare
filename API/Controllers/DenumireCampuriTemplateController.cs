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
    public class DenumireCampuriTemplateController: BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DenumireCampuriTemplateController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DenumireCampuriTemplateDto>>> GetDenumireCampuriTemplate()
        {
            var users = await _userRepository.GetDenumireCampuriTemplateAsync();
            return Ok(users);
        }

        [HttpGet("getdenumirecampuritemplatebyid/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DenumireCampuriTemplateDto>>> GetDenumireCampuriTemplateById(Guid id)
        {
            var users = await _userRepository.GetDenumireCampuriTemplateByIdAsync(id);
            return Ok(users);
        }

    }
}