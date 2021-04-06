using System.Collections.Generic;
using c_gregslist.Models;

namespace c_gregslist.DB
{
    public class FakeDB
    {
        //NOTE make sure you instantiate your list before you try to access it.
        public static List<Car> Cars { get; set; } = new List<Car>();

        public static List<House> Houses { get; set; } = new List<House>();

        public static List<Job> Jobs { get; set; } = new List<Job>();
    }

}