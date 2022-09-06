
namespace IMDB.Core.Applications.Common.Interfaces
{
   public interface IMailSender
    {
        public void Send(string subject, string body);
    }
}
