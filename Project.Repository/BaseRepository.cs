using Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}
