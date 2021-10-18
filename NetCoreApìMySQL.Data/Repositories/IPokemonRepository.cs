using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data.Repositories
{
    public interface IPokemonRepository
    {
        // Interface para el repositorio
        Task<IEnumerable<Pokemon>> GetAllPokemon();
        Task<Pokemon> GetPokemonDetails (int id);
        Task<bool> InsertPokemon (Pokemon car);
        Task<bool> UpdatePokemon (Pokemon car);
        Task<bool> DeletePokemon (Pokemon car);
    }
}
