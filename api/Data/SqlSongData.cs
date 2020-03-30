using enjoymusic_project.Models;
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

        public IEnumerable<Song> GetAll()
        {
            var query = from r in db.Songs
                        select r;
            return query;
        }

    }
}
