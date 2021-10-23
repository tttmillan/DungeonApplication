using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class MenuSelection
    {
        public static string PlayerTypeString(string name)
        {
            return string.Format("{0} Which type of player would you like?\n" +
                "A) Marty McFly\n" +
                "B) Han Solo\n" +
                "C) Ferrius Bueller\n" +
                "D) Samantha Barker\n" +
                "E) Lloyd Dobler\n" +
                "F) Daniel LaRusso\n" +
                "G) Andie Walsh\n" +
                "H) Clark Griswold\n" +
                "I) Baby\n" +
                "J) Roger Rabbit\n" +
                "K) Maverick", name);
        }
    }
}
