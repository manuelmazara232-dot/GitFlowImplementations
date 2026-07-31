namespace GitFlow.Entities
{
    internal class People
    {
        public int ID { get; set; }
        public string? FIRSTNAME { get; set; }
        public string? LASTNAME {  get; set; }
        public DateOnly? BIRTHDATE { get; set; }   
        public string? DNI {  get; set; }
        public string? GENDER { get; set; }
    }
}
