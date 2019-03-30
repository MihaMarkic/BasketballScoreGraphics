using BasketballScoreGraphics.Engine.Config;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace BasketballScoreGraphics.Engine.Services.Implementation
{
    public static class ConfigLoader
    {
        static readonly string root;

        static ConfigLoader ()
        {
            root = Path.Combine(Path.GetDirectoryName(typeof(ConfigLoader).Assembly.Location), "config");
        }
        public static Configuration Load()
        {
            string roosterPath = Path.Combine(root, "rooster.xml");
            if (File.Exists(roosterPath))
            {
                var doc = XDocument.Load(roosterPath);
                var config = new Configuration(
                    teams: (from t in doc.Root.Elements("Team")
                            select new Team(
                                name: (string)t.Attribute("Name"),
                                logo: (string)t.Attribute("Logo"),
                                color: ConvertToUint((string)t.Attribute("Color")),
                                players: null
                            )).ToArray()
                    );
                return config;
            }
            else
            {
                return null;
            }
        }

        public static string GetImagePath(string imageName)
        {
            return Path.Combine(root, imageName);
        }

        static uint ConvertToUint(string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                return Convert.ToUInt32(source, 16);
            }
            return 0;
        }
    }
}
