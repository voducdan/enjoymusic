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

        Task<IEnumerable<Song>> GetTopListen();
        Task<IEnumerable<Song>> GetTopDownLoad();
        Task<IEnumerable<Song>> GetTopRate();
        Task<IEnumerable<Song>> GetNewComment();
        Task<IEnumerable<Song>> GetByCategory(string category);
        Task<IEnumerable<Song>> GetBySinger(string singer);
        Task<IEnumerable<Song>> GetByComposer(string composer);
        Task<IEnumerable<Song>> GetByName(string name);
    }
}
