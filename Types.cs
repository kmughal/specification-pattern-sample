namespace SpecificationPatternSample
{
    using System;
    using System.Collections.Generic;

    public record Movie(string Name, DateTime ReleaseDateTime, List<Actor> Actors);
    public record Address(string LineAddress1, string LineAddress2, string PostCode, string County, string Country);

    public record Actor(string FistName, string LastName, Gender Gender, Address Address);

    public enum Gender
    {
        Male, FeMale
    }

    public enum Countries
    {
        UK,
        USA
    }

}