using System.Threading.Tasks;
using Friends.Application.Common;

namespace Friends.Application.Members.Abstractions
{
    public interface IMemberService
    {
        Task<object> GetAllAsync(BaseAdditional<BaseFilter> additional);
    }
}
