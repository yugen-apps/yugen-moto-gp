using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models
{
    public class LiveTiming
    {
        public Lt lt { get; set; }

        public Worldchamp worldchamp { get; set; }
    }

    public class Lt
    {
        public Head head { get; set; }

        public RiderList rider { get; set; }
    }

    public class Head
    {
        public string championship_id { get; set; }

        public string category { get; set; }

        public string circuit_id { get; set; }

        public string circuit_name { get; set; }

        public string global_event_id { get; set; }

        public string event_id { get; set; }

        public string event_tv_name { get; set; }

        public object event_shortname { get; set; }

        public string date { get; set; }

        public int datet { get; set; }

        public string gmt { get; set; }

        public string session_id { get; set; }

        public string session_type { get; set; }

        public string session_name { get; set; }

        public string duration { get; set; }

        public int remaining { get; set; }

        public string session_status_id { get; set; }

        public string session_status_name { get; set; }

        public string date_formated { get; set; }

        public string url { get; set; }

        public string trsid { get; set; }

        public string calendar_event_track { get; set; }
    }

    public class RiderList
    {
        [JsonPropertyName("1")]
        public Rider _1 { get; set; }

        [JsonPropertyName("2")]
        public Rider _2 { get; set; }

        [JsonPropertyName("3")]
        public Rider _3 { get; set; }

        [JsonPropertyName("4")]
        public Rider _4 { get; set; }

        [JsonPropertyName("5")]
        public Rider _5 { get; set; }

        [JsonPropertyName("6")]
        public Rider _6 { get; set; }

        [JsonPropertyName("7")]
        public Rider _7 { get; set; }

        [JsonPropertyName("8")]
        public Rider _8 { get; set; }

        [JsonPropertyName("9")]
        public Rider _9 { get; set; }

        [JsonPropertyName("10")]
        public Rider _10 { get; set; }

        //public Rider 11 { get; set; }

        //public Rider 12 { get; set; }

        //public Rider 13 { get; set; }

        //public Rider 14 { get; set; }

        //public Rider 15 { get; set; }

        //public Rider 16 { get; set; }

        //public Rider 17 { get; set; }

        //public Rider 18 { get; set; }

        //public Rider 19 { get; set; }

        //public Rider 20 { get; set; }

        //public Rider 21 { get; set; }

        //public Rider 22 { get; set; }

        //public Rider 23 { get; set; }

        //public Rider 24 { get; set; }

        //public Rider 25 { get; set; }
    }

    public class Rider
    {
        public string rider_id { get; set; }

        public string pos { get; set; }

        public string rider_number { get; set; }

        public string rider_name { get; set; }

        public string rider_surname { get; set; }

        public string team_name { get; set; }

        public string status_id { get; set; }

        public string status_name { get; set; }

        public string lap_time { get; set; }

        public string num_lap { get; set; }

        public string last_lap { get; set; }

        public string last_lap_time { get; set; }

        public string gap_first { get; set; }

        public string gap_prev { get; set; }

        public string trac_status { get; set; }

        public string rider_url { get; set; }

        public string on_pit { get; set; }
    }

    public class Worldchamp
    {
        public Head1 head { get; set; }

        public Rider1[] rider { get; set; }
    }

    public class Head1
    {
        public string category { get; set; }

        public string lap { get; set; }

        public string champid { get; set; }

        public string last_update_parsed { get; set; }

        public string last_update { get; set; }

        public string session_type { get; set; }

        public string session_name { get; set; }
    }

    public class Rider1
    {
        public string cid { get; set; }

        public string pos { get; set; }

        public string rid { get; set; }

        public string points { get; set; }

        public string bike_name { get; set; }

        public string champ_name { get; set; }

        public string rider_name { get; set; }

        public string rider_surname { get; set; }

        public string lap { get; set; }

        public string numgara { get; set; }

        public string last_update { get; set; }

        public string session_type { get; set; }

        public string session_name { get; set; }

        public string gap_first { get; set; }

        public string gap_prev { get; set; }

        public string rider_url { get; set; }
    }
}