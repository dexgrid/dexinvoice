using DexInvoice.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DexInvoice.Application
{
    public class HtmlToPdfClient : IHtmlToPdfClient
    {
        private readonly HttpClient _httpClient;

        public HtmlToPdfClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<byte[]> GetPdfFromHtml(string html)
        {
            var result = await _httpClient.PostAsync("Convert", new StringContent(html));
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsByteArrayAsync();
        }
    }
}
