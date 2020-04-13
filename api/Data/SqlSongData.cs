using enjoymusic_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enjoymusic_project.Data
{
    public class SqlSongData : ISongData
    {
        private readonly EnjoyMusicDBContext db;

        public SqlSongData(EnjoyMusicDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            var query = await db.Song.FromSqlRaw("exec sp_getAll").ToListAsync();
            return query;
        }
        public Song GetById(string id)
        {
            var parseString = id.Split("-");
            int parsedId = Int32.Parse(parseString[parseString.Length - 1]);

            var query = from s in db.Song
                        where s.id == parsedId
                        select s;
            return query.ElementAt(0);
        }
        public async Task<IEnumerable<Song>> GetTopListen()
        {
            var query = await db.Song.FromSqlRaw("exec sp_topListen").ToListAsync();
            return query;
        }
        public async Task<IEnumerable<Song>> GetTopDownLoad()
        {
            var query = await db.Song.FromSqlRaw("exec sp_topDownload").ToListAsync();
            return query;
        }
        public async Task<IEnumerable<Song>> GetTopRate()
        {
            var query = await db.Song.FromSqlRaw("exec sp_topRate").ToListAsync();
            return query;
        }
        public async Task<IEnumerable<Song>> GetNewComment()
        {
            var query = await db.Song.FromSqlRaw("exec sp_newComment").ToListAsync();
            return query;
        }
        public async Task<IEnumerable<Song>> GetByCategory(string category)
        {
            var query = await db.Song.FromSqlRaw("exec sp_GetSongByCategory {0}",category).ToListAsync();
            return query;
        }
        public async Task<IEnumerable<Song>> GetBySinger(string singer)
        {
            var query = await db.Song.FromSqlRaw("exec sp_GetBySinger {0}", singer).ToListAsync();
            return query;
        }
        public async Task<IEnumerable<Song>> GetByComposer(string composer)
        {
            var query = await db.Song.FromSqlRaw("exec sp_getByComposer {0}", composer).ToListAsync();
            return query;
        }
        public async Task<IEnumerable<Song>> GetByName(string name)
        {
            var query = await db.Song.FromSqlRaw("exec sp_searchByName {0}", name).ToListAsync();
            return query;
        }
    }
}
