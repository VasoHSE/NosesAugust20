using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NosesService.Data;

namespace NosesService
{
    public class Repository
    {
        private readonly NosesDbSecondEntities _context;

        public Repository()
        {
            _context = new NosesDbSecondEntities();
        }
        public void Seed()
        {
            var kek = new Random();
            _context.Users.Add(new User(
            {
                create_date = DateTime.Now.AddDays(-kek.Next(1,100)),
                
                
            }))
        }

    }
}