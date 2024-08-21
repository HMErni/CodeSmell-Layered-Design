namespace CodeSmells.Model
{

    public class User
    {
        public int id { get; init; }
        public string name { get; init; } = string.Empty;
        public string company { get; init; } = string.Empty;
        public string username { get; init; } = string.Empty;
        public string email { get; init; } = string.Empty;
        public string address { get; init; } = string.Empty;
        public string zip { get; init; } = string.Empty;
        public string state { get; init; } = string.Empty;
        public string country { get; init; } = string.Empty;
        public string phone { get; init; } = string.Empty;
        public string photo { get; init; } = string.Empty;

    }
}