using System;
using DotNetHelpers.Models;

namespace Friends.Application.Common
{
    public class BaseAdditional<T> where T : BaseFilter, new()
    {
        #region Constructors
        public BaseAdditional()
        {
            Filter = Activator.CreateInstance<T>();
            Paging = new Paging();
            Sorting = new Sorting();
        }

        public BaseAdditional(T filter, Paging paging, Sorting sorting)
        {
            Filter = filter;
            Paging = paging;
            Sorting = sorting;
        }

        #endregion

        #region Properties
        public T Filter { get; set; }
        public Paging Paging { get; set; }
        public Sorting Sorting { get; set; }
        #endregion
    }
}
