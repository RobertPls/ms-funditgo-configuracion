
using Application.Dto.Requerimientos;

namespace Application.Dto.TiposProyectos
{
    public class RequerimientoTipoDto
    {
        public Guid Id { get; set; }
        public RequerimientoDto Requerimiento { get; set; }
        public bool Obligatorio{ get; set; }
    }
}
