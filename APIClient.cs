using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JitBitAPIClient
{
    public class ClientException : Exception
    {
        public ClientException(string message) :
            base(message)
        {
        }

        public ClientException(string message, Exception innerException):
            base(message, innerException)
        {
        }
    }

    public class ClientResult<T>
    {
        public bool Ok { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }

    public class APIClient
    {
        private readonly string _UserName;
        private readonly string _UserPassword;

        private readonly string _URL;

        public APIClient(string url, string userName, string userPassword)
        {
            _URL = url;
            _UserName = userName;
            _UserPassword = userPassword;
        }

        protected async Task<T> GetData<T>(string endpoint)
        {
            var data = await _Query(endpoint, null, "GET");

            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    if (typeof(T) == typeof(int))
                    {
                        return (T)Convert.ChangeType(data, typeof(T));
                    }

                    return JsonSerializer.Deserialize<T>(data);
                }
                catch
                {
                }
            }

            return default;
        }

        protected async Task<T> PostData<T>(string endpoint, MultipartFormDataContent content)
        {
            var data = await _Query(endpoint, content, "POST");

            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    if (typeof(T) == typeof(int))
                    {
                        return (T)Convert.ChangeType(data, typeof(T));
                    }

                    return JsonSerializer.Deserialize<T>(data);
                }
                catch
                {
                }
            }

            return default;
        }

        protected async Task<bool> Execute(string endpoint, MultipartFormDataContent content)
        {
            var stringResult = await _Query(endpoint, content, "POST");

            return string.IsNullOrEmpty(stringResult);
        }

        private async Task<string> _Query(string endpoint, MultipartFormDataContent content, string method)
        {
            using (var httpClient = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes($"{_UserName}:{_UserPassword}");

                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                HttpResponseMessage response;

                if (method == "POST")
                {
                    response = await httpClient.PostAsync(_URL + endpoint, content);
                }
                else
                {
                    response = await httpClient.GetAsync(_URL + endpoint);
                }
                
                var stringResult = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ClientException($"{response.StatusCode}: {stringResult}");
                }

                return stringResult;
            }
        }
    }
}