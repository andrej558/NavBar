using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavBar
{
    class Tree
    {
        public Node Root { get; set; }


        public List<Node> toBePlaced { get; set; }

        public Tree() {
            Root = new Node(null, "", null, true, "");
            toBePlaced = new List<Node>();
        }

        public bool PlaceNode(Node node) {
            //Console.WriteLine(node.ParentId);
            if (node.ParentId == 0) {
                Root.children.Add(node);
                return true;
            }

            for (int i = 0; i < Root.children.Count; i++)
            {
                var nodee = FindNode(Root.children[i], (int)node.ParentId);

                if (nodee != null) {
                    nodee.children.Add(node);
                    return true;
                }
            }

            return false;
        }


        public void PlaceTheRest() {
            for (int i = 0; i < toBePlaced.Count; i++)
            {
                PlaceNode(toBePlaced[i]);
            }
        }
        private Node FindNode(Node node, int id) {
            //we go through each child reccursively of the current node to find the child and we return it.
            if (node.Id == id) {
                return node;
            }

            for (int i = 0; i < node.children.Count; i++)
            {
                var temp = FindNode(node.children[i], id);
                if (temp != null) {
                    return temp;
                }
            }
            return null;   
        }
        public void print_tree(Node node, string indent) {
            if (!node.isHidden) {
                Console.WriteLine(indent + node.Name);
            }
            node.children.Sort((a,b)=>a.Name.CompareTo(b.Name));

            for (int i = 0; i < node.children.Count; i++) {
                print_tree(node.children[i], indent+"...");
            }

        }
    }
}
