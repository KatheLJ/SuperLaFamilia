using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SuperLaFamiliaDAL.Entidades;

namespace SuperLaFamiliaDAL
{
    public class GestiónBD
    {
        string CadenaConexion;

        public GestiónBD()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["SuperLaFamilia"].ConnectionString;

        }

        //SELECT PRODUCTO
        public async Task<List<Productos>> ObtenerProductosAsync()
        {
            SqlDataReader Resultado;
            List<Productos> ListadoProductos;

            using (SqlConnection objConexion = new SqlConnection(CadenaConexion))
            {
                objConexion.ConnectionString = CadenaConexion;

                SqlCommand objComando = new SqlCommand();
                objComando.Connection = objConexion;
                objComando.CommandType = System.Data.CommandType.Text;
                objComando.CommandText = "SELECT * FROM PRODUCTOS";
                objConexion.Open();
                Resultado = await objComando.ExecuteReaderAsync();
                ListadoProductos = new List<Productos>();
                while (Resultado.Read())
                {
                    Productos objProducto = new Productos();
                    objProducto.ID_Producto = Resultado.GetInt32(0);
                    objProducto.Nombre_Producto = Resultado.GetString(1);
                    objProducto.ID_Marca = Resultado.GetInt32(2);
                    objProducto.ID_Categoría = Resultado.GetInt32(3);
                    objProducto.Fecha_ingreso = Resultado.GetDateTime(4);
                    objProducto.Cantidad = Resultado.GetInt32(5);
                    objProducto.Id_Estado = Resultado.GetInt32(6);
                    objProducto.Precio = Resultado.GetDecimal(7);
                    ListadoProductos.Add(objProducto);
                }
            }
            return ListadoProductos;
        }

        //INSERT PRODUCTO
        public async Task<int> RegistrarProductoAsync(Productos oProducto)
        {
            int Resultado = 0;
            using (SqlConnection objConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand objComando = new SqlCommand();
                objComando.Connection = objConexion;
                objComando.CommandType = System.Data.CommandType.Text;
                objComando.CommandText = "Insert into Producto (NomProducto,MarcaProducto,CostoProducto)" +
                                         "Values (@NomProducto,@MarcaProducto,@CostoProducto)";



                SqlParameter oParametro = new SqlParameter();
                oParametro.ParameterName = "@NomProducto";
                oParametro.SqlDbType = System.Data.SqlDbType.VarChar;
                oParametro.Size = 50;
                oParametro.Value = oProducto.Nombre_Producto;

                objComando.Parameters.Add(oParametro);

                objComando.Parameters.Add(new SqlParameter("@ID_Marca", oProducto.ID_Marca));

                objComando.Parameters.Add(new SqlParameter("@Precio", oProducto.Precio));

                objConexion.Open();
                Resultado = await objComando.ExecuteNonQueryAsync();
                objConexion.Close();

            }

            return Resultado;
        }

        //UPDATE PRODUCTO
        public async Task<int> ActualizarProductoAsync(Productos oProducto, int id)
        {
            int Resultado = 0;
            using (SqlConnection objConexion = new SqlConnection(CadenaConexion))
            {

                SqlCommand objComando = new SqlCommand();
                objComando.Connection = objConexion;
                objComando.CommandType = System.Data.CommandType.Text;
                objComando.CommandText = "Update Producto set Nombre_Producto = @NomProducto, ID_Marca = @MarcaProducto, CostoProducto = @CostoProducto where IdProducto = @IdProducto";


                objComando.Parameters.Add(new SqlParameter("@IdProducto", id));

                SqlParameter oParametro = new SqlParameter();
                oParametro.ParameterName = "@NomProducto";
                oParametro.SqlDbType = System.Data.SqlDbType.VarChar;
                oParametro.Size = 50;
                oParametro.Value = oProducto.Nombre_Producto;
                objComando.Parameters.Add(oParametro);

                objComando.Parameters.Add(new SqlParameter("@ID_Marca", oProducto.ID_Marca));

                objComando.Parameters.Add(new SqlParameter("@Precio", oProducto.Precio));
                objConexion.Open();
                Resultado = await objComando.ExecuteNonQueryAsync();
                objConexion.Close();

            }

            return Resultado;

        }


        public async Task<Productos> ObtenerProductoAsync(int? Id)
        {
            List<Productos> Listado = await ObtenerProductosAsync();
            Productos auxProducto = Listado.Where(x => x.ID_Producto == Id).FirstOrDefault();
            return auxProducto;
        }

        public async Task<int> EliminarProductoAsyn(int Id)
        {
            int resultado = 0;
            using (SqlConnection objConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand objComando = new SqlCommand();
                objComando.Connection = objConexion;
                objComando.CommandType = System.Data.CommandType.Text;
                objComando.CommandText = "Delete from Producto Where IdProducto = @IdProducto";
                objComando.Parameters.Add(new SqlParameter("@IdProducto", Id));
                objConexion.Open();
                resultado = await objComando.ExecuteNonQueryAsync();
                objConexion.Close();
            }

            return resultado;
        }
    }
}
