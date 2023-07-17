using Application.Dto.Archivos;
using Application.Dto.Requerimientos;

namespace Application.Dto.Proyectos
{
    public class RequisitoProyectoDto
    {
        public Guid Id { get; set; }
        public RequerimientoDto Requerimiento { get; set; }
        public Guid ArchivoId { get; set; }
    }
}
