using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class UnitOfWork : IDisposable
    {
        private MyDBContext context = new MyDBContext();
        private GenericRepository<Singer> singerRepository;
        private GenericRepository<Song> songRepository;
        private GenericRepository<SongStyle> songstyleRepository;
        private GenericRepository<User> userRepository;
    


        public GenericRepository<Singer> SingerRepository
        {
            get
            {

                if (this.singerRepository == null)
                {
                    this.singerRepository = new GenericRepository<Singer>(context);
                }
                return singerRepository;
            }
        }

        public GenericRepository<Song> SongRepository
        {
            get
            {

                if (this.songRepository == null)
                {
                    this.songRepository = new GenericRepository<Song>(context);
                }
                return songRepository;
            }
        }
        public GenericRepository<SongStyle> SongStyleRepository
        {
            get
            {

                if (this.songstyleRepository == null)
                {
                    this.songstyleRepository = new GenericRepository<SongStyle>(context);
                }
                return songstyleRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository ;
            }
        }
       

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
