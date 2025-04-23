using System.Threading.Tasks;
using Eventick.Services.Marketing.Entities;

namespace Eventick.Services.Marketing.Repositories
{
    public interface IBasketChangeEventRepository
    {
        Task AddBasketChangeEvent(BasketChangeEvent basketChangeEvent);
    }
}