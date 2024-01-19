using APIClientApp;
using System.Net.Http.Headers;
using System.Net.Http.Json;

var client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7084");

client.DefaultRequestHeaders.Clear();

client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = client.GetAsync("EquitySchedule?SellingPrice=10000&ReservationDate=2022-2-2&EquityTerm=5").Result;

if (response.IsSuccessStatusCode)
{
    var scheds = await response.Content.ReadFromJsonAsync<IEnumerable<GetResponse>>();
    foreach (var sched in scheds)
    {
        Console.WriteLine(sched.Balance);
        Console.WriteLine(sched.DueDate.ToShortDateString());
        Console.WriteLine(sched.Term);
        Console.WriteLine(sched.MonthlyAmount);
        Console.WriteLine(sched.Interest);
        Console.WriteLine(sched.Insurance);
        Console.WriteLine();
    }
    Console.WriteLine(response);
}
else
{
    Console.WriteLine("Not Epic");
}
