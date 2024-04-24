using System;
using System.Net.Http;
using System.Threading.Tasks;

public class SupabaseService
{
	private readonly HttpClient _httpClient;
	private readonly string _supabaseUrl;
	private readonly string _supabaseApiKey;

	public SupabaseService()
	{
		_httpClient = new HttpClient();
		_supabaseUrl = "https://pepiwahqzfqojffolhaq.supabase.co";
		_supabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InBlcGl3YWhxemZxb2pmZm9saGFxIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTcxMzU4MDcyNSwiZXhwIjoyMDI5MTU2NzI1fQ.0EzMdmelQUgd-6W0lRK-HHBcKowgcMngRiYvCzHgVdg";
	}

	public async Task<string> RegisterUser(string email, string password)
	{
		var requestBody = $"{{\"email\": \"{email}\", \"password\": \"{password}\"}}";
		var request = new HttpRequestMessage(HttpMethod.Post, $"{_supabaseUrl}/auth/v1/signup")
		{
			Content = new StringContent(requestBody)
		};
		request.Headers.Add("apikey", _supabaseApiKey);

		var response = await _httpClient.SendAsync(request);
		var content = await response.Content.ReadAsStringAsync();

		return content;
	}

	public async Task<string> LoginUser(string email, string password)
	{
		var requestBody = $"{{\"email\": \"{email}\", \"password\": \"{password}\"}}";
		var request = new HttpRequestMessage(HttpMethod.Post, $"{_supabaseUrl}/auth/v1/token?grant_type=password")
		{
			Content = new StringContent(requestBody)
		};
		request.Headers.Add("apikey", _supabaseApiKey);

		var response = await _httpClient.SendAsync(request);
		var content = await response.Content.ReadAsStringAsync();

		return content;
	}
}
