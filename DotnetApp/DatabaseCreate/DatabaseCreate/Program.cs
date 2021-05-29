using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Npgsql;
using Flurl;
using Flurl.Http;

namespace DatabaseCreate
{
    class Program
    {
        private const string ConnectionString =
            "Host=localhost;Port=5432;User ID=teddyzxcv;Password=1234;Database=postgres;";

        static NpgsqlConnection db;

        static async Task Main(string[] args)
        {
            Console.WriteLine("hello!");
            await Task.Delay(3000);
            db = new NpgsqlConnection(ConnectionString);
            await CreateTable();
            var res = await "https://restcountries.eu/rest/v2/all".GetJsonAsync<List<Country>>();
            Console.WriteLine(res.ToString());
            List<Country> countries = (List<Country>)res;
            foreach (var VARIABLE in countries)
            {
                await db.QueryAsync(
                    $"insert into public.COUNTRIES (NAME,topLevelDomain,alpha2Code,alpha3Code,callingCodes,capital,region,subregion,population,timezones) values (@NAME,@topLevelDomain,@alpha2Code,@alpha3Code,@callingCodes,@capital,@region,@subregion,@population,@timezones);",
                    new
                    {
                        NAME = VARIABLE.Name, topLevelDomain = VARIABLE.topLevelDomain,
                        alpha2Code = VARIABLE.alpha2Code, alpha3Code = VARIABLE.alpha3Code,
                        callingCodes = VARIABLE.callingCodes, capital = VARIABLE.capital, region = VARIABLE.region,
                        subregion = VARIABLE.subregion, population = VARIABLE.population, timezones = VARIABLE.timezones
                    });
            }
        }

        static async Task CreateTable()
        {
            var query =
                @"CREATE TABLE public.COUNTRIES(
                   ID SERIAL PRIMARY KEY     NOT NULL,
                   NAME          TEXT       NOT NULL,
                   topLevelDomain        TEXT[],
                   alpha2Code         TEXT,
                   alpha3Code         TEXT,
                   callingCodes TEXT[],
                   capital  TEXT,
                   region TEXT,
                   subregion TEXT,
                   population REAL,
                   timezones TEXT[]
                );";

            await db.QueryAsync(
                new CommandDefinition(
                    query
                ));
        }
    }

    class Country
    {
        [JsonProperty("name")] public string Name;
        public string[] topLevelDomain;
        public string alpha2Code;
        public string alpha3Code;
        public string[] callingCodes;
        public string capital;
        public string region;
        public string subregion;
        public int population;
        public List<string> timezones = new List<string>();
    }
}