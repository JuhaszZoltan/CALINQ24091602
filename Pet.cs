namespace CALINQ24091602
{
    internal class Pet
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age => (int)(DateTime.Now - BirthDate).TotalDays / 365;
        public bool Sex { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Age} years old {Species} {(Sex ? "boy" : "girl")})";
        }
    }
}
