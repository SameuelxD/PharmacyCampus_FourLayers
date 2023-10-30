using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonDto
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int TypeDocumentId { get; set; }
        public int PersonRoleId { get; set; }
        public int TypePersonId { get; set; }
    }
}