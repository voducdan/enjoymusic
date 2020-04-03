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
    }
}
