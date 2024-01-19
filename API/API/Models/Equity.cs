namespace API.Models
{
    public class Equity
    {
        public double Balance { get; set; }
        public DateTime DueDate { get; set; }
        public int Term { get; set; }
        public double MonthlyAmount { get; set; }
        public double Interest => (int)(MonthlyAmount * 0.05);
        public double Insurance => (int)(MonthlyAmount * 0.01);
    }
}
