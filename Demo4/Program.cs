using Demo4.Entities;
using Demo4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User u1 = new User { Firstname = "aoizjeoazeo", Lastname = "apzekpo" };
            //ObjectDisplayManager<User> display = new ObjectDisplayManager<User>(u1);
            //display.Show();

            //ObjectDisplayManager<Role> display1 = new ObjectDisplayManager<Role>(new Role { Name = "pokp" });
            //display1.Show();

            //ObjectDisplayManager<IDisplayable> display2 = new ObjectDisplayManager<IDisplayable>(new Role { Name = "pokp2" });
            //display2.Show();

            //ObjectDisplayManager<IDisplayable> display3 = new ObjectDisplayManager<IDisplayable>(new User { Firstname = "pokp2", Lastname = "apozeipoazke" });
            //display3.Show();

            ObjectDisplayManager<User, User> d1 = new ObjectDisplayManager<User, User>(new User());

            Dictionary<String, User> dic1 = new Dictionary<string, User>();

            d1.Show2<User>();

            List<string> strings = new List<string>();
            strings.Add("aozieozaije");
            int nbElement = strings.Count;
            strings.Clear();

            strings.Add("a");
            if (strings.Contains("a"))
            {
                Console.WriteLine("a");
                strings.Remove("a");
            }

            if (!strings.Contains("a"))
            {
                Console.WriteLine("pas a");
            }

            strings.Add("b");

            strings.ElementAt(strings.IndexOf("b"));

            // De Morgan
            int el1 = 10;
            int el2 = 20;
            if (!(el1 < 0 && el2 > 20))
            {

            }
            // <=>
            if (el1 >= 0 || el2 <= 20)
            {

            }

            List<List<String>> strings2 = new List<List<string>>();
            strings2.Add(new List<string>() { "a", "b" });

            foreach (var item in strings2)
            {
                foreach (var subitem in item)
                {
                    Console.WriteLine(subitem);
                }
            }

            Dictionary<int, string> dico1 = new Dictionary<int, string>();
            dico1.Add(1, "ioazepoij");
            dico1.Add(2, "ioazepoij");

            dico1[1] = "iaopzejoiodifjspdf";

            foreach (var item in dico1)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            int[,] tab1 = new int[2,5];

            // Ne sourtout pas utiliser
            dynamic yolo = "azoieuao";
            yolo = 10;
            yolo.yala = 10;

            var test1 = new ObjectDisplayManager<User, User>(new User());
            //var test2 = test1.Yololo();
            int test2 = test1.Yololo();


            Console.ReadKey();
        }
    }
}
