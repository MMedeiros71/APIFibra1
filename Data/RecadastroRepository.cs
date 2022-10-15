using System.Threading.Tasks;
using APIFibra.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIFibra.Data
{
    public class RecadastroRepository
    {
        private readonly DataContext _dataContext;

        public RecadastroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<Recadastro> GetRecadastroByIdAsync(int numCotista)
        {
            return await _dataContext.Recadastros.AsNoTracking().FirstOrDefaultAsync(x => x.Numcotista == numCotista);
        }
        
        public void IncluiRecadastro(Recadastro recadastro)
        {
            _dataContext.Recadastros.Add(recadastro);
        }
        
        public void UpdateRecadastro(Recadastro recadastro)
        {
            _dataContext.Entry(recadastro).State = EntityState.Modified;
        }
        
        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
        
    }
}