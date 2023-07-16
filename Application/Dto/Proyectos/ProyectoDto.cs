using Application.Dto.TiposProyectos;

namespace Application.Dto.Proyectos
{
    public class ProyectoDto
    {
        public Guid Id { get; set; }
        public Guid CreadorId { get; set; }
        public string Estado { get; set; }
        public string Titulo { get; set; }
        public TipoProyectoSimpleDto TipoProyecto { get; set; }
        public ICollection<RequisitoProyectoDto> Requisitos{ get; set; }

    }
}
