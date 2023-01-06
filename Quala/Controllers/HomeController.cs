using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quala.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Quala.Controllers
{
    public class HomeController : Controller
    {
        protected string ConnectionString { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<quala> listQualas = ObtenerRegistros();
            return View(listQualas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<quala> ObtenerRegistros()
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=TestDB;Trusted_Connection=True;");
            List<quala> lista = new List<quala>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from InfoQuala", connection as SqlConnection);
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    quala item = new quala();
                    item.id = Convert.ToInt32(reader["id"]);
                    item.descripcion = Convert.ToString(reader["descripcion"]);
                    item.direccion = Convert.ToString(reader["direccion"]);
                    item.identificacion = Convert.ToString(reader["identificacion"]);
                    item.moneda = Convert.ToString(reader["moneda"]);
                    lista.Add(item);
                }
                
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex);
            }
            finally {
                connection.Close();
                connection.Dispose();
            }
            return lista;
        }

        private IActionResult CrearRegistro()
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=TestDB;Trusted_Connection=True;");
            List<quala> lista = new List<quala>();
            try
            {
                connection.Open();
                string query = "insert into InfoQuala values (id, descripcion, direccion, identificacion, moneda) values ({0}, {1}, {2}, {3}, {4})";
                //query = string.Format(query, quala.id, quala.descripcion, quala.direccion, quala.identificacion, quala.moneda);
                SqlCommand command = new SqlCommand(query, connection as SqlConnection);
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    quala item = new quala();
                    item.id = Convert.ToInt32(reader["id"]);
                    item.descripcion = Convert.ToString(reader["descripcion"]);
                    item.direccion = Convert.ToString(reader["direccion"]);
                    item.identificacion = Convert.ToString(reader["identificacion"]);
                    item.moneda = Convert.ToString(reader["moneda"]);
                    lista.Add(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return View();
        }

        private void ModificarRegistro(quala quala)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=TestDB;Trusted_Connection=True;");
            List<quala> lista = new List<quala>();
            try
            {
                connection.Open();
                string query = "update infoquala set id = {0}, descripcion = {1}, direccion = {2}, identificacion = {3}, moneda = {4} where id = {0}";
                query = string.Format(query, quala.id, quala.descripcion, quala.direccion, quala.identificacion, quala.moneda);
                SqlCommand command = new SqlCommand(query, connection as SqlConnection);
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    quala item = new quala();
                    item.id = Convert.ToInt32(reader["id"]);
                    item.descripcion = Convert.ToString(reader["descripcion"]);
                    item.direccion = Convert.ToString(reader["direccion"]);
                    item.identificacion = Convert.ToString(reader["identificacion"]);
                    item.moneda = Convert.ToString(reader["moneda"]);
                    lista.Add(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        private void EliminarRegistro(int id)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=TestDB;Trusted_Connection=True;");
            List<quala> lista = new List<quala>();
            try
            {
                connection.Open();
                string query = "delete * from InfoQuala where id = {0}";
                query = string.Format(query, id);
                SqlCommand command = new SqlCommand(query, connection as SqlConnection);
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    quala item = new quala();
                    item.id = Convert.ToInt32(reader["id"]);
                    item.descripcion = Convert.ToString(reader["descripcion"]);
                    item.direccion = Convert.ToString(reader["direccion"]);
                    item.identificacion = Convert.ToString(reader["identificacion"]);
                    item.moneda = Convert.ToString(reader["moneda"]);
                    lista.Add(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
