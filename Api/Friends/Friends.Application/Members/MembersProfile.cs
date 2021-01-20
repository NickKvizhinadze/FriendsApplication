using System.Linq;
using AutoMapper;
using Friends.Domain.Members;
using Friends.Application.Members.Models;

namespace Friends.Application.Members
{
    public class MembersProfile : Profile
    {
        public MembersProfile()
        {
            CreateMap<Member, MemberDto>()
                .AfterMap((src, dest) => { 
                    if(src.Friends != null && src.Friends.Count > 0)
                        dest.Friends = src.Friends.Select(f => f.Friend2.Name).ToList();
                });
        }
    }
}
