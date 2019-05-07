using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xamarin.Forms;

namespace FinalProject.Models
{
    public partial class DrinkDetail
    {

        [JsonProperty("idDrink")]
        public string IdDrink { get; set; }

        [JsonProperty("strDrink")]
        public string StrDrink { get; set; }

        [JsonProperty("strDrinkAlternate")]
        public string strDrinkAlternate { get; set; }

        [JsonProperty("strDrinkES")]
        public string strDrinkES { get; set; }

        [JsonProperty("strDrinkDE")]
        public string strDrinkDE { get; set; }

        [JsonProperty("strDrinkFR")]
        public string strDrinkFR { get; set; }

        [JsonProperty("strDrinkZH-HANS")]
        public string strDrinkZH { get; set; }

        [JsonProperty("strDrinkZH-HANT")]
        public string strDrinkZHH { get; set; }

        [JsonProperty("strTags")]
        public string strTags { get; set; }

        [JsonProperty("strVideo")]
        public string strVideo { get; set; }

        [JsonProperty("strCategory")]
        public string strCategory { get; set; }

        [JsonProperty("strIBA")]
        public string strIBA { get; set; }

        [JsonProperty("strAlcoholic")]
        public string strAlcoholic { get; set; }

        [JsonProperty("strGlass")]
        public string strGlass { get; set; }

        [JsonProperty("strInstructions")]
        public string strInstructions { get; set; }

        [JsonProperty("strInstructionsES")]
        public string strInstructionsES { get; set; }

        [JsonProperty("strInstructionsDE")]
        public string strInstructionsDE { get; set; }

        [JsonProperty("strInstructionsFR")]
        public string strInstructionsFR { get; set; }

        [JsonProperty("strInstructionsZH-HANS")]
        public string strInstructionsZH { get; set; }

        [JsonProperty("strInstructionsZH-HANT")]
        public string strInstructionsZHH { get; set; }

        [JsonProperty("strDrinkThumb")]
        public Uri StrDrinkThumb { get; set; }

        [JsonProperty("strIngredient1")]
        public string strIngredient1 { get; set; }

        [JsonProperty("strIngredient2")]
        public string strIngredient2 { get; set; }

        [JsonProperty("strIngredient3")]
        public string strIngredient3 { get; set; }

        [JsonProperty("strIngredient4")]
        public string strIngredient4 { get; set; }

        [JsonProperty("strIngredient5")]
        public string strIngredient5 { get; set; }

        [JsonProperty("strIngredient6")]
        public string strIngredient6 { get; set; }

        [JsonProperty("strIngredient7")]
        public string strIngredient7 { get; set; }

        [JsonProperty("strIngredient8")]
        public string strIngredient8 { get; set; }

        [JsonProperty("strIngredient9")]
        public string strIngredient9 { get; set; }

        [JsonProperty("strIngredient10")]
        public string strIngredient10 { get; set; }

        [JsonProperty("strIngredient11")]
        public string strIngredient11 { get; set; }

        [JsonProperty("strIngredient12")]
        public string strIngredient12 { get; set; }

        [JsonProperty("strIngredient13")]
        public string strIngredient13 { get; set; }

        [JsonProperty("strIngredient14")]
        public string strIngredient14 { get; set; }

        [JsonProperty("strIngredient15")]
        public string strIngredient15 { get; set; }

        [JsonProperty("strMeasure1")]
        public string strMeasure1 { get; set; }

        [JsonProperty("strMeasure2")]
        public string strMeasure2 { get; set; }

        [JsonProperty("strMeasure3")]
        public string strMeasure3 { get; set; }

        [JsonProperty("strMeasure4")]
        public string strMeasure4 { get; set; }

        [JsonProperty("strMeasure5")]
        public string strMeasure5 { get; set; }

        [JsonProperty("strMeasure6")]
        public string strMeasure6 { get; set; }

        [JsonProperty("strMeasure7")]
        public string strMeasure7 { get; set; }

        [JsonProperty("strMeasure8")]
        public string strMeasure8 { get; set; }

        [JsonProperty("strMeasure9")]
        public string strMeasure9 { get; set; }

        [JsonProperty("strMeasure10")]
        public string strMeasure10 { get; set; }

        [JsonProperty("strMeasure11")]
        public string strMeasure11 { get; set; }

        [JsonProperty("strMeasure12")]
        public string strMeasure12 { get; set; }

        [JsonProperty("strMeasure13")]
        public string strMeasure13 { get; set; }

        [JsonProperty("strMeasure14")]
        public string strMeasure14 { get; set; }

        [JsonProperty("strMeasure15")]
        public string strMeasure15 { get; set; }

        [JsonProperty("dateModified")]
        public string dateModified { get; set; }
    }

    public class CocktailDetail
    {

        [JsonProperty("drinks")]
        public List<DrinkDetail> drinks { get; set; }
    }
}