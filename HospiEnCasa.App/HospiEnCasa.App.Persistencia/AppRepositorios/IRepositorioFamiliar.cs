using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
public interface IRepositorioFamiliar{
    //IEnumerable<Paciente> GetAllPacientes();
    FamiliarDesignado AddFamiliar(FamiliarDesignado familiar);
    FamiliarDesignado UpdateFamiliar(FamiliarDesignado familiar);
    void DeleteFamiliar(int idFamiliar);
    FamiliarDesignado GetFamiliar(int idFamiliar);
}
}