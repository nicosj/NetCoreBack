using System.Collections.Generic;
using System.Threading.Tasks;
using Localidad.Models;

namespace Localidad.Interfaces
{
    public interface ILocalidadRepository
    {
        Task<Pais> GetPaisAsync(int id);
        Task<IReadOnlyList<Pais>> GetPaissAsync();
        Task <Pais> AddPaisAsync(Pais pais);
        Task <Pais> UpdatePaissAsync(Pais pais);
        Task <Pais> Delete(int id);
    }
}