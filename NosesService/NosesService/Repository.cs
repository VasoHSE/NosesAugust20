using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NosesService.Data;
using System.IO;
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
            
            _context.SaveChanges();
        }
        public void SeedOperations_dotors()
        {
            var a = from us in _context.Users
                where us.isDoctor == true
                select us.Id;
            var kek = new Random();
            foreach (var doctor in a)
            {
                var exist = new List<int>();
                for (int i = 0; i < kek.Next(0, 28); i++)
                {
                    var operation = kek.Next(1, 29);
                    if (exist.All(x => x != operation))
                    {
                        _context.Operatopn_Doctor.Add(new Operatopn_Doctor
                        {
                            doctor_id = doctor,
                            operation_id = operation,
                            rating = kek.Next(1, 10000)
                        });
                        exist.Add(operation);

                    }

                }
            }
            _context.SaveChanges();
        }
        public void SeedOperations()
        {
            var a = from us in _context.Users
                where us.isDoctor == true
                select us.Id;
            var operations = File.ReadAllLines("operations.txt");
            for (int i = 0; i < operations.Length; i++)
            {
                _context.Operations.Add(new Operation
                {
                    name = operations[i]
                });
            }
            _context.SaveChanges();
        }
        public void SeedUsers()
        {
            var kek = new Random();
            var names = File.ReadAllLines("names.txt");
            for (int i = 0; i < names.Length; i++)
            {
                var a = names[i];

                _context.Users.Add(new User
                {
                    create_date = DateTime.Now.AddDays(-kek.Next(1, 100)),
                    last_active = DateTime.Now.AddDays(kek.Next(1, 13)),
                    email = string.Format(a + i + "@gmail.com"),
                    isDoctor = kek.Next(0, 2) == 1,
                    facebook = string.Format("fb.com/" + a + i),
                    instagram = string.Format("@insta" + a + i),
                    name = a,
                    password = string.Format("pw" + a + i),
                    patronimic = string.Format(a + i + "evna"),
                    phone = string.Format("7916" + kek.Next(1111111, 9999999)),
                    rating = kek.Next(123, 1234),
                    surname = kek.Next(0, 2) == 1 ? string.Format(a + i + "yan") : string.Format(a + i + "son"),
                    twitter = string.Format(a + i + "twitt"),
                    vk = string.Format(a + i + "vk"),
                    website = string.Format("http://" + a + i),
                    youtube = string.Format("youtube@" + a)
                });
            }
            _context.SaveChanges();
        }
    }
}