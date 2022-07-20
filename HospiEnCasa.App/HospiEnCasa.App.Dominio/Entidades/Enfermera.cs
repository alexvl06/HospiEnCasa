using System;
using System.Collections.Generic;
namespace HospiEnCasa.App.Dominio
{
    public class Enfermera : Persona
    {
        public string TarjetaProfesional { get; set; }
        public int HorasLaborales { get; set; }
        public virtual IEnumerable<Paciente>? pacientes { get; set; }
    }
}