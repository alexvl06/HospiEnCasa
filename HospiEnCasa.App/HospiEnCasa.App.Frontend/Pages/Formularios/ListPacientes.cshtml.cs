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

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Pacientes = repositorioPaciente.GetAllPacientes();
            }
            else
            {
                Pacientes = repositorioMedico.GetPatientsByDoctorId(id);

            }



        }
    }
}
