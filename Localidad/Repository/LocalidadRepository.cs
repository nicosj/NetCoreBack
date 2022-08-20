using System.Collections.Generic;
using System.Threading.Tasks;
using Localidad.Interfaces;
using Localidad.Models;
using Microsoft.EntityFrameworkCore;

namespace Localidad.Repository
{
    public class LocalidadRepository : ILocalidadRepository
    {
        private readonly  LDbContext _context;
        public LocalidadRepository(LDbContext context)
        {
            _context= context;
        }

        public async Task<Pais> GetPaisAsync(int id)
        {
            return await _context.Pais
                .Include(p => p.Provincia)
                .Include(p => p.Provincia.Depto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Pais>> GetPaissAsync()
        {
            return await _context.Pais
                .Include(p => p.Provincia)
                .Include(p => p.Provincia.Depto)
                .ToListAsync();
        }

        public async Task<Pais> AddPaisAsync(Pais pais)
        {
            _context.Pais.Add(pais);
            await _context.SaveChangesAsync();
            return pais;
        }

        public async Task<Pais> UpdatePaissAsync(Pais pais)
        {
            _context.Update(pais).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pais;
        }

        public async Task<Pais> Delete(int id)
        {
            var local = await _context.Pais.FindAsync(id);
            if (local == null)
            {
                return null;
            }
            _context.Set<Pais>().Remove(local);
            await _context.SaveChangesAsync();
            
            return local;
        }
        
    }
}