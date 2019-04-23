using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FinalProject.Models
{
    public partial class Recipe
    {
        [JsonProperty("q")]
        public string Q { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("params")]
        public Params Params { get; set; }

        [JsonProperty("more")]
        public bool More { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("hits")]
        public List<Hit> Hits { get; set; }
    }

    public partial class Hit
    {
        [JsonProperty("recipe")]
        public RecipeClass Recipe { get; set; }

        [JsonProperty("bookmarked")]
        public bool Bookmarked { get; set; }

        [JsonProperty("bought")]
        public bool Bought { get; set; }
    }

    public partial class RecipeClass
    {
        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("shareAs")]
        public Uri ShareAs { get; set; }

        [JsonProperty("yield")]
        public long Yield { get; set; }

        [JsonProperty("dietLabels")]
        public List<string> DietLabels { get; set; }

        [JsonProperty("healthLabels")]
        public List<string> HealthLabels { get; set; }

        [JsonProperty("cautions")]
        public List<string> Cautions { get; set; }

        [JsonProperty("ingredientLines")]
        public List<string> IngredientLines { get; set; }

        [JsonProperty("ingredients")]
        public List<Ingredient> Ingredients { get; set; }

        [JsonProperty("calories")]
        public double Calories { get; set; }

        [JsonProperty("totalWeight")]
        public double TotalWeight { get; set; }

        [JsonProperty("totalTime")]
        public long TotalTime { get; set; }

        [JsonProperty("totalNutrients")]
        public Dictionary<string, Total> TotalNutrients { get; set; }

        [JsonProperty("totalDaily")]
        public Dictionary<string, Total> TotalDaily { get; set; }

        [JsonProperty("digest")]
        public List<Digest> Digest { get; set; }
    }

    public partial class Digest
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("schemaOrgTag")]
        public string SchemaOrgTag { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("hasRDI")]
        public bool HasRdi { get; set; }

        [JsonProperty("daily")]
        public double Daily { get; set; }

        [JsonProperty("unit")]
        public String Unit { get; set; }

        [JsonProperty("sub", NullValueHandling = NullValueHandling.Ignore)]
        public List<Digest> Sub { get; set; }
    }

    public partial class Ingredient
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }

    public partial class Total
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("unit")]
        public String Unit { get; set; }
    }

    public partial class Params
    {
        [JsonProperty("sane")]
        public List<object> Sane { get; set; }

        [JsonProperty("q")]
        public List<string> Q { get; set; }

        [JsonProperty("app_key")]
        public List<string> AppKey { get; set; }

        [JsonProperty("health")]
        public List<string> Health { get; set; }

        [JsonProperty("from")]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public List<long> From { get; set; }

        [JsonProperty("to")]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public List<long> To { get; set; }

        [JsonProperty("calories")]
        public List<string> Calories { get; set; }

        [JsonProperty("app_id")]
        public List<string> AppId { get; set; }
    }

    public partial class Recipe
    {
        public static Recipe FromJson(string json) => JsonConvert.DeserializeObject<Recipe>(json, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(List<long>);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = ParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (List<long>)untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = ParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
