using Project.Models;
using System.IO;
using System.Web;

namespace Project.Infrastructure.Message {
    public class MessageFileStorage : FileRepositoryStorage<MessageModel>
    {
        private static readonly string DefaultPath = Path.Combine(
            HttpRuntime.AppDomainAppPath,
            "App_Data",
            "messages.json"
        );

        public MessageFileStorage() : base(DefaultPath) { }
    }
}