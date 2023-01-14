using Helsinki_City_Bike_App.Models;
using System.Text.RegularExpressions;

namespace Helsinki_City_Bike_App.Data
{
    public class CsvToStation
    {
        public static List<Station> Stations()
        {
            var stations = new List<Station>();
            try
            {
                using (var reader = new StreamReader("Helsingin_ja_Espoon_kaupunkipy%C3%B6r%C3%A4asemat_avoin.csv"))
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
