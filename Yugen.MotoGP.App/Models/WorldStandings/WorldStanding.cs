using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.WorldStanding
{
	public class Classification
	{
		[JsonPropertyName("rider")]
		public List<RiderBase> Rider { get; set; }

		[JsonPropertyName("constructor")]
		public object Constructor { get; set; }

		[JsonPropertyName("team")]
		public object Team { get; set; }
	}

	public class Constructor
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("legacy_id")]
		public int LegacyId { get; set; }
	}

	public class Country
	{
		[JsonPropertyName("iso")]
		public string Iso { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("region_iso")]
		public string RegionIso { get; set; }
	}

	public class Files
	{
		[JsonPropertyName("pdf")]
		public string Pdf { get; set; }

		[JsonPropertyName("xml")]
		public string Xml { get; set; }
	}

	public class LastPositions
	{
		[JsonPropertyName("HUN")]
		public int? HUN { get; set; }

		[JsonPropertyName("ITA")]
		public int? ITA { get; set; }

		[JsonPropertyName("CAT")]
		public int? CAT { get; set; }
	}

	public class RiderBase
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("position")]
		public int Position { get; set; }

		[JsonPropertyName("rider")]
		public RiderBase Rider { get; set; }

		[JsonPropertyName("constructor")]
		public Constructor Constructor { get; set; }

		[JsonPropertyName("team_name")]
		public string TeamName { get; set; }

		[JsonPropertyName("session")]
		public string Session { get; set; }

		[JsonPropertyName("points")]
		public int Points { get; set; }

		[JsonPropertyName("pointsFromFirst")]
		public int PointsFromFirst { get; set; }

		[JsonPropertyName("pointsFromPrevious")]
		public int PointsFromPrevious { get; set; }

		[JsonPropertyName("race_wins")]
		public int RaceWins { get; set; }

		[JsonPropertyName("podiums")]
		public int Podiums { get; set; }

		[JsonPropertyName("last_positions")]
		public LastPositions LastPositions { get; set; }

		[JsonPropertyName("sprint_wins")]
		public int SprintWins { get; set; }

		[JsonPropertyName("sprint_podiums")]
		public int SprintPodiums { get; set; }

		[JsonPropertyName("sprint_last_positions")]
		public SprintLastPositions SprintLastPositions { get; set; }

		[JsonPropertyName("position_change")]
		public int PositionChange { get; set; }

		[JsonPropertyName("full_name")]
		public string FullName { get; set; }

		[JsonPropertyName("country")]
		public Country Country { get; set; }

		[JsonPropertyName("legacy_id")]
		public int LegacyId { get; set; }

		[JsonPropertyName("riders_id")]
		public string RidersId { get; set; }

		[JsonPropertyName("number")]
		public int Number { get; set; }

		[JsonPropertyName("riders_api_uuid")]
		public string RidersApiUuid { get; set; }
	}

	public class WorldStanding
	{
		[JsonPropertyName("classification")]
		public Classification Classification { get; set; }

		[JsonPropertyName("files")]
		public Files Files { get; set; }

		[JsonPropertyName("official")]
		public bool Official { get; set; }
	}

	public class SprintLastPositions
	{
		[JsonPropertyName("HUN")]
		public int? HUN { get; set; }

		[JsonPropertyName("ITA")]
		public int? ITA { get; set; }

		[JsonPropertyName("CAT")]
		public int? CAT { get; set; }
	}


}