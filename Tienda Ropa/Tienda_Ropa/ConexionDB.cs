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
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lectura;

        string alojamiento;

        public ConexionDB ()
        {
            alojamiento = @"Data Source=DESKTOP-H8HNC0D;Initial Catalog=TiendaRopa;Integrated Security=True";
            conexion = new SqlConnection(alojamiento);
            comando = new SqlCommand();
        }

        public void Conectar()
        {
            conexion.Open();

            comando.Connection = conexion;    // Para que los comandos se ejecuten atra vez de la conexion sql

            comando.CommandType = System.Data.CommandType.Text;     // Para que los comandos sean de forma de texto

        }

        public void Desconectar()
        {
            conexion.Close();
        }

        public System.Data.DataTable ConsultasDB(string sentenciasql)    // Es un metodo de tipo tabla asi que retorna una tabla
        {
            System.Data.DataTable tabla = new System.Data.DataTable();

            Conectar();

            comando.CommandText = sentenciasql;

            tabla.Load(comando.ExecuteReader());     // Para que se cargue, lea y ejecute la sentencia sql que va a entrar en el metodo

            Desconectar();

            return tabla;
        }


        public int ActualizarDB(string sentenciasql)   // Devuelve un numero entero de las filas afectadas o alteradas
        {
            int filasAfectadas;

            Conectar();

            comando.CommandText = sentenciasql;

            filasAfectadas = comando.ExecuteNonQuery();    // Operador que procesa enteros

            Desconectar();

            return filasAfectadas;
        }

    }
}
