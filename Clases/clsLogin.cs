using Examen_3.Models;
using Servicios_Jue.Clases;
using System.Collections.Generic;
using System.Linq;
using System;

public class clsLogin
{
    private NatilleraEntities2 dbSuper = new NatilleraEntities2();
    public Login login { get; set; }
    private LoginRespuesta logRpta;

    private bool ValidarAdministrador()
    {
        try
        {
            // Validación simple: texto plano
            Administrador admin = dbSuper.Administradors.FirstOrDefault(a => a.Usuario == login.Usuario);

            if (admin == null)
            {
                logRpta = new LoginRespuesta();
                logRpta.Mensaje = "Administrador no existe";
                return false;
            }

            if (admin.Clave != login.Clave)
            {
                logRpta = new LoginRespuesta();
                logRpta.Mensaje = "Clave incorrecta";
                return false;
            }

            // Validación exitosa
            return true;
        }
        catch (Exception ex)
        {
            logRpta = new LoginRespuesta();
            logRpta.Mensaje = ex.Message;
            return false;
        }
    }

    public IQueryable<LoginRespuesta> Ingresar()
    {
        if (ValidarAdministrador())
        {
            string token = TokenGenerator.GenerateTokenJwt(login.Usuario);

            return from A in dbSuper.Set<Administrador>()
                   where A.Usuario == login.Usuario && A.Clave == login.Clave
                   select new LoginRespuesta
                   {
                       Usuario = A.Usuario,
                       Autenticado = true,
                       Token = token,
                       Perfil = "Administrador",  // Puedes cambiar esto si tienes roles
                       PaginaInicio = "/eventos", // Página inicial sugerida
                       Mensaje = "Administrador autenticado",
                   };
        }
        else
        {
            return new List<LoginRespuesta>
            {
                new LoginRespuesta
                {
                    Usuario = login.Usuario,
                    Autenticado = false,
                    Token = null,
                    Perfil = null,
                    PaginaInicio = null,
                    Mensaje = logRpta.Mensaje
                }
            }.AsQueryable();
        }
    }
}
