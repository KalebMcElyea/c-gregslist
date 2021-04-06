using System;


namespace c_gregslist.Models
{
    public class Car
    {
        public Car(string model, int year, int miles, int price)
        {
            Model = model;
            Year = year;
            Miles = miles;
            Price = price;

        }

        public Car()
        {

        }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Miles { get; set; }

        public int Price { get; set; }

        public string id { get; private set; } = Guid.NewGuid().ToString();

    }
}