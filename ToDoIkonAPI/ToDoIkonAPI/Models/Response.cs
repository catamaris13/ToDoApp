namespace ToDoIkonAPI.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public User User { get; set; }
        public List<Sarcina> listSarcina { get; set; }
    }
}
