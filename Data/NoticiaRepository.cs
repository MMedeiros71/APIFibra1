using System;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using APIFibra.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFibra.Data
{
    public class NoticiaRepository
    {
        private readonly DataContext _dataContext;

        public NoticiaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<PagedList<Noticia>> GetNoticiasAsync(UserParams userParams)
        {
            var query = _dataContext.Noticias.AsQueryable();
            
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

            query = query.OrderByDescending(u => u.Data);

            return await PagedList<Noticia>.CreateAsync(
                query.AsNoTracking(),
                userParams.PageNumber, userParams.PageSize);
        }
        public async Task<Noticia> GetNoticiaByIdAsync(int id)
        {
            return await _dataContext.Noticias.FindAsync(id);
        }

        public void IncluiNoticia(Noticia noticia)
        {
            _dataContext.Noticias.Add(noticia);
        }
        public void UpdateNoticia(Noticia noticia)
        {
            _dataContext.Entry(noticia).State = EntityState.Modified;
        }

        public void DeleteNoticia(Noticia noticia)
        {
            _dataContext.Set<Noticia>().Remove(noticia);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}