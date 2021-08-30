using System;
using System.Reflection;
using System.Text.RegularExpressions;
using DoctorWho.Db.Domain;

namespace DoctorWho.Web.Utils
{
    
    public class EpisodeLocatorUtils
    {
        public static string GetEpisodeLocator(object episodeRepresentation)
        {
            var (seriesNumberProperty,
                episodeNumberProperty) = GetPropertiesInfo(episodeRepresentation);

            int seriesNumber = (int) seriesNumberProperty.GetValue(episodeRepresentation);
            int episodeNumber = (int) episodeNumberProperty.GetValue(episodeRepresentation);

            return $"S{seriesNumber:00}:E{episodeNumber:00}";
        }

        public static void SetEpisodeLocator(object episodeRepresentation, string locator)
        {
            var (seriesNumberProperty, episodeNumberProperty) = GetPropertiesInfo(episodeRepresentation);

            var (episodeNumber, seriesNumber) = GetNumbers(locator);

            episodeNumberProperty.SetValue(episodeRepresentation, episodeNumber);
            seriesNumberProperty.SetValue(episodeRepresentation, seriesNumber);
        }

        private static (PropertyInfo seriesPropertyInfo, PropertyInfo episodePropertyInfo) GetPropertiesInfo(
            object representation)
        {
            Type representationType = representation.GetType();
            PropertyInfo seriesNumberProperty = representationType.GetProperty("SeriesNumber");
            PropertyInfo episodeNumberProperty = representationType.GetProperty("EpisodeNumber");
            
            return (seriesNumberProperty, episodeNumberProperty);
        }

        public static (int seriesNumber, int episodeNumber) GetNumbers(string locator)
        {
            Regex seriesRegex = new Regex("(?<=(^S))(\\d){2}");
            Regex episodeRegex = new Regex("(?<=(E))(\\d){2}");

            int episodeNumber = int.Parse(episodeRegex.Match(locator).Value);
            int seriesNumber = int.Parse(seriesRegex.Match(locator).Value);

            return ( seriesNumber,episodeNumber);
        }
    }
}