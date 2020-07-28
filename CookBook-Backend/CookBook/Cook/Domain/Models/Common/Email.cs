using System;
namespace Cook.Domain.Models.Common
{
    public class Email
    {
        public string Address {get; set;}

        public Email(string emailAddress)
        {
            if(string.IsNullOrEmpty(emailAddress))
            {
                throw new Exception("Email não pode ser vazio");
            }
            if(!emailAddress.Contains("@"))
            {
                throw new Exception("Endereço de Email invalido");
            }
            Address = emailAddress;
        }
    }
}