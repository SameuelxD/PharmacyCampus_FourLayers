
namespace Domain.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public ICollection<City> Cities { get; set; } // Cada departamento tendra una coleccion de ciudades
        public Country Countries { get; set; } // Cada departamento tendra el id de un Pais frente a la coleccion de Departamentos, Pais a Departamentos , uno a muchos , un Pais a muchos Departamentos
    }
}