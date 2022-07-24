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
    public class DetailPacientesModel : PageModel
    {
        
        private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        [BindProperty]
        public Paciente paciente {get;set;}
        public int IdPaciente{get;set;}
             

        public void OnGet(int idPaciente)
        {
            IdPaciente=idPaciente;
            paciente = repositorioPaciente.GetPaciente(idPaciente);
        }

        public void OnPost()
        {
            paciente = repositorioPaciente.UpdatePaciente(paciente);
        }
    }
}
