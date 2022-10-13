using System.Threading.Tasks;
using APIFibra.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIFibra.Data
{
    public class CotaIndiceRepository
    {
        private readonly DataContext _dataContext;

        public CotaIndiceRepository(DataContext dataContext )
        {
            _dataContext = dataContext;
        }
        
        public async Task<CotaIndice> GetNoticiaByIdAsync()
        {
            return await _dataContext.CotasIndices.FindAsync(1);
        }
        public void IncluiCotaIndice(CotaIndice cotaIndice)
        {
            _dataContext.CotasIndices.Add(cotaIndice);
        }
        
        public void UpdateCotaIndice(CotaIndice cotaIndice)
        {
            _dataContext.Entry(cotaIndice).State = EntityState.Modified;
        }
        
        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
        
        public async Task<int> CotaIndiceCount()
        {
            return await _dataContext.CotasIndices.CountAsync();
        }
    }
}