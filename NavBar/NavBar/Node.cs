using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavBar
{
    class Node
    {
        public List<Node> children { get; private set; }


        public int? Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public bool isHidden { get; set; }

        public string LinkURL { get; set; }


        public Node(int? id, string name, int? parentid, bool ishidden, string linkurl) {
            this.Id = id;
            this.Name = name;
            this.ParentId = parentid;
            this.isHidden = ishidden;
            this.LinkURL = linkurl;
            children = new List<Node>();
            
        }

        public override string ToString()
        {
            return this.Name;
        }

        public static Node CreateNode(string data) {
            string[] values = data.Split(';');


                //Console.WriteLine(values[0]);
                int? id = int.Parse(values[0]);
                string name = values[1];
                int parentId;
                bool success = int.TryParse(values[2], out parentId);
                bool hidden = Boolean.Parse(values[3]);
                string url = values[4];

                var node = new Node(id, name, parentId, hidden, url);

                return node;
        }

    }
}
