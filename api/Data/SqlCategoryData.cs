using enjoymusic_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enjoymusic_project.Data
{
    public class SqlCategoryData : ICategoryData
    {
        private readonly EnjoyMusicDBContext db;

        public SqlCategoryData(EnjoyMusicDBContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            var query = await db.Categories.FromSqlRaw("exec sp_getAllCategory").ToListAsync();
            return query;
        }
    }
}
