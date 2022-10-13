using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using APIFibra.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIFibra.Data
{
    public class AtivoRepository
    {
        private readonly DataContext _dataContext;

        public AtivoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<PagedList<Ativo>> GetAtivosAsync(AtivoParams ativoParams)
        {
            var query = _dataContext.Ativos.AsQueryable();
            
            // query = query.Where(u => u.Username != userParams.CurrentUsername);
            // query = query.Where(u => u.Gender == userParams.Gender);

            // var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
            // var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

            // query = query.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            
            /*
            query = userParams.OrderBy switch
            {
                "created" => query.OrderByDescending(u => u.Created),
                _ => query.OrderByDescending(u => u.LastActive)
            };
            */

            query = query.OrderByDescending(u => u.Data).ThenBy(u => u.NomeAtivo);

            return await PagedList<Ativo>.CreateAsync(
                query.AsNoTracking(),
                ativoParams.PageNumber, ativoParams.PageSize);
        }
        
        public async Task<Ativo> GetAtivoByIdAsync(int id)
        {
            return await _dataContext.Ativos.FindAsync(id);
        }
        
        public void IncluiAtivo(Ativo ativo)
        {
            _dataContext.Ativos.Add(ativo);
        }
        public void UpdateAtivo(Ativo ativo)
        {
            _dataContext.Entry(ativo).State = EntityState.Modified;
        }
        
        public void DeleteAtivo(Ativo ativo)
        {
            _dataContext.Set<Ativo>().Remove(ativo);
        }
        
        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}