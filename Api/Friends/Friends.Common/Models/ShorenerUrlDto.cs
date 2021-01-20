using System;

namespace Friends.Common.Models
{
    public class ShorenerUrlDto
    {
        public UrlDto Url { get; set; } = new UrlDto();
    }

    public class UrlDto
    {
        #region Constructors
        public UrlDto()
        {
            FullLink = string.Empty;
            ShortLink = string.Empty;
            Title = string.Empty;
        }
        #endregion
        public int Status { get; set; }
        public string FullLink { get; set; }
        public DateTime Date { get; set; }
        public string ShortLink { get; set; }
        public string Title { get; set; }
    }
}
