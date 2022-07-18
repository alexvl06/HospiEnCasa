using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Frontend.Pages
{
    public class RegPacientesModel : PageModel
    {
        private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        [BindProperty]
        public  Paciente paciente {get;set;}

        public void OnGet()
        {
            paciente = new Paciente();
        }
        public void OnPost()
        {
           paciente = repositorioPaciente.AddPaciente(paciente);
        }
    }
}