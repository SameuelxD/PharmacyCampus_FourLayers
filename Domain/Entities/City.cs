namespace Domain.Entities;

    public class City:BaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; } 
        
        public Department Departments { get; set;}   // Cada ciudad tendra el id de un Departamento frente a la coleccion de Ciudades, Departamento a Ciudades , uno a muchos , un Departamento a muchas Ciudades
        public ICollection<AddressPerson> AddressesPeople { get; set; }
    }
