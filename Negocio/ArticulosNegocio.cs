using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using static System.Net.WebRequestMethods;

namespace Tp2_Programacion
{
    public class ArticulosNegocio
    {
        public int contRegistros()
        {
            int contRegistros = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    contRegistros++;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return contRegistros;
        }
        public List<Articulo> listarconSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
    
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                int indiceColumnaCategoria = datos.Lector.GetOrdinal("idCategoria");
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.Lector["id"];
                    aux._codArticulo = (string)datos.Lector["Codigo"];
                    aux._nombre = (string)datos.Lector["Nombre"];
                    aux._descripcion = (string)datos.Lector["Descripcion"];
                    aux._marca = new Marca();
                    aux._marca._nombre = (string)datos.Lector["Marca"];
                    aux._marca._idMarca = (int)datos.Lector["idMarca"];
                    aux._categoria = new Categoria();

                    if (!datos.Lector.IsDBNull(indiceColumnaCategoria))
                    {
                        aux._categoria._descripcion = (string)datos.Lector["Categoria"];
                        aux._categoria._idCategoria = (int)datos.Lector["idCategoria"];
                        aux.urlImagen = (string)datos.Lector["imagenurl"];
                        aux._precio = (float)datos.Lector.GetDecimal(8);
                    }
                    else
                    {
                        aux._categoria._descripcion = "no disponible";
                        aux._categoria._idCategoria = 0;
                        aux.urlImagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_txxCgoGFnihbdmhtwePTHURvJbXXnRkN9g&usqp=CAU";
                        aux._precio = (float)datos.Lector.GetDecimal(8);

                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public List<Marca> listarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Descripcion, Id from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux._nombre = (string)datos.Lector["Descripcion"];
                    aux._idMarca = (int)datos.Lector["Id"];
            
                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public List<Categoria> listarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Descripcion, Id from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux._descripcion = (string)datos.Lector["Descripcion"];
                    aux._idCategoria = (int)datos.Lector["Id"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


        public void Agregar(Articulo nuevo)
        {
			AccesoDatos datos = new AccesoDatos();
            
			try
			{
				datos.setearConsulta("INSERT into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)values('"+ nuevo._codArticulo +"', '"+ nuevo._nombre +"','"+ nuevo._descripcion + "', @idMarca, @idCategoria, "+ nuevo._precio+")");
                datos.setearParametro("@idMarca", nuevo._marca._idMarca);
                datos.setearParametro("@idCategoria", nuevo._categoria._idCategoria);

                datos.ejecutarAccion();

			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }

        public void Modificar(Articulo modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set  Codigo = @codArticulo, Nombre = @nombre, Descripcion = @descripcion, IdMarca= @idMarca,IdCategoria = @idCategoria, Precio =@precio where Id= @id");
                datos.setearParametro("@codArticulo", modificado._codArticulo);
                datos.setearParametro("@nombre", modificado._nombre);
                datos.setearParametro("@descripcion", modificado._descripcion);
                datos.setearParametro("@idMarca",modificado._marca._idMarca);
                datos.setearParametro("@idCategoria", modificado._categoria._idCategoria);
                datos.setearParametro("@precio", modificado._precio);
                datos.setearParametro("@id", modificado.ID);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

        public void Eliminar(int idEliminado)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id=@id");
                datos.setearParametro("@id", idEliminado);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.id,a.Codigo,a.Descripcion, a.Nombre,c.Id as 'idCategoria',c.Descripcion as 'Categoria',m.Id as 'idMarca', m.Descripcion as 'Marca', a.Precio, i.imagenurl from ARTICULOS a left join categorias c on c.Id = a.IdCategoria INNER join MARCAS m on m.Id = a.IdMarca inner join imagenes i on i.id = a. id And ";
                if (campo == "Marca") {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "m.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "m.Descripcion like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "m.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if(campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }



                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                int indiceColumnaCategoria = datos.Lector.GetOrdinal("idCategoria");
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.Lector["id"];
                    aux._codArticulo = (string)datos.Lector["Codigo"];
                    aux._nombre = (string)datos.Lector["Nombre"];
                    aux._descripcion = (string)datos.Lector["Descripcion"];
                    aux._marca = new Marca();
                    aux._marca._nombre = (string)datos.Lector["Marca"];
                    aux._marca._idMarca = (int)datos.Lector["idMarca"];
                    aux._categoria = new Categoria();

                    if (!datos.Lector.IsDBNull(indiceColumnaCategoria))
                    {
                        aux._categoria._descripcion = (string)datos.Lector["Categoria"];
                        aux._categoria._idCategoria = (int)datos.Lector["idCategoria"];
                        aux.urlImagen = (string)datos.Lector["imagenurl"];
                        aux._precio = (float)datos.Lector.GetDecimal(8);
                    }
                    else
                    {
                        aux._categoria._descripcion = "no disponible";
                        aux._categoria._idCategoria = 0;
                        aux.urlImagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_txxCgoGFnihbdmhtwePTHURvJbXXnRkN9g&usqp=CAU";
                        aux._precio = (float)datos.Lector.GetDecimal(8);

                    }

                    lista.Add(aux);
                }
                
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
