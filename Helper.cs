using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h2mLauncher
{
    internal class Helper
    {
       
        public static string validateGamemode(string shortdesc)
        {
            string gamemodeValidated = "Unknown"; 
            var jsonObj = JObject.Parse(File.ReadAllText(Application.StartupPath + @"/helper.json"));

            // Zugriff auf die gamemodes Liste
            var gamemodes = jsonObj["gamemodes"];

            // Iteriere durch die gamemodes und gib die Schlüssel-Werte-Paare aus
            foreach (var gamemode in gamemodes)
            {
                foreach (var mode in gamemode)
                {
                    if (((JProperty)mode).Name == shortdesc)
                    {
                        gamemodeValidated = ((JProperty)mode).Value.ToString();
                        break;
                    }                
                }             
            }          
            return gamemodeValidated;
        }

        public static string validateMaps(string shortdesc)
        {
            string mapValidated = "Unknown";
            var jsonObj = JObject.Parse(File.ReadAllText(Application.StartupPath + @"/helper.json"));

            // Zugriff auf die gamemodes Liste
            var maps = jsonObj["maps"];

            // Iteriere durch die gamemodes und gib die Schlüssel-Werte-Paare aus
            foreach (var map in maps)
            {
                foreach (var playmap in map)
                {
                    if (((JProperty)playmap).Name == shortdesc)
                    {
                        mapValidated = ((JProperty)playmap).Value.ToString();
                        break;
                    }
                }
            }

       
            return mapValidated;
        }
    }
}
