using AutoMapper;
using Friends.Domain.Members;
using Friends.Application.Members.Models;

namespace Friends.Application.Members
{
    public class MembersProfile : Profile
    {
        public MembersProfile()
        {
            CreateMap<Member, MemberDto>();
        }
    }
}
