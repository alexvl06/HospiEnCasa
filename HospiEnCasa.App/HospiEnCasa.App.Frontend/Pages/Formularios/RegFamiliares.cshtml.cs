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
    public class RegFamiliaresModel : PageModel
    {
        private IRepositorioFamiliar repositorioFamiliar = new RepositorioFamiliar(new Persistencia.AppContext());
        private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        [BindProperty]
        public Paciente paciente { get; set; }
        public int? IdPaciente { get; set; }
        [BindProperty]
        public FamiliarDesignado familiarDesignado { get; set; }

        public void OnGet(int? idPaciente)
        {
            if (idPaciente.HasValue)
            {
                int IdPaciente = idPaciente.Value;
                paciente = repositorioPaciente.GetPaciente(IdPaciente);

                familiarDesignado = new FamiliarDesignado
                {
                    PacienteId = IdPaciente
                };
            }
        }
        public void OnPost()
        {
            familiarDesignado = repositorioFamiliar.AddFamiliar(familiarDesignado);
        }
    }
}
