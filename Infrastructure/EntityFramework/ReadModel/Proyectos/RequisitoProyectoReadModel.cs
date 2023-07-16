using Infrastructure.EntityFramework.ReadModel.Archivos;
using Infrastructure.EntityFramework.ReadModel.Requerimientos;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Proyectos
{
    internal class RequisitoProyectoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public ArchivoReadModel Archivo { get; set; }
        public Guid ArchivoId { get; set; }
        public RequerimientoReadModel Requerimiento { get; set; }
        public Guid RequerimientoId { get; set; }
        public ProyectoReadModel Proyecto { get; set; }
        public Guid ProyectoId { get; set; }
    }
}
