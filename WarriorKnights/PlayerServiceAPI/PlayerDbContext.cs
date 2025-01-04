using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PlayerServiceAPI.Models;

namespace PlayerServiceAPI{
    public class PlayerDbContext : DbContext
    {
    
        public PlayerDbContext(DbContextOptions<PlayerDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreator != null){
                    if(!dbCreator.CanConnect()) dbCreator.Create();
                    if(!dbCreator.HasTables()) dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<Player> Players {get;set;}
    }
}


