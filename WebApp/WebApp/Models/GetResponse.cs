namespace APIClientApp
{
    public class GetResponse
    {
        public double Balance { get; set; }
        public DateTime DueDate { get; set; }
        public int Term { get; set; }
        public double MonthlyAmount { get; set; }
        public double Interest {  get; set; }
        public double Insurance {  get; set; }
    }
}
