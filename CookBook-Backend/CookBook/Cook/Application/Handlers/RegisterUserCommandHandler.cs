using System.Threading;
using System.Threading.Tasks;
using Cook.Controllers.Commands;
using Cook.Domain.Models.Users;
using CookBook.Interface;
using MediatR;

namespace Cook.Application.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IAsyncRepository<User> _repository;
        public RegisterUserCommandHandler(IMediator mediator,IAsyncRepository<User> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.document,request.email, request.password
                                ,request.firstName, request.lastName);
          
            await _repository.Add(user);
            return await Task.FromResult("Usuario adicionado!!");
            
        }
    }
}