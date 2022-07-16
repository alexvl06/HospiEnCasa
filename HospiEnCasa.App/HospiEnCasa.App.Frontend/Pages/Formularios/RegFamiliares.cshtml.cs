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
        [BindProperty]
        public  FamiliarDesignado familiarDesignado {get;set;}

        public void OnGet()
        {
            familiarDesignado = new FamiliarDesignado();
        }
        public void OnPost()
        {
           familiarDesignado = repositorioFamiliar.AddFamiliar(familiarDesignado);
        }
    }
}
