using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Requerimientos
{
    internal class RequerimientoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
