using MinimalApi.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();
        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Administradores
                           .Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha)
                           .FirstOrDefault();
        return adm;
    }

    public Administrador? BuscarPorId(int id)
    {
        return _contexto.Administradores.Find(id);
    }

    public List<Administrador> Todos(int? pagina = 1)
    {
        var query = _contexto.Administradores.AsQueryable();
        int itensPorPagina = 10;
        if (pagina != null)
        {
            query = query.Skip(((int)pagina.Value - 1) * itensPorPagina).Take(itensPorPagina);
        }
        return query.ToList();
    }
    
    public void Atualizar(Administrador administrador)
    {
        _contexto.Administradores.Update(administrador);
        _contexto.SaveChanges();
    }
    public void Apagar(Administrador administrador)
    {
        _contexto.Administradores.Remove(administrador);
        _contexto.SaveChanges();
    }
}
