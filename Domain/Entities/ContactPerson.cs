using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactPerson:BaseEntity
    {
        public string PersonCode { get; set; }
        public int TypeContactId { get; set; }
        public Person People { get; set; }
        public ContactType TypeContacts { get; set; }
    }
}