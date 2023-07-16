﻿namespace Application.Dto.TiposProyectos
{
    public class TipoProyectoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<RequerimientoTipoDto> Requerimientos { get; set; }

    }
}
