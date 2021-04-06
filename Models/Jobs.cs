using System;


namespace c_gregslist.Models
{
    public class Job
    {
        public Job(string description, int rate, int hour, string company)
        {
            Description = description;
            Rate = rate;
            Hour = hour;
            Company = company;

        }

        public Job()
        {

        }

        public string Description { get; set; }

        public int Rate { get; set; }

        public int Hour { get; set; }

        public string Company { get; set; }

        public string Id { get; private set; } = Guid.NewGuid().ToString();

    }
}