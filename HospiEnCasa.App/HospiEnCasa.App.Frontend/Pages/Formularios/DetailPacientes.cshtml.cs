using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class DetailPacientesModel : PageModel
    {
        
        private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private IRepositorioFamiliar repositorioFamiliar = new RepositorioFamiliar(new Persistencia.AppContext());
        private IRepositorioMedico repositorioMedico = new RepositorioMedico(new Persistencia.AppContext());

        [BindProperty]
        public Paciente paciente {get;set;}
        public int IdPaciente{get;set;}
        [BindProperty]
        public  FamiliarDesignado familiarDesignado {get;set;}
        [BindProperty]
        public  Medico medico {get;set;}
        [BindProperty]
        public IEnumerable<Medico> medicos{get; set;}
             

        public void OnGet(int idPaciente)
        {
            IdPaciente=idPaciente;
            paciente = repositorioPaciente.GetPaciente(idPaciente);
            familiarDesignado = repositorioFamiliar.GetFamiliarByPatientId(idPaciente);
            if(familiarDesignado==null){
                familiarDesignado=new FamiliarDesignado();
            }
            medico = repositorioMedico.GetMedico(paciente.MedicoId);
            medicos = repositorioMedico.GetAllMedicos();
            ViewData["MedicoId"] = new SelectList(medicos, "Id", "Apellidos");
        }

        public IActionResult OnPost()
        {
            paciente = repositorioPaciente.UpdatePaciente(paciente);
            return RedirectToPage("ListPacientes");
        }
    }
}
