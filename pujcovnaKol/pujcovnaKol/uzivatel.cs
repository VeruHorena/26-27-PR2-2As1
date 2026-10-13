using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pujcovnaKol
{
    internal class uzivatel
    {
        private int id;
        private string jmeno;
        private List<kolo> seznamkol;

        public int Id { get => id; set => id = value; }
        public string Jmeno { get => jmeno; set => jmeno = value; }
        internal List<kolo> Seznamkol { get => seznamkol; set => seznamkol = value;
        
        public uzivatel(int id, string jmeno)
        {
            this.id = id;
            this.jmeno = jmeno;
            Seznamkol = new List<kolo>();
        }

        public override string ToString()
        {
            string pomocni = jmeno + " ";
            foreach (var k in seznamkol)
            {
                pomocni = pomocni + k.ToString();
            }

            return pomocni;
        }
        }
    }
}
