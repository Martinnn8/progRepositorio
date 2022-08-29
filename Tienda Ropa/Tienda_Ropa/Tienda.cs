using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Ropa
{
    internal class Tienda
    {
        private int codigo;
        private int precio;
        private int marca;
        private int tipo;
        private DateTime fecha_ingreso;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public int Precio
        {
            set { precio = value; }
            get { return precio; }
        }

        public int Marca
        {
            set { marca = value; }
            get { return marca; }
        }

        public int Tipo
        {
            set { tipo = value; }
            get { return tipo; }
        }

        public DateTime Fecha_ingreso
        {
            set { fecha_ingreso = value; }
            get { return fecha_ingreso; }
        }

        public Tienda()
        {
            codigo = 0;
            precio = 0;
            marca = 0;
            tipo = 0;
            fecha_ingreso = DateTime.Today;   
        }

        public Tienda (int codigo, int precio, int marca, int tipo, DateTime fecha_ingreso)
        {
            this.codigo = codigo;
            this.precio = precio;
            this.marca = marca;
            this.tipo = tipo;
            this.fecha_ingreso = fecha_ingreso;
        }

        public override string ToString()
        {
            return codigo + " / " + precio;
        }

    }
}
