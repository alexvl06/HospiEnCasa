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
    public class RegHistoriasModel : PageModel
    {
        private IRepositorioHistoria repositorioHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        [BindProperty]
        public Historia Historia { get; set; }
        public IEnumerable<Paciente> Pacientes { get; set; }


        public void OnGet()
        {


            Pacientes = repositorioPaciente.GetAllPacientes();
            ViewData["PacienteId"] = new SelectList(Pacientes, "Id", "Apellidos");



        }
        public void OnPost()
        {
            Pacientes = repositorioPaciente.GetAllPacientes();
            ViewData["PacienteId"] = new SelectList(Pacientes, "Id", "Apellidos");

            Historia.Id = repositorioHistoria.HistoriaWasAssigned(Historia.PacienteId);
            if (Historia.Id != 0)
            {

                Historia = repositorioHistoria.UpdateHistoria(Historia);

            }
            else
            {

                Historia = repositorioHistoria.AddHistoria(Historia);
            }
        }
    }
}