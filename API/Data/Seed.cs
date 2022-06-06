using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if(await context.Manageri.AnyAsync()) return;  //daca avem useri in database ne intoarcem

            //daca nu avem useri in baza, citim din .json si salvam intr-o variabila
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppManageri>>(userData);

            foreach(var user in users)
            {
                using var hmac = new HMACSHA512();

                user.ManagerNume = user.ManagerNume.ToLower();
                user.Departament = user.Departament.ToLower();
                //user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("p@ssword"));
                //user.PasswordSalt = hmac.Key;

                context.Manageri.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}