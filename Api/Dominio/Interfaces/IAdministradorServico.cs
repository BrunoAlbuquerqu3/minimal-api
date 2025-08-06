using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;
using System.Collections.Generic;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
    Administrador? Incluir(Administrador administrador);
    List<Administrador> Todos(int? pagina = 1);
    Administrador? BuscarPorId(int id);
    void Atualizar(Administrador administrador);
    void Apagar(Administrador administrador);
}
