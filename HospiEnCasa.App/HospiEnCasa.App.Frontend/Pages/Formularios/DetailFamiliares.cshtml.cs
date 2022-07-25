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
    public class DetailFamiliaresModel : PageModel
    {
        
        private IRepositorioFamiliar repositorioFamiliar = new RepositorioFamiliar(new Persistencia.AppContext());

        [BindProperty]
        public FamiliarDesignado familiarDesignado {get;set;}
        public int IdFamiliar{get;set;}
             

        public void OnGet(int idFamiliar)
        {
            IdFamiliar=idFamiliar;
            familiarDesignado = repositorioFamiliar.GetFamiliar(idFamiliar);
        }

        public void OnPost()
        {
            familiarDesignado = repositorioFamiliar.UpdateFamiliar(familiarDesignado);
        }
    }
}