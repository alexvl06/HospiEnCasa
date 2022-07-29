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
    public class ConsultarHistoriaModel : PageModel
    {  
        private readonly IRepositorioPaciente _repositorioPaciente;
        public Paciente paciente {get;set;}

        public ConsultarHistoriaModel(IRepositorioPaciente repositorioPaciente)
        {
            this._repositorioPaciente=repositorioPaciente;
        }
        public void OnGet(int idPaciente)
        {
            paciente=_repositorioPaciente.GetPaciente(idPaciente);
        }
    }
}
