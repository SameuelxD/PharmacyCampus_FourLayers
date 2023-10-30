using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AddressPersonDto
    {
        public int Id { get; set; }
        public string RoadType { get; set; }
        public int FirstNumber { get; set; }
        public string FirstLetter { get; set; }
        public string Bis { get; set; }
        public string SecondLetter { get; set; }
        public string FirstCardinal { get; set; }
        public int SecondNumber { get; set; }
        public string ThirdLetter { get; set; }
        public int ThirdNumber { get; set; }
        public string SecondCardinal { get; set; }
        public string Complement { get; set; }
        public string PersonCode { get; set; }
        public int CityId { get; set; }
    }
}