using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DotNetHelpers.Models;
using Friends.Common.Models;

namespace Friends.Application.Common
{
    public abstract class BaseService
    {
        #region Fields
        protected readonly AppSettings _settings;
        protected readonly IMapper _mapper;
        protected readonly ILogger<BaseService> _logger;
        #endregion

        #region Constructors
        public BaseService(IOptionsSnapshot<AppSettings> options, IMapper mapper, ILogger<BaseService> logger)
        {
            _settings = options.Value;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Protected Methods
        protected void CheckPerPage(Paging paging)
        {
            if (paging.PerPage == 0)
                paging.PerPage = _settings.PerPage;
        }


        protected Paging GetPagingInfo(Paging paging, int totalCount)
            => new Paging(paging.CurrentPage, paging.PerPage, totalCount, GetPagesCount(totalCount, paging.PerPage));

        protected int GetPagesCount(int totalCount, int perPage)
            => (int)Math.Ceiling((decimal)totalCount / perPage);

        #endregion
    }
}
