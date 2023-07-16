﻿using Domain.Model.Proyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factory.Proyectos
{
    public class ProyectoFactory : IProyectoFactory
    {
        public Proyecto Crear(Guid id, Guid creadorId, Guid tipoProyectoId, string titulo, string estado)
        {
            return new Proyecto(id, creadorId, tipoProyectoId, titulo, estado);
        }
    }
}
