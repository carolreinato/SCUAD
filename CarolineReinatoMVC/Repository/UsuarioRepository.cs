using CarolineReinatoMVC.Interface;
using CarolineReinatoMVC.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarolineReinatoMVC.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["ScuadConnectionString"].ConnectionString;
        public void Ativar(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "Update Usuario set StatusAtivo = 1 Where Id = " + id;
                int rowsAffectes = db.Execute(sqlQuery);
            }
        }

        public void Desativar(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "Update Usuario set StatusAtivo = 0 Where Id = " + id;
                int rowsAffectes = db.Execute(sqlQuery);
            }
        }

        public List<Usuario> GetUsuarios()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Usuario>("Select u.IdCargo, u.Nome, u.StatusAtivo, c.NomeCargo From Usuario u inner join Cargo c on u.IdCargo = c.Id").ToList();
            }
        }

        public void Insert(Usuario usuario)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = $"Insert into Usuario (IdCargo, Nome, StatusAtivo) Values('{usuario.IdCargo}','{usuario.Nome}',1)";
                int rowsAffectes = db.Execute(sqlQuery);
            }
        }

        public void Select(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Query<Cargo>($"Select * From Usuario Where Id = {id}").SingleOrDefault();
            }
        }
        public List<Cargo> DropDownCargos()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Cargo>("Select * From Cargo").ToList();
            }
        }
    }
}