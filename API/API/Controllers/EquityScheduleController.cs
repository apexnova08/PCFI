using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquityScheduleController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Equity> Get(double SellingPrice, DateTime ReservationDate, int EquityTerm)
        {
            double monthlyAmount = SellingPrice / EquityTerm;
            return Enumerable.Range(1, EquityTerm).Select(index => new Equity
            {
                Balance = SellingPrice - monthlyAmount * index,
                DueDate = ReservationDate.AddMonths(index),
                Term = index,
                MonthlyAmount = monthlyAmount
            })
            .ToArray();
        }
    }
}
