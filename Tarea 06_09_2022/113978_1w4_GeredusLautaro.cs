using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tienda_Ropa
{
    internal class ConexionDB
    {

        // EJEMPLO

        private void updateData()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaDeConexion"].ConnectionString))
            {
                try
                {
                    conn.Open();

                    sqlDa = new SqlDataAdapter("select ED.EmeDetalle_Id AS ID_DETALLE, ED.EmeDetalle_MaestroId AS ID_EMERGENCIA, " +
                    "ED.Emedetalle_GastoId AS ID_GASTO, ED.EmeDetalle_TipoGastoId AS ID_TIPOGASTO, " +
                    "GA.Descripcion AS Gasto, TG.Descripcion As TipoGasto, ED.EmeDetalle_PU_Ars as Precio, " +
                    "ED.EmeDetalle_Cantidad as Cantidad, SUM((ED.EmeDetalle_PU_Ars*ED.EmeDetalle_Cantidad)) as SubTotal " +
                    "from dbo.tblEmergencias_Detalles  AS ED " +
                    "INNER JOIN  dbo.tblGastos_Ars AS GA ON ED.Emedetalle_GastoId=GA.ID_GASTO " +
                    "INNER JOIN dbo.tblGastos_Tipos AS TG ON ED.EmeDetalle_TipoGastoId=TG.ID_TipoGasto " +
                    "WHERE ED.EmeDetalle_MaestroId= " + 365 + " group by ED.EmeDetalle_Id, " +
                    "ED.EmeDetalle_MaestroId, ED.Emedetalle_GastoId, ED.EmeDetalle_TipoGastoId, GA.Descripcion, " +
                    "TG.Descripcion, ED.EmeDetalle_PU_Ars, ED.EmeDetalle_Cantidad", conn);

                    //DataSet
                    dSet = new DataSet();
                    //fill the dataset
                    sqlDa.Fill(dSet, "DetalleEme");

                    //Bind the datagrid with the dataset
                    dataGridView1.DataSource = dSet.Tables["DetalleEme"];

                    //build the select command
                    SqlCommand selCmd = new SqlCommand("select * from tblEmergencias_Detalles where EmeDetalle_MaestroId = "
                        + 365 + "order by EmeDetalle_Id", conn);
                    sqlDa.SelectCommand = selCmd;

                    //build insert command
                    SqlCommand insCmd = new SqlCommand("insert into tblEmergencias_Detalles (EmeDetalle_TipoGastoId, Emedetalle_GastoId, " +
                        "EmeDetalle_PU_Ars, EmeDetalle_Cantidad) values (@TipoGastoId, @GastoId, @PU_Ars, @Cantidad)", conn);
                    sqlDa.InsertCommand = insCmd;

                    //update command
                    SqlCommand upCmd = new SqlCommand("update tblEmergencias_Detalles set EmeDetalle_TipoGastoId=@paramTipoGastoId, " +
                    "Emedetalle_GastoId=@paramGastoId, EmeDetalle_PU_Ars=@paramPUArs, EmeDetalle_Cantidad=@paramCantidad, " +
                    "WHERE EmeDetalle_Id=@paramId", conn);
                    //Parameters
                    upCmd.Parameters.Add("@paramTipoGastoId", SqlDbType.Int, 5, "EmeDetalle_TipoGastoId");
                    upCmd.Parameters.Add("@paramGastoId", SqlDbType.Int, 4, "Emedetalle_GastoId");
                    upCmd.Parameters.Add("@paramPUArs", SqlDbType.Decimal, 4, "EmeDetalle_PU_Ars");
                    upCmd.Parameters.Add("@paramCantidad", SqlDbType.Int, 3, "EmeDetalle_Cantidad");
                    sqlDa.UpdateCommand = upCmd;

                    //Delete command
                    SqlCommand delCmd = new SqlCommand("delete from tblEmergencias_Detalles where EmeDetalle_Id=@paramId", conn);
                    delCmd.Parameters.Add("@paramId", SqlDbType.Int, 5, "EmeDetalle_Id");

                    //Update the data adapter
                    sqlDa.Update(dSet, "DetalleEme");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }

        public class Persona
        {
            //Propiedades
            public string Nombre { get; set; }
            public string ApellidoPat { get; set; }
            public string ApellidMat { get; set; }
            public string TipoDocument { get; set; }
            public string Correo { get; set; }
            public bool Vigencia { get; set; }
            //Asignar el constructor por
            //defecto para que no genere error
            //de argumentos
            public Persona()
            {
            }
            //Constructor que recibe parámetro de la misma clase
            public Persona(Persona Add)
            {
                Nombre = Add.Nombre;
                ApellidoPat = Add.ApellidoPat;
                ApellidMat = Add.ApellidMat;
                TipoDocument = Add.TipoDocument;
                Correo = Add.Correo;
                Vigencia = Add.Vigencia;
            }
        }



    }
}
