using Loja.DAL;
using Loja.DTO;
using System;
using System.Collections.Generic;

namespace Loja.BLL
{
    public class UsuarioBLL
    {
        public IList<usuario_DTO> CargaUsuario()
        {
            try
            {
                return new UsuarioDAL().CargaUsuario();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int InsereUsuario(usuario_DTO USU)
        {
            try
            {
                return new UsuarioDAL().InsereUsuario(USU);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public int EditaUsuario(usuario_DTO USU)
        {
            try
            {
                return new UsuarioDAL().EditaUsuario(USU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeletaUsuario(usuario_DTO USU)
        {
            try
            {
                return new UsuarioDAL().DeletaUsuario(USU);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
