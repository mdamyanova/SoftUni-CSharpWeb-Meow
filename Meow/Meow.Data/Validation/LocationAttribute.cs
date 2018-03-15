namespace Meow.Data.Validation
{
    using Meow.Data.Models.Enums;
    using System;

    public class LocationAttribute : Attribute
    {
        public bool IsValid(object value)
        {
            var location = value as string;

            if (location == null)
            {
                return true;
            }

            if (Enum.TryParse(location, out Towns town))
            {
                return true;
            }

            return false;
        }
    }
}