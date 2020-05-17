using CarolineReinatoMVC.Interface;
using CarolineReinatoMVC.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace CarolineReinatoMVC.Repository
{
    public class CargoRepository : ICargoRepository
    {

        public string connectionString = ConfigurationManager.ConnectionStrings["ScuadConnectionString"].ConnectionString;
        public List<Cargo> GetCargos()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Cargo>("Select * From Cargo").ToList();
            }
        }
        public void Select(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Query<Cargo>($"Select * From Cargo Where Id = {id}").SingleOrDefault();
            }
        }
        public void Insert(Cargo cargo)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = $"Insert into Cargo (NomeCargo, StatusAtivo) Values('{cargo.NomeCargo}',1)";
                int rowsAffectes = db.Execute(sqlQuery);
            }
        }
        public void Desativar (int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "Update Cargo set StatusAtivo = 0 Where Id = " + id;
                int rowsAffectes = db.Execute(sqlQuery);
            }
        }
        public void Ativar(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "Update Cargo set StatusAtivo = 1 Where Id = " + id;
                int rowsAffectes = db.Execute(sqlQuery);
            }
        }
    }
}