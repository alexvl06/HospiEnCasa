using System;
namespace HospiEnCasa.App.Dominio
{
    public class FamiliarDesignado : Persona
    {
        public string Parentesco { get; set; }
        public string Correo { get; set; }
        public int PacienteId { get; set; }

        public Paciente? paciente { set; get; }
    }
}