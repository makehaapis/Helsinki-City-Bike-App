using Helsinki_City_Bike_Database_Seeder.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace Helsinki_City_Bike_Database_Seeder.Data
{
    public class CsvToStation
    {
        public static List<Station> Stations()
        {
            var stations = new List<Station>();
            var stationUrl = "https://opendata.arcgis.com/datasets/726277c507ef4914b0aec3cbcfcbfafc_0.csv";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(stationUrl);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (var reader = new StreamReader(resp.GetResponseStream()))
                {
                    string header = reader.ReadLine();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Replacing commas between quotas
                        var regex = new Regex("\\\"(.*?)\\\"");
                        var output = regex.Replace(line, m => m.Value.Replace(',', ' '));
                        string[] values = output.Split(",");

                        var station = new Station()
                        {
                            StationID = int.Parse(values[1]),
                            Name = values[2],
                            Address = values[5],
                            Capacity = int.Parse(values[10]),
                            Longitude = values[11],
                            Latitude = values[12]
                        };
                        stations.Add(station);
                    }
                }
                return stations;

            }
            catch (FileNotFoundException) { Console.WriteLine("File Not Found"); }
            return stations;
        }
    }
}
