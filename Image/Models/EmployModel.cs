namespace Image.Models
{
    public class EmployModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public List<HobbyModel> Hobbies { get; set; }
        public string ProfileImage { get; set; }

    }
}
