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
    public class SingerManagementSystem
    {
       // private MyDBContext ctx = new MyDBContext(); //връзка с context

        public List<SingerDTO> Get(string filter) //четем данните от бд // ще ни връща всички песни
        {
            List<SingerDTO> singer = new List<SingerDTO>();  // правим си празен списък

            //foreach (var item in ctx.Singers.ToList()) // взимаме записите от таблицата 
            //{
            using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork()) 
            {
                foreach (var item in unitOfWork.SingerRepository.Get(x => x.Name.Contains(filter)))
                {
                    singer.Add(new SingerDTO //properties from DTOs //добавяме в списъка всеки item 
                    {
                        Id = item.Id,
                        Name = item.Name,
                        //!
                        SongStyleId = item.SongStyleId,
                        SongStyle = new SongStyleDTO //виртулен 
                        {
                            Id = item.SongStyleId,
                            Title = item.SongStyle.Title
                        }
                    });
                } 
                }
          
            return singer;

        }
        public SingerDTO GetById(int id)
        {

            //Singer item = ctx.Singers.Find(id);
            SingerDTO singerDTO = new SingerDTO();
            using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
            {
                Singer singer = unitOfWork.SingerRepository.GetByID(id);

                if (singer != null)
                {
                    singerDTO.Id = singer.Id;
                    singerDTO.Name = singer.Name;
                }
            }
            return singerDTO;
            //SingerDTO singer = new SingerDTO
            //{
            //    Id = item.Id,
            //    Name = item.Name,

            //    //!
            //    SongStyleId = item.SongStyleId,
            //    SongStyle = new SongStyleDTO //виртулен 
            //    {
            //        Id = item.SongStyleId,
            //        Title = item.SongStyle.Title
            //    }

            //};





        }


        public bool Save(SingerDTO singerDTO) //Create
        {

            //! работим с две таблици
            //проверка дали има подaден пaрметър Style
            //
            if (singerDTO.SongStyle == null || singerDTO.SongStyleId == 0)
            {
                return false;
            }

            /*  SongStyle style = new SongStyle //object SongStyle
              {
                  Id = songDTO.SongStyleId,
                  Title = songDTO.SongStyle.Title
              };*/

            Singer singer = new Singer //object Song
            {
                Id = singerDTO.Id,
                Name = singerDTO.Name,

                //!
                SongStyleId = singerDTO.SongStyleId,



            };
            try
            {
                using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
                {
                    unitOfWork.SingerRepository.Insert(singer);
                    unitOfWork.Save();
                }
                //ctx.Singers.Add(singer);
                //ctx.SaveChanges();

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
                    Singer singer = unitOfWork.SingerRepository.GetByID(id);
                    unitOfWork.SingerRepository.Delete(singer);
                    unitOfWork.Save();
                }


            //    Singer singer = ctx.Singers.Find(id);
            //    ctx.Singers.Remove(singer);
            //    ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
