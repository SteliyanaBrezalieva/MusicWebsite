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

    public class UserManagementService
    {
        //правим логиката -  CRUD

        private MyDBContext ctx = new MyDBContext(); //връзка с context

        public List<UserDTO> Get() //четем данните от бд // ще ни връща всички песни
        {
            List<UserDTO> user = new List<UserDTO>();  // правим си празен списък

            //foreach (var item in ctx.Users.ToList()) // взимаме записите от таблицата 
            // {
            using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
            {
                foreach (var item in unitOfWork.UserRepository.Get())
                {
                    user.Add(new UserDTO //properties from DTOs //добавяме в списъка всеки item 
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Username = item.Username,
                        // Password = item.Password,
                        //ConfPassword = item.ConfPassword,
                        Email = item.Email,

                        //!

                    });

                }

                return user;
            }
        }
        public UserDTO GetById(int id)
        {

            User item = ctx.Users.Find(id);

            UserDTO userDTO = new UserDTO
            {
                Id = item.Id,
                Name = item.Name,
                Username = item.Username,
                Password = item.Password,
                //ConfPassword = item.ConfPassword,
                Email = item.Email

            };

            return userDTO;



        }


        public bool Save(UserDTO userDTO) //Create
        {

            User user = new User //object Song
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Username = userDTO.Username,
                Password = userDTO.Password,
                // ConfPassword = userDTO.ConfPassword,
                Email = userDTO.Email




            };
            try
            {
                // ctx.Users.Add(user);
                //  ctx.SaveChanges();

                using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
                {
                    unitOfWork.UserRepository.Insert(user);
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
                using (Repository.Implementation.UnitOfWork unitOfWork = new Repository.Implementation.UnitOfWork())
                {
                    User user = unitOfWork.UserRepository.GetByID(id);
                    unitOfWork.UserRepository.Delete(user);
                    unitOfWork.Save();
                }
                //User user = ctx.Users.Find(id);
                // ctx.Users.Remove(user);
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
