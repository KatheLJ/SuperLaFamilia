using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLaFamiliaDAL.Entidades
{
    public class Producto
    {

        public int Id_Producto { get; set; }

        public string Nombre_Producto { get; set; }

        public int Id_Marca { get; set; }

        public int ID_Categoría { get; set; }


        public DateTime Fecha_ingreso { get; set; }

        public int Cantidad { get; set; }



        public int Id_Estado { get; set; }

        public decimal Precio { get; set; }



    }
}
