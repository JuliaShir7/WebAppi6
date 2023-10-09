using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppi6.Models
{
    public class Attraction
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int MaxRating { get; set; }
        public int? RatingCount { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Site { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Duration { get; set; }
        public string? Prices { get; set; }
        public string? Image { get; set; }
        public string Url { get; set; }
        public virtual WorkingHours WorkingHours { get; set; } 
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; } 
        public virtual ICollection<Cuisine> Cuisines { get; set; }
        public virtual ICollection<FoodRestriction> FoodRestrictions { get; set; } 

        public Attraction() { }

        public Attraction(string name, double rating, int maxRating, int ratingCount, string? email, string? phone, string? site, string description, string address, double latitude, double longitude, string? duration, string? prices, string? image, string url)
        {
            Name = name;
            Rating = rating;
            MaxRating = maxRating;
            RatingCount = ratingCount;
            Email = email;
            Phone = phone;
            Site = site;
            Description = description;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            Duration = duration;
            Prices = prices;
            Image = image;
            Url = url;
            WorkingHours = new WorkingHours();
            SubCategories = new List<SubCategory>();
        }
        public Attraction(string name, double rating, int maxRating, int? ratingCount, string? email, string? phone, string? site, string? description, string? address, double latitude, double longitude, string? duration, string? prices, string? image, string url, WorkingHours workingHours, ICollection<SubCategory> subCategories, List<Review> reviews)
        {
            Name = name;
            Rating = rating;
            MaxRating = maxRating;
            RatingCount = ratingCount;
            Email = email;
            Phone = phone;
            Site = site;
            Description = description;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            Duration = duration;
            Prices = prices;
            Image = image;
            Url = url;
            WorkingHours = workingHours == null ? new WorkingHours() : workingHours;
            Reviews = reviews == null ? new List<Review>() : reviews;
            SubCategories = subCategories == null ? new List<SubCategory>() : subCategories;
        }
        public Attraction(string name, double rating, int maxRating, int? ratingCount, string? email, string? phone, string? site, string? description, string? address, double latitude, double longitude, string? duration, string? prices, string? image, string url, WorkingHours workingHours, ICollection<SubCategory> subCategories, List<Review> reviews, List<Cuisine> cuisines, List<FoodRestriction> foodRestrictions)
        {
            Name = name;
            Rating = rating;
            MaxRating = maxRating;
            RatingCount = ratingCount;
            Email = email;
            Phone = phone;
            Site = site;
            Description = description;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            Duration = duration;
            Prices = prices;
            Image = image;
            Url = url;
            WorkingHours = workingHours == null ? new WorkingHours() : workingHours;
            Reviews = reviews == null ? new List<Review>() : reviews;
            SubCategories = subCategories == null ? new List<SubCategory>() : subCategories;

            Cuisines = cuisines == null ? new List<Cuisine>() : cuisines;
            FoodRestrictions = foodRestrictions == null ? new List<FoodRestriction>() : foodRestrictions;
        }
        public Attraction(long iD, string name, double rating, int maxRating, int? ratingCount, string? email, string? phone, string? site, string? description, string? address, double latitude, double longitude, string? duration, string? prices, string? image, string url)
        {
            ID = iD;
            Name = name;
            Rating = rating;
            MaxRating = maxRating;
            RatingCount = ratingCount;
            Email = email;
            Phone = phone;
            Site = site;
            Description = description;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            Duration = duration;
            Prices = prices;
            Image = image;
            Url = url;
        }
    }

    //public class Cafe : Attraction
    //{
    //    public virtual ICollection<Cuisine> Cuisines { get; set; } = new List<Cuisine>();
    //    public virtual ICollection<FoodRestriction> FoodRestrictions { get; set; } = new List<FoodRestriction>();
    //    public Cafe(long id, string name, double rating, int maxRating, int? ratingCount, string? email, string? phone, string? site, string? description, string? address, double latitude, double longitude, string? duration, string? prices, string? image, string url) : base(id, name, rating, maxRating, ratingCount, email, phone, site, description, address, latitude, longitude, duration, prices, image, url)
    //    {
    //        ID = id;
    //        Name = name;
    //        Rating = rating;
    //        MaxRating = maxRating;
    //        RatingCount = ratingCount;
    //        Email = email;
    //        Phone = phone;
    //        Site = site;
    //        Description = description;
    //        Address = address;
    //        Latitude = latitude;
    //        Longitude = longitude;
    //        Duration = duration;
    //        Prices = prices;
    //        Image = image;
    //        Url = url;
    //    }
    //    public Cafe(string name, double rating, int maxRating, int? ratingCount, string? email, string? phone, string? site, string? description, string? address, double latitude, double longitude, string? duration, string? prices, string? image, string url, WorkingHours workingHours, ICollection<SubCategory> subCategories, List<Cuisine> cuisines, List<FoodRestriction> foodRestrictions) : base(name, rating, maxRating, ratingCount, email, phone, site, description, address, latitude, longitude, duration, prices, image, url)
    //    {
    //        Name = name;
    //        Rating = rating;
    //        MaxRating = maxRating;
    //        RatingCount = ratingCount;
    //        Email = email;
    //        Phone = phone;
    //        Site = site;
    //        Description = description;
    //        Address = address;
    //        Latitude = latitude;
    //        Longitude = longitude;
    //        Duration = duration;
    //        Prices = prices;
    //        Image = image;
    //        Url = url;


    //        WorkingHours = workingHours == null ? new WorkingHours() : workingHours;
    //        ////Reviews = reviews == null ? new List<Review>() : reviews;
    //        SubCategories = subCategories == null ? new List<SubCategory>() : subCategories;
    //        Cuisines = cuisines == null ? new List<Cuisine>() : cuisines;
    //        FoodRestrictions = foodRestrictions == null ? new List<FoodRestriction>() : foodRestrictions;
    //    }
    //    public Cafe() : base()
    //    {
    //        ID = base.ID;
    //        Name = base.Name;
    //        Rating = base.Rating;
    //        MaxRating = base.MaxRating;
    //        RatingCount = base.RatingCount;
    //        Email = base.Email;
    //        Phone = base.Phone;
    //        Site = base.Site;
    //        Description = base.Description;
    //        Address = base.Address;
    //        Image = base.Image;
    //        Latitude = base.Latitude;
    //        Longitude = base.Longitude;
    //        Duration = base.Duration;
    //        Prices = base.Prices;
    //        Url = base.Url;
    //        WorkingHours = base.WorkingHours;
    //        //Reviews = base.Reviews;
    //        SubCategories = base.SubCategories;
    //    }
    //}
}