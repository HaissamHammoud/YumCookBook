namespace Cook.Domain.Models.Common
{
    public class Document
    {
        public string Number {get; set;}
        public string DocumentName{get; set;}

        public Document(string number, string name)
        {
            Number = number;
            DocumentName = name;
        }
    }
}