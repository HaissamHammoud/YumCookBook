using System.Runtime.Serialization;
using MediatR;

namespace Cook.Controllers.Commands
{
    [DataContract]
    public class RegisterUserCommand  : IRequest<string>
    {
        public string document { get; set; }
        public string email { get; set; }
        public string loggin { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}