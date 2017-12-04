namespace Meow.Data.Validation
{
    using System;

    public class BirthdateAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        public bool IsValid(object value)
        {
            var birthdate = value as string;

            if (birthdate == null)
            {
                return true;
            }

            var date = DateTime.Parse(birthdate);

            var today = DateTime.Now;
            var validDate = new DateTime(today.Year - 21, today.Month, today.Day);

            var validAge = today.Subtract(validDate);
            var actualAge = today.Subtract(date);

            return TimeSpan.Compare(validAge, actualAge) >= 18;
        }
    }
}