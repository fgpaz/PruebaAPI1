using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DataAccess.FromPlanificacion
{
    public abstract class DatosCrudosAccess
    {
        //private readonly LoggerService _log;

        private readonly HttpClient client;

        private readonly IConfiguration _configuration;
        public DatosCrudosAccess(IConfiguration configuration)//, LoggerService log)
        {
            this._configuration = configuration;
            //this._log = log;

            client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.GetSection("SnoopGateway")["ProjectApiUrl"].ToString());
            client.DefaultRequestHeaders.Add(
                _configuration.GetSection("SnoopGateway")["KeyHeader"].ToString(),
                _configuration.GetSection("SnoopGateway")["ProjectApiKey"].ToString());
        }

        protected async Task<T?> Get<T>(string url)
        { 
            //_log.Info("Project GET request: " + url);
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                //_log.Info("Request completed successfully");
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }
            else
            {
                //log.Error("Request failed: " + content);
                throw new Exception("Toggl request failed", new Exception(content));
            }
        }
    }
}
