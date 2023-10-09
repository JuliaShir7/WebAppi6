using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace WebAppi6.Models
{
    public interface IPreferencable
    {
    }
    public enum Role
    {
        Admin,
        Moderator,
        Company,
        Individual
    }
    public enum Gender
    {
        Male,
        Female
    } 
    public enum PhaseOfConcideration
    {
        Accepted,
        IsProcessing,
        Completed
    }
    public enum Transport
    {
        [Description("Пешком")]
        OnFoot,
        [Description("На автомобиле")]
        Auto,
        [Description("На автобусе")]
        Bus
    }
    public static class ValueConverter
    {
        public static object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                return Enum.Parse(typeof(Transport), s.Substring(0, s.IndexOf(':')));
            }
            return null;
        }
        public static string GetString(Transport type)
        {
            return GetDescription(type);
        }
        public static string GetDescription(Transport format)
        {
            if (format != 0)
                return format.GetType().GetMember(format.ToString())[0].GetCustomAttribute<DescriptionAttribute>().Description;
            else return "";
        }
        public static string[] GetStrings()
        {
            List<string> list = new List<string>();
            foreach (Transport format in Enum.GetValues(typeof(Transport)))
            {
                list.Add(GetString(format));
            }
            return list.ToArray();

        }
    }
}
