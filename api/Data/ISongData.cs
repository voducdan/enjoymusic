using enjoymusic_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enjoymusic_project.Data
{
    public interface ISongData
    {
        Task<IEnumerable<Song>> GetAll();
        Song GetById(string id);
    }
}
