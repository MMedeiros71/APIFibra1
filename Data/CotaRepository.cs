using System.Threading.Tasks;
using APIFibra.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIFibra.Data
{
    public class CotaRepository
    {
        private readonly DataContext _dataContext;

        public CotaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<Cota> GetCotaByIdAsync(int numCotista)
        {
            return await _dataContext.Cotas.AsNoTracking().FirstOrDefaultAsync(x => x.Numcotista == numCotista);
        }
        
        public void IncluiCota(Cota cota)
        {
            _dataContext.Cotas.Add(cota);
        }
        
        public void UpdateCota(Cota cota)
        {
            _dataContext.Entry(cota).State = EntityState.Modified;
        }
        
        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
        
    }
}