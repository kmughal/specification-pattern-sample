namespace SpecificationPatternSample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static List<Movie> movies = new List<Movie> {
                new Movie("Movie 1", DateTime.Now.AddYears(-1), new List<Actor> {
                new Actor("abc", "def",
                Gender.Male,
                new Address("Street1", "Street2", "Not known", "Home", "UK"))}),


                new Movie("Movie 2", DateTime.Now, new List<Actor> {
                new Actor("abc", "def",
                Gender.Male,
                new Address("Street1", "Street2", "Not known", "Home", "UK"))}),


                new Movie("Movie 3", DateTime.Now.AddYears(-3), new List<Actor> {
                new Actor("abc", "def",
                Gender.Male,
                new Address("Street1", "Street2", "Not known", "Home", "UK"))}),


                new Movie("Movie 4", DateTime.Now.AddYears(-7), new List<Actor> {
                new Actor("abc", "def",
                Gender.Male,
                new Address("Street1", "Street2", "Not known", "Home", "UK"))}),
        };

        static void Main(string[] args)
        {
            var specs = new SpecificationPattern<Movie>(m => m.ReleaseDateTime.Year == 2021)
              .OrSpecification(new SpecificationPattern<Movie>(m => m.Name == "Movie 1"));

            foreach (var movie in movies.Where(specs.IsSatisfied))
            {
                Console.WriteLine(movie.ToString());
            }
        }
    }
}
