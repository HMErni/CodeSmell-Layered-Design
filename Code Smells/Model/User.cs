namespace CodeSmells.Model
{

    public class User
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string company { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string zip { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string photo { get; set; } = string.Empty;

    }
}