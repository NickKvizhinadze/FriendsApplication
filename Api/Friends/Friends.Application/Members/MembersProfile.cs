using System.Linq;
using System.Collections.Generic;
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
                .ForMember(dest => dest.Headings, opts => opts.Ignore())
                .AfterMap((src, dest) => { 
                    if(src.Friends != null && src.Friends.Count > 0)
                        dest.Friends = src.Friends.Select(f => f.Friend2!.Name).ToList();

                    if (src.Headings != null && src.Headings.Count > 0)
                        dest.Headings = src.Headings
                        .Select(h => new KeyValuePair<string, string>(h.Key, h.Value))
                        .ToList();
                });
        }
    }
}
