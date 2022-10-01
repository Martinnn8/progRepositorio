using RecetasSimulacro.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSimulacro.Datos_Sql
{
    class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection conecc;

        private HelperDao()
        {
            conecc = new SqlConnection(@"Data Source=localhost;Initial Catalog=ParcialRecetas;Integrated Security=True");
        }

        public static HelperDao ObtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        public int ConsultarEscalar(string SP, string paramOut)
        {
            int aux;

            try
            {
                conecc.Open();
                SqlCommand comando = new SqlCommand(SP, conecc);
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = paramOut;
                pOut.Direction = ParameterDirection.Output;
                pOut.DbType = DbType.Int32;

                comando.Parameters.Add(pOut);
                comando.ExecuteNonQuery();

                conecc.Close();

                aux = (int)pOut.Value;
            }
            catch(Exception ex)
            {
                aux = 1;
            }
            return aux;
        }


        public DataTable Consultar(string SP)
        {
            DataTable tabla = new DataTable();

            conecc.Open();

            SqlCommand comando = new SqlCommand(SP, conecc);
            comando.CommandType = CommandType.StoredProcedure;

            tabla.Load(comando.ExecuteReader());

            conecc.Close();

            return tabla;
        }


        public bool CrearMaestroDetalleReceta(string spMaestro, string spDetalle, Receta receta)
        {
            bool aux = false;

            SqlTransaction t = null;

            try
            {
                conecc.Open();
                t = conecc.BeginTransaction();  // transaccion iniciada

                SqlCommand comando = new SqlCommand(spMaestro,conecc,t);  // transaccion + comando
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_receta",receta.TipoReceta);
                comando.Parameters.AddWithValue("@cheff",receta.Cheff);
                comando.Parameters.AddWithValue("@nombre",receta.Nombre);

                //salida

                SqlParameter paramOut = new SqlParameter();
                paramOut.ParameterName = "@id";
                paramOut.Direction = ParameterDirection.Output;
                paramOut.DbType = DbType.Int32;

                comando.Parameters.Add(paramOut);

                comando.ExecuteNonQuery();

                int idReceta = (int)paramOut.Value;

                SqlCommand comanD = null;

                foreach(DetalleReceta var in receta.Detalles)
                {
                    comanD = new SqlCommand(spDetalle,conecc,t);
                    comanD.CommandType = CommandType.StoredProcedure;
                    comanD.Parameters.AddWithValue("@id_receta",idReceta);
                    comanD.Parameters.AddWithValue("@id_ingrediente",var.Ingrediente.IdIngrediente);
                    comanD.Parameters.AddWithValue("@cantidad",var.Cantidad);

                    comanD.ExecuteNonQuery();
                }

                t.Commit();
                aux = true;

            }
            catch (Exception ex)
            {
                if(t != null)
                {
                    t.Rollback();
                }
            }
            finally
            {
                if(conecc != null && conecc.State == ConnectionState.Open)
                {
                    conecc.Close();
                }
            }

            return aux;

        }


    }

}

    

