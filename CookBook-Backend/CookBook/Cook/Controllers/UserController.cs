using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookBook.Models;
using Cook.Domain.Models.Users;
using MediatR;
using CookBook.Interface;
using Cook.Application.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using CookBook.Application;
using CookBook.Repositories;
using CookBook_Backend.Application.Interface;
using Cook.Controllers.Commands;

namespace Cook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAsyncRepository<User> _repository;

        public UserController(IMediator mediator, IAsyncRepository<User> repository)
        {
            _repository = repository;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var response = await _repository.GetAll();
            return response.ToList();
        }
    }
}