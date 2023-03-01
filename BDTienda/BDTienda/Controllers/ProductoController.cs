using BDTienda.Models;
using BDTienda.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDTienda.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Producto()
        {
            List<ListaProducto> listaProductos;

            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {
                listaProductos = db.Producto.Select(prod =>
                new ListaProducto
                {
                    idProducto = prod.Id_Producto,
                    Nombre = prod.Nombre,
                    Precio = prod.Precio,
                    idProv = prod.Id_Prov

                }).ToList();
            }

            return View(listaProductos);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductoNuevo prodNuevo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                    {
                        var producto = new Producto();
                        producto.Id_Producto = prodNuevo.idProducto;
                        producto.Id_Prov = prodNuevo.idProv;
                        producto.Nombre = prodNuevo.nombre;
                        producto.Precio = prodNuevo.precio;

                        db.Producto.Add(producto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/Producto");
                }
                return View(prodNuevo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int id)
        {
            ProductoNuevo productEdit = new ProductoNuevo();
            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {
                var producto = db.Producto.Find(id);
                productEdit.idProducto = producto.Id_Producto;
                productEdit.idProv = producto.Id_Prov;
                productEdit.nombre = producto.Nombre;
                productEdit.precio = producto.Precio;
            }
            return View(productEdit);
        }

        [HttpPost]
        public ActionResult Editar(ProductoNuevo prodEditar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                    {
                        var producto = db.Producto.Find(prodEditar.idProducto);
                        producto.Id_Producto = prodEditar.idProducto;
                        producto.Id_Prov = prodEditar.idProv;
                        producto.Nombre = prodEditar.nombre;
                        producto.Precio = prodEditar.precio;

                        db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/Producto");
                }
                return View(prodEditar);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            ProductoNuevo productEliminar = new ProductoNuevo();
            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {
                var producto = db.Producto.Find(id);
                db.Producto.Remove(producto);
                db.SaveChanges();
            }
            return Redirect("~/Producto/Producto");
        }
        // GET: Producto
        public ActionResult ProductoRequerido()
        {
            try
            {
                using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                {

                    List<Producto> productos = db.Producto.ToList();
                    List<Proveedor> proveedors = db.Proveedor.ToList();

                    var consulta = from pro in productos
                                   join prov in proveedors
                                   on pro.Id_Prov equals prov.Id_Prov
                                   select new ProductoProveedor
                                   {
                                       product = pro,
                                       provee = prov
                                   };
                    return View(consulta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}