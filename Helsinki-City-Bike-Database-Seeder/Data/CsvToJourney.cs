using Helsinki_City_Bike_Database_Seeder.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace Helsinki_City_Bike_Database_Seeder.Data
{
    public class CsvToJourney
    {
        public static List<Journey> Journeys()
        {
            var journeys = new List<Journey>();
            var journeyUrls = new List<string>
            {
                "https://dev.hsl.fi/citybikes/od-trips-2021/2021-05.csv",
                "https://dev.hsl.fi/citybikes/od-trips-2021/2021-06.csv",
                "https://dev.hsl.fi/citybikes/od-trips-2021/2021-07.csv"
            };



            foreach (string journeyurl in journeyUrls)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(journeyurl);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                try
                {
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

                            var journey = new Journey()
                            {
                                DepartureTime = DateTime.Parse(values[0]),
                                ReturnTime = DateTime.Parse(values[1]),
                                DepartureStationID = ValidatedInt(values[2]),
                                ReturnStationID = ValidatedInt(values[4]),
                                Distance = ValidatedInt(values[6]),
                                Duration = ValidatedInt(values[7])
                            };
                            journeys.Add(journey);
                        }
                    }
                }
                catch (FileNotFoundException) { Console.WriteLine("File Not Found"); }
            }
            return journeys;
        }

        public static int ValidatedInt(string value)
        {
            int i;
            bool result;
            result = int.TryParse(value, out i);
            if (result)
            {
                return i;
            }
            else
            {
                return 0;
            }
        }
    }
}
