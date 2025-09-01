using AeroSimFT.Data;
using AeroSimFT.EFModels;
using AeroSimFT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.Services
{
   public class LocationServices
    {
        public static async Task<List<Continents>> GetContinents()
        {

            List<Continents> continents = new List<Continents>();
            using var context = new FlightSimContext();

            var cty = context.Countries.GroupBy(c => c.Continent)
                                       .Select(y => new { ContinentCode = y.Key })
                                       .ToList();
            foreach (var con in cty)
            {
                Continents c = new Continents();
                switch (con.ContinentCode)
                {
                    case "NA":
                        c.ContinentCode = con.ContinentCode.ToString();
                        c.ContinentName = "North America";
                        break;
                    case "EU":
                        c.ContinentCode = con.ContinentCode.ToString();
                        c.ContinentName = "Europe";
                        break;
                    case "OC":
                        c.ContinentCode = con.ContinentCode.ToString();
                        c.ContinentName = "Oceania";
                        break;
                    case "SA":
                        c.ContinentCode = con.ContinentCode.ToString();
                        c.ContinentName = "South America";
                        break;
                    case "AF":
                        c.ContinentCode = con.ContinentCode.ToString();
                        c.ContinentName = "Africa";
                        break;
                    case "AS":
                        c.ContinentCode = con.ContinentCode.ToString();
                        c.ContinentName = "Asia";
                        break;
                    case "AN":
                        c.ContinentCode = con.ContinentCode.ToString();
                        c.ContinentName = "Antartica";
                        break;
                    default:
                        break;
                }
                continents.Add(c);
            }
            return continents;
        }
    }
}
