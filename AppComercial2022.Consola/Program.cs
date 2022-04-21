using System;
using AppComercial2022.Datos;

namespace AppComercial2022.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    ConexionBd conexionBd = new ConexionBd();
            //    SqlConnection cn = conexionBd.GetConexion();
            //    Console.WriteLine("Conexion establecida");
            //    Console.ReadLine();
            //    conexionBd.CerrarConexion();
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
               
            //}
            TraerListaCategorias();

            Console.ReadLine();
        }

        private static void TraerListaCategorias()
        {
            try
            {
                var repo=new RepositorioCategorias();
                var lista = repo.GetLista();
                foreach (var categoria in lista)
                {
                    Console.WriteLine($"{categoria.CategoriaId} {categoria.NombreCategoria} {categoria.Descripcion}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            Console.ReadLine();
        }
    }
}
