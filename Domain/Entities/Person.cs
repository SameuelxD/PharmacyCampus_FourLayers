using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person:BaseEntity
    {
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int TypeDocumentId { get; set; }
        public int PersonRoleId { get; set; }
        public int TypePersonId { get; set; }
        public DocumentType DocumentsType { get; set; }
        public PersonRole PeopleRole { get; set; }
        public PersonType PeopleType { get; set; }
        public ICollection<AddressPerson> AddressPeople { get; set; }
        public ICollection<ContactPerson> ContactPeople { get; set; }
        public ICollection<InventoryManagement> InventoriesManagement { get; set; }

    }
}