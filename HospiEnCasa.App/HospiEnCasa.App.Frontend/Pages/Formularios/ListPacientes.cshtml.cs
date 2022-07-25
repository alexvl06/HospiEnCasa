using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;


namespace HospiEnCasa.App.Frontend.Pages
{
    public class ListPacientesModel : PageModel
    {
        private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private IRepositorioMedico repositorioMedico = new RepositorioMedico(new Persistencia.AppContext());
        public IEnumerable<Paciente> Pacientes { get; set; }
        public int? IdPaciente {get;set;}
        public int? IdMedico {get;set;}

        public void OnGet(int? idPaciente, int? idMedico)
        {
            if (idPaciente.HasValue)
            {
                Paciente pacienteEncontrado = repositorioPaciente.GetPaciente(idPaciente.Value);
                if(pacienteEncontrado!=null)
                {
                List<Paciente> listaP = new List<Paciente>();
                listaP.Add(pacienteEncontrado);
                Pacientes = listaP;
                IdPaciente=idPaciente;
                IdMedico=idMedico;
                }else{
                    Pacientes = repositorioPaciente.GetAllPacientes();
                }
            }
            else if(idMedico.HasValue)
            {
                Pacientes = repositorioMedico.GetPatientsByDoctorId(idMedico);
                
            }else
            {
                Pacientes = repositorioPaciente.GetAllPacientes();
            }



        }
    }
}
