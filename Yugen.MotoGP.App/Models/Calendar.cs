using System;

namespace Yugen.MotoGP.App.Models
{
    public class Calendar
    {
        public Event[] events { get; set; }
    }

    public class Event
    {
        public string id { get; set; }

        public string shortname { get; set; }

        public string name { get; set; }

        public string url { get; set; }

        public Asset[] assets { get; set; }

        public DateTime date_start { get; set; }

        public DateTime date_end { get; set; }

        public string country { get; set; }

        public string time_zone { get; set; }

        public string status { get; set; }

        public string type { get; set; }

        public string kind { get; set; }

        public Circuit circuit { get; set; }

        public Category[] categories { get; set; }

        public Event_Categories[] event_categories { get; set; }

        public Business_Unit business_unit { get; set; }

        public Season season { get; set; }

        public Broadcast[] broadcasts { get; set; }

        public Schedule schedule { get; set; }

        public int timing_id { get; set; }

        public Url[] urls { get; set; }

        public Ticketing[] ticketings { get; set; }

        public Next_Broadcast next_broadcast { get; set; }

        public string hashtag { get; set; }

        public int remain { get; set; }
    }

    public class Circuit
    {
        public string id { get; set; }

        public string name { get; set; }

        public string iso_code { get; set; }

        public string country { get; set; }

        public string region { get; set; }

        public string city { get; set; }

        public string postal_code { get; set; }

        public string address { get; set; }

        public string lat { get; set; }

        public string lng { get; set; }

        public string place_id { get; set; }

        public int constructed { get; set; }

        public string designer { get; set; }

        public bool active { get; set; }

        public Timing_Ids1[] timing_ids { get; set; }

        public Track track { get; set; }

        public Circuit_Descriptions[] circuit_descriptions { get; set; }

        public int modified { get; set; }

        public int capacity { get; set; }
    }

    public class Track
    {
        public string id { get; set; }

        public string first_grid { get; set; }

        public bool box_entry { get; set; }

        public bool box_exit { get; set; }

        public string lenght { get; set; }

        public Lenght_Units lenght_units { get; set; }

        public string width { get; set; }

        public Width_Units width_units { get; set; }

        public string longest_straight { get; set; }

        public Longest_Straight_Units longest_straight_units { get; set; }

        public string left_corners { get; set; }

        public string right_corners { get; set; }

        public bool is_active { get; set; }

        public Timing_Ids[] timing_ids { get; set; }

        public DateTime modification_date { get; set; }

        public object assets { get; set; }
    }

    public class Lenght_Units
    {
        public int meters { get; set; }

        public float kiloMeters { get; set; }

        public float miles { get; set; }

        public float feet { get; set; }
    }

    public class Width_Units
    {
        public int meters { get; set; }

        public float kiloMeters { get; set; }

        public float miles { get; set; }

        public float feet { get; set; }
    }

    public class Longest_Straight_Units
    {
        public int meters { get; set; }

        public float kiloMeters { get; set; }

        public float miles { get; set; }

        public float feet { get; set; }
    }

    public class Timing_Ids
    {
        public string business_unit { get; set; }

        public string id { get; set; }
    }

    public class Timing_Ids1
    {
        public string business_unit { get; set; }

        public int id { get; set; }
    }

    public class Circuit_Descriptions
    {
        public string id { get; set; }

        public Business_Unit_Id business_unit_id { get; set; }

        public Business_Unit_Name business_unit_name { get; set; }

        public string language { get; set; }

        public string description { get; set; }
    }

    public class Business_Unit_Id
    {
        public string id { get; set; }
    }

    public class Business_Unit_Name
    {
        public string value { get; set; }
    }

    public class Business_Unit
    {
        public string id { get; set; }

        public string name { get; set; }

        public string acronym { get; set; }
    }

    public class Season
    {
        public string id { get; set; }

        public int year { get; set; }

        public bool current { get; set; }
    }

    public class Schedule
    {
        public Option[] options { get; set; }

        public int selected_day { get; set; }
    }

    public class Option
    {
        public int date { get; set; }

        public string dateStart { get; set; }

        public string name { get; set; }

        public int day { get; set; }

        public string month { get; set; }

        public string day_suffix { get; set; }

        public int gp_day { get; set; }
    }

    public class Next_Broadcast
    {
        public string id_broadcast { get; set; }

        public int remain { get; set; }

        public string type { get; set; }

        public string name { get; set; }

        public string shortname { get; set; }

        public string category_name { get; set; }

        public int gp_day { get; set; }
    }

    public class Asset
    {
        public string type { get; set; }

        public string quality { get; set; }

        public string path { get; set; }

        public string mimetype { get; set; }
    }

    public class Category
    {
        public string id { get; set; }

        public string acronym { get; set; }

        public string name { get; set; }

        public bool active { get; set; }

        public int timing_id { get; set; }

        public int priority { get; set; }
    }

    public class Event_Categories
    {
        public string category_id { get; set; }

        public int category_timing_id { get; set; }

        public int timing_id { get; set; }

        public int sequence { get; set; }

        public Distance distance { get; set; }

        public int num_laps { get; set; }
    }

    public class Distance
    {
        public int meters { get; set; }

        public float kiloMeters { get; set; }

        public float miles { get; set; }

        public float feet { get; set; }
    }

    public class Broadcast
    {
        public string id { get; set; }

        public string shortname { get; set; }

        public string name { get; set; }

        public string date_start { get; set; }

        public string date_end { get; set; }

        public int remain { get; set; }

        public string type { get; set; }

        public string kind { get; set; }

        public string status { get; set; }

        public int progressive { get; set; }

        public bool has_timing { get; set; }

        public bool has_live { get; set; }

        public bool has_report { get; set; }

        public bool has_results { get; set; }

        public bool has_on_demand { get; set; }

        public bool is_live { get; set; }

        public bool is_live_timing { get; set; }

        public Category1 category { get; set; }

        public int gp_day { get; set; }

        public int timing_id { get; set; }

        public int num_laps { get; set; }
    }

    public class Category1
    {
        public string id { get; set; }

        public string acronym { get; set; }

        public string name { get; set; }

        public bool active { get; set; }

        public int timing_id { get; set; }

        public int priority { get; set; }
    }

    public class Url
    {
        public string id { get; set; }

        public string language { get; set; }

        public string url { get; set; }

        public string type { get; set; }
    }

    public class Ticketing
    {
        public string id { get; set; }

        public string language { get; set; }

        public string url { get; set; }

        public string type { get; set; }
    }
}