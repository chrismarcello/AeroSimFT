using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.ViewModels
{
    public class Continents
    {
        private string? continentCode;
        private string? continentName;
        private bool continentSelected = false;
        public Continents() { }

        public Continents(string continentCode, string continentName)
        {
            ContinentCode = continentCode;
            ContinentName = continentName;
        }

        public string ContinentCode { get { return continentCode!; } set { continentCode = value; } }
        public string ContinentName { get { return continentName!; } set { continentName = value; } }
        public bool ContinentSelected { get { return continentSelected; } set { continentSelected = value; } }
    }
}
