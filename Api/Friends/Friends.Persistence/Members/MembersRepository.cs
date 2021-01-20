using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DotNetHelpers.Enums;
using DotNetHelpers.Models;
using DotNetHelpers.Extentions;
using Friends.Domain.Members;
using Friends.Application.Common;
using Friends.Persistence.Common;
using Friends.Application.Members.Abstractions;

namespace Friends.Persistence.Members
{
    public class MembersRepository : BaseRepository<Member, string>, IMembersRepository
    {
        #region Ctor

        public MembersRepository(ApplicationDbContext context) : base(context)
        {
        }

        #endregion

        #region Methods
        public async Task<(List<Member> users, int totalCount)> GetAllAsync(BaseAdditional<BaseFilter> additional)
        {
            var query = GetQuery(additional);
            var totalCount = await query.CountAsync();

            var result = await query
                       .Skip((additional.Paging.CurrentPage - 1) * additional.Paging.PerPage)
                       .Take(additional.Paging.PerPage)
                       .ToListAsync();
            return (result, totalCount);
        }

        public Task<Member> GetAsFriendAsync(string id)
            => TableNoTracking.SingleOrDefaultAsync(f => f.Id == id);

        public Task<bool> ExistsAsync(string name)
        {
            return TableNoTracking.AnyAsync(f => f.Name == name);
        }
        #endregion

        #region Overrides
        public override Task<Member> GetAsync(string id)
            => GetWithIncludes(false).Include(c => c.Friends).SingleOrDefaultAsync(f => f.Id == id);
        #endregion

        #region Private Methods
        private IQueryable<Member> GetQuery(BaseAdditional<BaseFilter> additional)
        {
            var filter = additional.Filter;
            var result = GetWithIncludes(false);

            if (!string.IsNullOrEmpty(filter.SearchValue))
                result = result.Where(u => u.Name.ToLower().Contains(filter.SearchValue.ToLower()));
            //Sorting
            result = SortResult(result, additional.Sorting);

            return result;
        }

        private IQueryable<Member> SortResult(IQueryable<Member> result, Sorting sorting)
        {
            if (sorting != null && !string.IsNullOrEmpty(sorting.PropertyName))
            {
                if (sorting.Direction == SortDirection.Descending)
                    return result.OrderByDescending(sorting.PropertyName);
                else
                    return result.OrderBy(sorting.PropertyName);
            }

            return result.OrderByDescending(m => m.Id);
        }

        private IQueryable<Member> GetWithIncludes(bool withTracking)
        {
            var table = withTracking ? Table : TableNoTracking;
            return table
                    .Include(c => c.Headings)
                    .Include(c => c.Friends)
                    .ThenInclude(f => f.Friend2);
        }

        #endregion
    }
}
