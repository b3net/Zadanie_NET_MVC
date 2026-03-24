using Project.Models;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=DefaultConnection") { }
    public DbSet <MessageModel> Messages { get; set; }
}