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
    public class SongStyleManagementService
    {
        //връзка с context

        //private MyDBContext ctx = new MyDBContext();


        //ще ни връща списък от песни
        public List<SongStyleDTO> Get() //четем данните от бд
        {
            List<SongStyleDTO> style = new List<SongStyleDTO>();

            // foreach (var item in ctx.Styles.ToList()) // взимаме записите от таблицата 
            // {
            using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
            {
                foreach (var item in unitOfWork.SongStyleRepository.Get())
                {
                    style.Add(new SongStyleDTO //properties from DTOs
                    {
                        Id = item.Id,
                        Title = item.Title
                    });

                }

                return style;

            }
        }

        public SongStyleDTO GetById(int id)
        {
            //  SongStyleDTO styleDTO = new SongStyleDTO();

            // SongStyle style = ctx.Styles.Find(id);
            SongStyleDTO styleDTO = new SongStyleDTO();
            using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
            {
                SongStyle style = unitOfWork.SongStyleRepository.GetByID(id);
                if (style != null)
                {
                    styleDTO.Id = style.Id;
                    styleDTO.Title = style.Title;
                }

                return styleDTO;
            }
        }

        public bool Save(SongStyleDTO styleDTO)
        {
            SongStyle style = new SongStyle
            {
                Title = styleDTO.Title
            };

            try
            {
                //ctx.Styles.Add(style);
                // ctx.SaveChanges();

                using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
                {
                    unitOfWork.SongStyleRepository.Insert(style);
                    unitOfWork.Save();
                }
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
                // SongStyle style = ctx.Styles.Find(id);
                //ctx.Styles.Remove(style);
                //ctx.SaveChanges();


                using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
                {
                    SongStyle style = unitOfWork.SongStyleRepository.GetByID(id);
                    unitOfWork.SongStyleRepository.Delete(style);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
