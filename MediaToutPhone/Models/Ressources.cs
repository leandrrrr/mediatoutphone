using System;
using System.Collections.Generic;
using System.Text;

namespace MediaToutPhone.Models
{
    public class Ressources
    {

        public int idressource { get; set; }
        public int idcategorie { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int anneesortie { get; set; }
        public string isbn { get; set; }
        public string langue { get; set; }
        public string libellecategorie { get; set; }

    }
}
