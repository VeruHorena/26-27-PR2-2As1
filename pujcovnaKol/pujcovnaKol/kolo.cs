using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pujcovnaKol
{
    internal class kolo
    {
        private int id;
        private string druh;
        private int najetekm;

        public kolo(int najetekm)
        {
            this.najetekm = najetekm;
        }

        public int Id { get => id; set => id = value; }
        public string Druh { get => druh; set => druh = value; }

        public kolo(int id, string druh, int najetekm)
        {
            this.id = id;
            this.druh = druh;
            this.najetekm =najetekm;
        }
        public override string ToString()
        {
            return ($"Kolo ma id:{id}");
        }

    }
}
