using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace HospiEnCasa.App.Frontend.Pages
{
    public class RegPacientesModel : PageModel
    {
        private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private IRepositorioMedico repositorioMedico = new RepositorioMedico(new Persistencia.AppContext());

        [BindProperty]
        public Paciente paciente { get; set; }
        public IEnumerable<Medico> medicos{get; set;}

        public void OnGet()
        {
            paciente = new Paciente();
            medicos = repositorioMedico.GetAllMedicos();
            ViewData["MedicoId"] = new SelectList(medicos, "Id", "Apellidos");
        }
        public void OnPost()
        {
            paciente = repositorioPaciente.AddPaciente(paciente);
        }
    }
}