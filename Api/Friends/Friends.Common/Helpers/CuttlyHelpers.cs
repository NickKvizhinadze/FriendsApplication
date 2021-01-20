using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using Friends.Common.Models;
using DotNetHelpers.Models;

namespace Friends.Common.Helpers
{
    public static class CuttlyHelpers
    {
        #region Fields
        private static Dictionary<int, string> _cuttlyStatusDictionary = new Dictionary<int, string>()
        {
            {1, "the shortened link comes from the domain that shortens the link, i.e. the link has already been shortened" },
            {2, "the entered link is not a link" },
            {3, "the preferred link name is already taken" },
            {4, "Invalid API key" },
            {5, "the link has not passed the validation. Includes invalid characters" },
            {6, "The link provided is from a blocked domain" },
            {7, "OK - the link has been shortened" },
        };
        #endregion

        #region Methods
        public static async Task<Result<string>> GetShorenerUrlasync(AppSettings settings, string url)
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri(settings.CuttlyUrl)
            };

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync($"?key={settings.CuttlyApiKey}&short={url}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ShorenerUrlDto>(content).Url;
                if (result.Status == 1)
                        return Result.Success(url);

                if (result.Status == 7)
                        return Result.Success(result.ShortLink);

                return Result.Error<string>($"data status: {result.Status}, status text: {_cuttlyStatusDictionary[result.Status]}");
            }
            return Result.Error<string>($"response status code: {(int)response.StatusCode}, error: {response.ReasonPhrase}");
        }
        #endregion
    }
}
