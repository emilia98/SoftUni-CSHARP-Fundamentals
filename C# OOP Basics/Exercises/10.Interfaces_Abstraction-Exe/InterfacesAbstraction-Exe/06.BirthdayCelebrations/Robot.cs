namespace _06.BirthdayCelebrations
{
    public class Robot : IMember
    {
        public string Id { get; private set; }

        public string Model { get; private set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}