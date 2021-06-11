using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class SongManagementService
    {
        //правим логиката -  CRUD

        private MyDBContext ctx = new MyDBContext(); //връзка с context

        public List<SongDTO> Get(string filter) //четем данните от бд // ще ни връща всички песни
        {
            List<SongDTO> song = new List<SongDTO>();  // правим си празен списък

            //foreach (var item in ctx.Songs.ToList()) // взимаме записите от таблицата 
            // {
            using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
            {
                foreach (var item in unitOfWork.SongRepository.Get(x => x.songName.Contains(filter)))
                {
                    song.Add(new SongDTO //properties from DTOs //добавяме в списъка всеки item 
                    {
                        Id = item.Id,
                        songName = item.songName,
                        Singer = item.Singer,
                        Year = item.Year,
                        //!
                        SongStyleId = item.SongStyleId,
                       
                        SongStyle = new SongStyleDTO //виртулен 
                        {
                            Id = item.SongStyleId,
                            Title = item.SongStyle.Title
                        }
                    });

                }

                return song;

            }
        }
        public SongDTO GetById(int id)
        {

            Song item = ctx.Songs.Find(id);

            SongDTO songDTO = new SongDTO
            {
                Id = item.Id,
                songName = item.songName,
                Singer = item.Singer,
                Year = item.Year,
                //!
                SongStyleId = item.SongStyleId,
                SongStyle = new SongStyleDTO //виртулен 
                {
                    Id = item.SongStyleId,
                    Title = item.SongStyle.Title
                }

            };

            return songDTO;



        }


        public bool Save(SongDTO songDTO) //Create
        {

            //! работим с две таблици
            //проверка дали има подaден пaрметър Style
            //
            if (songDTO.SongStyle == null || songDTO.SongStyleId == 0)
            {
                return false;
            }

            /*  SongStyle style = new SongStyle //object SongStyle
              {
                  Id = songDTO.SongStyleId,
                  Title = songDTO.SongStyle.Title
              };*/

            Song song = new Song //object Song
            {
                Id = songDTO.Id,
                songName = songDTO.songName,
                Singer = songDTO.Singer,
                Year = songDTO.Year,
                //!
                SongStyleId = songDTO.SongStyleId,



            };
            try
            {
                using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
                {
                    unitOfWork.SongRepository.Insert(song);
                    unitOfWork.Save();
                }
                //ctx.Songs.Add(song);
                //  ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
                {
                    Song song = unitOfWork.SongRepository.GetByID(id);
                    unitOfWork.SongRepository.Delete(song);
                    unitOfWork.Save();
                }

                // Song song = ctx.Songs.Find(id);
                //ctx.Songs.Remove(song);
                // ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
