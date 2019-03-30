using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Services
{
    public class NewsService
    {
        private readonly string _apiNewsKey = "17e4f139baae40be981076543ab4297c";
        private readonly string _queryTemplate = "https://newsapi.org/v2/everything?q={0}&from={1}-{2}-{3}&sortBy=publishedAt&apiKey=17e4f139baae40be981076543ab4297c";

        public async Task<ObservableCollection<Article>> GetNewsByQuery(string query)
        {
            try
            {
                ArticlesResult articlesResult = null;

                using (var client = new HttpClient())
                {
                    DateTime date = DateTime.Today.AddMonths(-1);
                    var jsonString = await client.GetStringAsync(new Uri(string.Format(_queryTemplate, query, date.Year, date.Month, date.Day)));
                    articlesResult = JsonConvert.DeserializeObject<ArticlesResult>(jsonString);
                    if (articlesResult != null)
                    {
                        return new ObservableCollection<Article>(articlesResult.Articles.Take(3));
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<ObservableCollection<Article>> GetUkraineNews()
        {
            return await GetNewsByQuery("Украина");
        }

        public async Task<ObservableCollection<Article>> GetPolandNews()
        {
            return await GetNewsByQuery("Польша");
        }

        public async Task<ObservableCollection<Article>> GetEnglandNews()
        {
            return await GetNewsByQuery("Англия");
        }
    }
}
