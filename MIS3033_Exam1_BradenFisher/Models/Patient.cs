using System.ComponentModel.DataAnnotations;

namespace a
{
    public class Patient
    {
        [Key]
        public string PID { get; set; }
        public int Age { get; set; }
        public int AgeLevel { get; set; }

        public override string ToString()
        {
            return $"ID: {PID}, Age: {Age} (Level {AgeLevel})";
        }

        public int GetAgeLevel()
        {
            if (Age >= 65)
            {
                AgeLevel = 1;
            }
            else if (Age >= 40)
            {
                AgeLevel = 2; 
            }
            else
            {
                AgeLevel = 3;
            }
            return AgeLevel;
        }
    }
}