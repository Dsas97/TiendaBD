using BDTienda.Models;
using BDTienda.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDTienda.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Proveedor()
        {
            List<ListaProveedores> listaProveedores;

            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {
                listaProveedores = db.Proveedor.Select(prov =>
                new ListaProveedores
                {
                    idProv = prov.Id_Prov,
                    nombre = prov.Nombre,
                    direccion = prov.Direccion
                }).ToList();
            }

            return View(listaProveedores);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProveedorNuevo provNuevo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                    {
                        var proveedor = new Proveedor();
                        proveedor.Id_Prov = provNuevo.idProv;
                        proveedor.Nombre = provNuevo.nombre;
                        proveedor.Direccion = provNuevo.direccion;

                        db.Proveedor.Add(proveedor);
                        db.SaveChanges();
                    }
                    return Redirect("~/Proveedor/Proveedor");
                }
                return View(provNuevo);
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int id)
        {
            ProveedorNuevo provEdit = new ProveedorNuevo();
            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {
                var proveedor = db.Proveedor.Find(id);
                provEdit.idProv = proveedor.Id_Prov;
                provEdit.nombre = proveedor.Nombre;
                provEdit.direccion = proveedor.Direccion;

            }
            return View(provEdit);
        }

        [HttpPost]
        public ActionResult Editar(ProveedorNuevo provEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                    {
                        var proveedor = db.Proveedor.Find(provEdit.idProv);
                        proveedor.Id_Prov = provEdit.idProv;
                        proveedor.Nombre = provEdit.nombre;
                        proveedor.Direccion = provEdit.direccion;

                        db.Entry(proveedor).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Proveedor/Proveedor");
                }
                return View(provEdit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                ProveedorNuevo provEdit = new ProveedorNuevo();
                using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                {

                    var proveedor = db.Proveedor.Find(id);
                    db.Proveedor.Remove(proveedor);
                    db.SaveChanges();
                }
                return Redirect("~/Proveedor/Proveedor");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}