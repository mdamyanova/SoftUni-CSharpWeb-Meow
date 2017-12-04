namespace Meow.Data.Validation
{
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

            // todo: add all cities in bg
            return true;
        }
    }
}