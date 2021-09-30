using Dapper;
using MySql.Data.MySqlClient;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        public MySQLConfiguration _connectionString { get; set; }

        public PokemonRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString._connectionString);
            // El segundo _connect... Hace referencia al parametro de la clase MySQLConfiguration
        }

        public async Task<bool> DeletePokemon(Pokemon pokemon)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM pokemon WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = pokemon.Id });
            return result > 0;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemon()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM pokemon";

            return await db.QueryAsync<Pokemon>(sql, new { });
        }

        public async Task<Pokemon> GetPokemonDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM pokemon WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Pokemon>(sql, new { Id = id });
        }

        public async Task<bool> InsertPokemon(Pokemon pokemon)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO pokemon (name, type1, type2, generation, imx_location)
                        VALUES (@Name, @Type1 ,@Type1 ,@Generation ,@Imx_location)";

            var result = await db.ExecuteAsync(sql, new { pokemon.Name, pokemon.Type1, pokemon.Type2, pokemon.Generation, pokemon.Imx_location });

            return result > 0;
        }

        public async Task<bool> UpdatePokemon(Pokemon pokemon)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE pokemon
                        SET name = @Name , type1 = @Type1, type2 = @Type2, generation = @Generation, imx_location = @Imx_location
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { pokemon.Name, pokemon.Type1, pokemon.Type2, pokemon.Generation, pokemon.Imx_location, pokemon.Id});

            return result > 0;
        }
    }
}
