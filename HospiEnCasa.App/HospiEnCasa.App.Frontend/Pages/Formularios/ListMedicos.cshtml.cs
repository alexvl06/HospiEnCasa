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
    public class ListMedicosModel : PageModel
    {
        private IRepositorioMedico repositorioMedico = new RepositorioMedico(new Persistencia.AppContext());
        public IEnumerable<Medico> Medicos { get; set; }

        public void OnGet()
        {
            Medicos = repositorioMedico.GetAllMedicos();
        }

    }
}