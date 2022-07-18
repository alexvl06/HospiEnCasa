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
    public class RegMedicosModel : PageModel
    {
        private IRepositorioMedico repositorioMedico= new RepositorioMedico(new Persistencia.AppContext());
        [BindProperty]
        public  Medico medico {get;set;}

        public void OnGet()
        {
            medico = new Medico();
        }
        public void OnPost()
        {
           medico = repositorioMedico.AddMedico(medico);
        }
    }
}
