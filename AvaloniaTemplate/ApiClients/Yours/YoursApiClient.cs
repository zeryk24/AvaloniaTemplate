using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaTemplate.ApiClients.Yours;

public class YoursApiClient : IYoursApiClient
{
    private readonly HttpClient _client;
    private readonly string _baseUri;
    private readonly string _apiUrl;

    public YoursApiClient(HttpClient client, string baseUri, string apiUrl)
    {
        _client = client;
        _baseUri = baseUri;
        _apiUrl = apiUrl;
    }

    //TODO: Create method that returns data and add it to interface
}
