using Project.Models;

namespace Project.Infrastructure.Message
{

    public class MessageDbStorage : DbRepositoryStorage<MessageModel, AppDbContext> { }
}