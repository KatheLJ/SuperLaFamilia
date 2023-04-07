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
    public class HomeController : Controller
    {
        GestiónBD objGestionBD;

        // GET: Productos

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {
            
            return View();
        }

        public ActionResult Login()
        {
            
            return View();
        }



        //Accion que valide los datos y permite o deniega el ingreso al usuario
        public ActionResult InicioSesion()
        {
           /* if (ModelState.IsValid)
            {
                using (SoportePatitosEntities ContextoBD = new SoportePatitosEntities())
                {
                    var user = ContextoBD.Empleado.FirstOrDefault(a => a.Usuario.Equals(pEmpleado.Usuario) &&
                    a.Contraseña.Equals(pEmpleado.Contraseña));

                    if (user != null)
                    {
                        // Si se encuentra el usuario, se establecen las variables de sesión correspondientes
                        if (user.ID_perfil == 1)
                        {
                            Session["Gerencia"] = user.Usuario;
                        }
                        else if (user.ID_perfil == 2)
                        {
                            Session["RH"] = user.Usuario;
                        }
                        else if (user.ID_perfil == 3)
                        {
                            Session["Empleado"] = user.Usuario;
                        }

                        Session["Cedula"] = user.Cedula;
                        Session["Nombre"] = user.Nombre_Empleado;

                        // Redireccionar al usuario a la página de inicio
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
           */
            // Si no se encuentra el usuario, redireccionar a la página de registro
            return RedirectToAction("Login", "Home");
        }






    }



   

}