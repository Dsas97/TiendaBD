using BDTienda.Models;
using BDTienda.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDTienda.Controllers
{
    public class ComprasController : Controller
    {
        // GET: Compras
        public ActionResult Compras()
        {
            List<ListaCompras> listaCompras;

            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {
                listaCompras = db.Compras.Select(comp =>
                new ListaCompras
                {
                    idCompra = comp.Id_Compra,
                    idCliente = comp.Id_Cliente,
                    idProducto = comp.Id_Producto
                }).ToList();

            }
            return View(listaCompras);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(CompraNueva compNueva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                    {
                        var compra = new Compras();
                        compra.Id_Cliente = compNueva.idCliente;
                        compra.Id_Producto = compNueva.idProducto;

                        db.Compras.Add(compra);
                        db.SaveChanges();                        
                    }
                    return Redirect("~/Compras/Compras");
                }
                return View(compNueva);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            CompraNueva compraEdit = new CompraNueva();
            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {
                var compras = db.Compras.Find(id);
                compraEdit.idCompra = compras.Id_Compra;
                compraEdit.idCliente = compras.Id_Cliente;
                compraEdit.idProducto = compras.Id_Producto;
                
            }
            return View(compraEdit);
        }

        [HttpPost]
        public ActionResult Editar(CompraNueva compEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                    {
                        var compra = db.Compras.Find(compEdit.idCompra);
                        compra.Id_Compra = compEdit.idCompra;
                        compra.Id_Cliente = compEdit.idCliente;
                        compra.Id_Producto = compEdit.idProducto;
                       
                        db.Entry(compra).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Compras/Compras");
                }
                return View(compEdit);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult CompraRequerida()
        {

            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {

                List<Clientes> clientes = db.Clientes.ToList();
                List<Compras> compras = db.Compras.ToList();
                List<Producto> producto = db.Producto.ToList();

                var consulta = from cli in clientes
                               join com in compras
                               on cli.Id_Cliente equals com.Id_Cliente into table1
                               from com in table1
                               join prod in producto 
                               on com.Id_Producto equals prod.Id_Producto
                               orderby prod.Precio
                               select new CompraCliente
                               {
                                   cliente = cli,
                                   compra = com,
                                   producto = prod
                               };
                return View(consulta);
            }
        }

    }
}