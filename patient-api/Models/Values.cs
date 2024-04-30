namespace patient_api.Models
{
    public class Values
    {
        public enum SearchOperation
        {
            GreaterThan,
            LessThan,
            EqualTo,
            NotEqualTo
        }

        public enum Gender
        {
            male,
            female,
            other,
            unknown
        }
    }
}
