using System;
using System.Collections.Generic;

namespace HospiEnCasa.App. Dominio
{
    public class Historia{
        public List <SugerenciaCuidado>  SugerenciaCuidado{get;set;}
        public int  Id{get;set;}
        public string Diagnostico{get;set;}
        public string Entorno{get;set;}
        
        public int PacienteId { get; set; }

        public Paciente? paciente {get; set;}

    }
}