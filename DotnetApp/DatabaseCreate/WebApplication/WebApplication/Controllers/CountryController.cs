using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Npgsql;
using Flurl;
using Flurl.Http;
using System.Linq;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        static NpgsqlConnection db =
            new NpgsqlConnection("Host=localhost;Port=5432;User ID=teddyzxcv;Password=1234;Database=postgres;");


        private readonly ILogger<CountryController> _logger;

        public CountryController(ILogger<CountryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("AllCountry")]
        public IEnumerable<string> GetAllCountry()
        {
            db.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT name FROM countries", db);
            NpgsqlDataReader dr = command.ExecuteReader();
            // Output rows
            List<string> output = new List<string>();
            while (dr.Read())
                output.Add((string) dr[0]);
            db.Close();
            return output;
        }

        [HttpGet("CountryByName")]
        public IEnumerable<Country> GetCountryByName(string name)
        {
            db.Open();
            NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM countries WHERE name = '{name}'", db);
            NpgsqlDataReader dr = command.ExecuteReader();
            // Output rows
            List<Country> output = new List<Country>();
            while (dr.Read())
            {
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine(i + ": " + dr[i]);
                }

                Country newCountry = new Country((string) dr[1], (string[]) dr[2], (string) dr[3], (string) dr[4],
                    (string[]) dr[5], (string) dr[6], (string) dr[7], (string) dr[8], Convert.ToInt32(dr[9]),
                    ((string[]) dr[10]).ToList());
                output.Add(newCountry);
            }

            db.Close();
            return output;
        }
        [HttpGet("AllRegion")]
        public IEnumerable<string> GetRegion()
        {
            db.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT region FROM countries", db);
            NpgsqlDataReader dr = command.ExecuteReader();
            // Output rows
            List<string> output = new List<string>();
            while (dr.Read())
                output.Add((string) dr[0]);
            db.Close();
            return output;
        }
        [HttpGet("GetRegionByName")]
        public IEnumerable<Country> GetRegionByName(string regionname)
        {
            db.Open();
            NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM countries WHERE region = '{regionname}'", db);
            NpgsqlDataReader dr = command.ExecuteReader();
            // Output rows
            List<Country> output = new List<Country>();
            while (dr.Read())
            {
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine(i + ": " + dr[i]);
                }

                Country newCountry = new Country((string) dr[1], (string[]) dr[2], (string) dr[3], (string) dr[4],
                    (string[]) dr[5], (string) dr[6], (string) dr[7], (string) dr[8], Convert.ToInt32(dr[9]),
                    ((string[]) dr[10]).ToList());
                output.Add(newCountry);
            }

            db.Close();
            return output;
        }
    }
}