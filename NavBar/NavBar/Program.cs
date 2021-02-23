using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NavBar
{
    class Program
    {
        static void Main(string[] args)
        {

            Tree tree = new Tree();

            using (var reader = new StreamReader("../../Navigation.csv")) {
                reader.ReadLine();

                while (!reader.EndOfStream) {

                    var line = reader.ReadLine();
                   
                    Node node = Node.CreateNode(line);

                    bool placed = tree.PlaceNode(node);

                    if (!placed) {
                        tree.toBePlaced.Add(node);
                    }
                  
                }
            }
            if (tree.toBePlaced.Count != 0) {
                tree.PlaceTheRest();
            }


            tree.print_tree(tree.Root,"");
            Console.WriteLine();
        }
    }
}
