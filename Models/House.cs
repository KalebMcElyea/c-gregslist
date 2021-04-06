using System;


namespace c_gregslist.Models
{
    public class House
    {
        public House(int bedrooms, int bathrooms, int year, int price, string description)
        {
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            Year = year;
            Price = price;
            Description = description;

        }

        public House()
        {

        }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string Id { get; private set; } = Guid.NewGuid().ToString();

    }
}