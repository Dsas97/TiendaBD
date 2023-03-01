using BDTienda.Models;
using BDTienda.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDTienda.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cliente()
        {
            List<ListaCliente> listaClientes;

            using (TIENDA_BDEntities db =  new TIENDA_BDEntities())
            {
                listaClientes = db.Clientes.Select(cli => 
                new ListaCliente
                {
                    idCliente = cli.Id_Cliente,
                    nombreCompleto = cli.Nombre + " " + cli.Apellidos,
                    direccion = cli.Direccion,
                    telefono = cli.telefono

                }).ToList(); 
            }

            return View(listaClientes);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ClienteNuevo cliNuevo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                    {
                        var cliente = new Clientes();
                        cliente.Id_Cliente = cliNuevo.idCliente;
                        cliente.Nombre = cliNuevo.nombre;
                        cliente.Apellidos = cliNuevo.apellidos;
                        cliente.Direccion = cliNuevo.direccion;
                        cliente.telefono = cliNuevo.telefono;

                        db.Clientes.Add(cliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Cliente");
                }
                return View(cliNuevo);
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            ClienteNuevo clientEdit = new ClienteNuevo();
            using (TIENDA_BDEntities db = new TIENDA_BDEntities())
            {
                var cliente = db.Clientes.Find(id);
                clientEdit.idCliente = cliente.Id_Cliente;
                clientEdit.nombre = cliente.Nombre;
                clientEdit.apellidos = cliente.Apellidos;
                clientEdit.direccion = cliente.Direccion;
                clientEdit.telefono = cliente.telefono;
            }
            return View(clientEdit);
        }

        [HttpPost]
        public ActionResult Editar(ClienteNuevo cliEditar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                    {
                        var cliente = db.Clientes.Find(cliEditar.idCliente);
                        cliente.Id_Cliente = cliEditar.idCliente;
                        cliente.Nombre = cliEditar.nombre;
                        cliente.Apellidos = cliEditar.apellidos;
                        cliente.Direccion = cliEditar.direccion;
                        cliente.telefono = cliEditar.telefono;

                        db.Entry(cliente).State= System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Cliente");
                }
                return View(cliEditar);

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
                ClienteNuevo clientEdit = new ClienteNuevo();
                using (TIENDA_BDEntities db = new TIENDA_BDEntities())
                {

                    var cliente = db.Clientes.Find(id);
                    db.Clientes.Remove(cliente);
                    db.SaveChanges();
                }
                return Redirect("~/Cliente/Cliente");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }
    }
}