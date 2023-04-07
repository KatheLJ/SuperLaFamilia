using SuperLaFamiliaDAL.Entidades;
using SuperLaFamiliaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;




namespace SuperLaFamilia.Controllers
{
    public class ProductosController : Controller
    {
        GestiónBD objGestiónBD;

        // GET: Productos

        //Permite mostrar un listado de los Productos que hay en el sistema
        public async Task<ActionResult> List()
        {
            objGestiónBD = new GestiónBD();
            List<Productos> Listado = await objGestiónBD.ObtenerProductosAsync();

            return View(Listado);
        }



        public ActionResult IngresarProductos()
        {
           
            return View();
        }


        // GET
        // Ver los detalles de un producto
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            objGestiónBD = new GestiónBD();
            Productos auxProductos = await objGestiónBD.ObtenerProductoAsync(id);
            if (auxProductos == null)
            {
                return HttpNotFound();
            }


            return View(auxProductos);
        }



        // GET
        // Formulario para el ingreso del producto
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enviar Producto 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnviarProducto(FormCollection collection)
        {
            try
            {
                objGestiónBD = new GestiónBD();
                Productos oProductos = new Productos();
                oProductos.Nombre_Producto = collection["NomProductos"];
                oProductos.ID_Marca = Convert.ToInt32(collection["MarcaProductos"]);
                oProductos.Precio = Convert.ToDecimal(collection["CostoProductos"]);
                int resulta = await objGestiónBD.RegistrarProductoAsync(oProductos);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            objGestiónBD = new GestiónBD();
            Productos obj = new Productos();
            obj = await objGestiónBD.ObtenerProductoAsync(id);
            return View(obj);

        }

        // POST: Productos/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                objGestiónBD = new GestiónBD();
                Productos auxProductos = new Productos();
                auxProductos.Nombre_Producto = collection["NomProductos"];
                auxProductos.ID_Marca = Convert.ToInt32(collection["MarcaProductos"]);
                auxProductos.Precio = Convert.ToDecimal(collection["CostoProductos"]);
                int resulta = await objGestiónBD.ActualizarProductoAsync(auxProductos, id);
                return RedirectToAction("Index");

            }
            catch
            {

                return View();
            }
        }

        // GET: Productos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            objGestiónBD = new GestiónBD();
            Productos auxProductos = await objGestiónBD.ObtenerProductoAsync(id);
            if (auxProductos == null)
            {
                return HttpNotFound();
            }


            return View(auxProductos);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAplicar(int id)
        {
            try
            {
                objGestiónBD = new GestiónBD();
                await objGestiónBD.EliminarProductoAsyn(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}