
using Newtonsoft.Json;
using System.Text;

namespace DeluxeHotel.Services.GeminiServices
{
    public class GeminiService : IGeminiService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private const string Model = "gemini-2.5-flash";
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/";

        public GeminiService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["Gemini:ApiKey"];
        }
        public async Task<string> GetAiResponse(string prompt)
        {
            var request = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[] { new { text = prompt } }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.7f,
                    maxOutputTokens = 10000
                }
            };
            var jsonContent = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var url = $"{BaseUrl}{Model}:generateContent?key={_apiKey}";

            var response = await _client.PostAsync(url, httpContent);
            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return message;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic geminiResponse = JsonConvert.DeserializeObject(responseString);
            var resultText = geminiResponse.candidates[0].content.parts[0].text;
            return resultText ?? "Yanıt Alınamadı";
        }

        public async Task<string> GetHistoricalRouteHtml(string cityName)
        {
            string htmlTemplate = @"
                                    <div class=""glass-panel rounded-2xl p-5 md:col-span-2 flex flex-col"">
                                        <div class=""flex items-center justify-between mb-4"">
                                            <h3 class=""text-lg font-bold flex items-center gap-2"">
                                                <span class=""material-symbols-outlined text-cyan-400 text-[20px]"">map</span>
                                                Tarihi Rota
                                            </h3>
                                            <div class=""flex items-center gap-2"">
                                                <span class=""text-xs bg-cyan-400/10 text-cyan-400 px-2 py-1 rounded border border-cyan-400/20"">{Şehir İsmi}</span>
                                                <span class=""text-xl"">🗺️</span>
                                            </div>
                                        </div>
                                        <div class=""relative pl-2 flex-1 overflow-hidden"">
                                            <div class=""absolute left-2 top-2 bottom-4 w-0.5 bg-gradient-to-b from-cyan-500 via-cyan-900 to-transparent""></div>
                                            <div class=""space-y-5 ml-6 py-1"">
                                                
                                                <div class=""relative group cursor-pointer"">
                                                    <span class=""absolute -left-[23px] top-1.5 h-3 w-3 rounded-full bg-cyan-400 ring-4 ring-[#162e25] group-hover:scale-110 transition-transform""></span>
                                                    <div class=""flex justify-between items-start"">
                                                        <div>
                                                            <h4 class=""font-bold text-sm text-slate-800 dark:text-slate-200 group-hover:text-cyan-400 transition-colors"">{Mekan Adı}</h4>
                                                            <p class=""text-xs text-slate-500 dark:text-slate-400 mt-1 leading-relaxed"">{Mekan Açıklaması}</p>
                                                        </div>
                                                        <span class=""text-[10px] font-mono text-slate-400 border border-slate-600 rounded px-1.5 py-0.5 ml-2"">{Saat}</span>
                                                    </div>
                                                </div>
                                                </div>
                                        </div>
                                    </div>";

            var prompt = $@"Sen bir profesyonel gezi rehberisin. {cityName} şehri için tarihi bir rota oluştur. 
                            Yanıt olarak sadece ve sadece ham HTML kodu döndür. 
                            Markdown işaretleri (```html gibi) asla kullanma. 
                            Yapı tam olarak şu şekilde olmalı:
                            
                            {htmlTemplate}
                            
                            Kurallar:
                            1. HTML içindeki başlıkları ve açıklamaları {cityName} şehrine göre doldur.
                            2. Saatleri mantıklı bir sıraya koy (09:00, 11:30 vb.).
                            3. 'Istanbul Old City' yazan yerdeki şehir ismini güncelle.
                            4. Sadece 4 durak (item) olsun.";

            var response = await GetAiResponse(prompt);

            return response.Replace("```html", "").Replace("```", "").Trim();
        }
    }
}
