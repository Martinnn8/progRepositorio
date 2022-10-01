using RecetasSimulacro.Datos_Sql.Interfaces;
using RecetasSimulacro.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSimulacro.Datos_Sql.Implementaciones
{
    internal class RecetaDao : IRecetaDao
    {
        public List<Ingrediente> GetIngredientes()
        {
            List<Ingrediente> lst = new List<Ingrediente>();

            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_INGREDIENTES");

            foreach(DataRow fila in tabla.Rows)
            {
                Ingrediente i = new Ingrediente();

                i.IdIngrediente = (int)fila["Id_ingrediente"];
                i.Nombre = fila["n_ingrediente"].ToString();
                i.Unidad = fila["unidad_medida"].ToString();

                lst.Add(i);
            }

            return lst;
        }

        public int ObtenerProximoNumero()
        {
            return HelperDao.ObtenerInstancia().ConsultarEscalar("SP_PROXIMO_ID", "@next");
        }

        public bool Crear(Receta receta)
        {
            return HelperDao.ObtenerInstancia().CrearMaestroDetalleReceta("SP_INSERTAR_RECETA","SP_INSETAR_DETALLES",receta)
        }

    }
}
