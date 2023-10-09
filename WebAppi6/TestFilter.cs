using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebAppi6.Models;

namespace WebAppi6
{
    public class TestFilter
    {
        List<SubCategory> subcategories;
        public TestFilter(ApplicationContext context)
        {
            subcategories = context.SubCategories.ToList();
        }
        static Dictionary<string, List<string>> ReturnAllRegionsWithCities()
        {
            string fileName = "citiesAndRegions.json";
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText(fileName));
            var jsonString = jsonObject.ToString(Newtonsoft.Json.Formatting.None);
            //Console.Write(jsonString);
            var values = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonString);
            return values;
        }
        static List<Attraction> ChooseSuitableForCityAttractions(List<Attraction> attractions, List<string> choosedCities)
        {
            List<Attraction> choosedAttractions = new List<Attraction>();
            //идти только по выбранным пользователем
            foreach (var c in choosedCities)
            {
                foreach (var a in attractions)
                {
                    if (a.Address.Contains(c))
                        choosedAttractions.Add(a);
                }
            }
            return choosedAttractions;
        }
        public List<Attraction> ChooseBySubCategories(List<Attraction> attractions, List<SubCategory> subCategories)
        {
            List<Attraction> choosedAttractions = new List<Attraction>();
            if (subCategories.Count == 0)
                return attractions;
            foreach (var a in attractions)
            {
                foreach (var asc in a.SubCategories)
                {
                    var l = subCategories.Where(s => s.ID == asc.ID).FirstOrDefault();
                    if (l is not null)
                    {
                        choosedAttractions.Add(a);
                        break;
                    }
                }
            }

            return choosedAttractions;
        }
        public List<Attraction> ChooseByCuisine(List<Attraction> cafes, List<Cuisine> cuisines)
        {
            List<Attraction> choosedCafes = new List<Attraction>();
            if (cuisines.Count == 0)
                return cafes;
            foreach (var a in cafes)
            {
                foreach (var asc in a.Cuisines)
                {
                    var l = cuisines.Where(s => s.ID == asc.ID).FirstOrDefault();
                    if (l is not null)
                    {
                        choosedCafes.Add(a);
                        break;
                    }
                }
            }
            return choosedCafes;
        }
        public List<Attraction> ChooseByFoodRestrictions(List<Attraction> cafes, List<FoodRestriction> restrictions)
        {
            List<Attraction> choosedCafes = new List<Attraction>();
            if (restrictions.Count == 0)
                return cafes;
            foreach (var a in cafes)
            {
                foreach (var asc in a.FoodRestrictions)
                {
                    var l = restrictions.Where(s => s.ID == asc.ID).FirstOrDefault();
                    if (l is not null)
                    {
                        choosedCafes.Add(a);
                        break;
                    }
                }
            }
            return choosedCafes;
        }
        static List<Attraction> ChooseByWorkingHours(List<Attraction> attractions)
        {
            List<Attraction> choosedAttractions = new List<Attraction>();
            ////идти только по выбранным пользователем
            //foreach (var c in choosedCities)
            //{
            //    foreach (var a in attractions)
            //    {
            //        if (a.Address.Contains(c))
            //            choosedAttractions.Add(a);
            //    }
            //}
            return choosedAttractions;
        }
    }
}
