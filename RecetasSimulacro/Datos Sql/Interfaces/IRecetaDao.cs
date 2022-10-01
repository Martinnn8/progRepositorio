using RecetasSimulacro.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSimulacro.Datos_Sql.Interfaces
{
     interface IRecetaDao  // solo contienen metodos
     {
        int ObtenerProximoNumero();

        List<Ingrediente> GetIngredientes();

        bool Crear(Receta receta);  
     }
}
