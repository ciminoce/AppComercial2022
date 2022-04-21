using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AppComercial2022.Entidades;

namespace AppComercial2022.Datos
{
    public class RepositorioCategorias
    {
        private readonly ConexionBd conexionBd;

        public RepositorioCategorias()
        {
            conexionBd=new ConexionBd();
        }

        public List<Categoria> GetLista()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                using (var cn=conexionBd.GetConexion())
                {
                    string cadenaComando = "SELECT CategoriaId, NombreCategoria, Descripcion FROM Categorias";
                    SqlCommand comando=new SqlCommand(cadenaComando,cn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        var categoria = ConstruirCategoria(reader);
                        lista.Add(categoria);
                    }
                    reader.Close();
                }

                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Categoria ConstruirCategoria(SqlDataReader reader)
        {
            var categoria=new Categoria();
            categoria.CategoriaId = reader.GetInt32(0);
            categoria.NombreCategoria = reader.GetString(1);
            categoria.Descripcion = reader.GetString(2);
            return categoria;
        }
    }
}
