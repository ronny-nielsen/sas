using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        [Test]
        public void WhenSearchingGivenNoShirtsShouldReturnResult()
        {
            var searchEngine = new SearchEngine(null);
            var results = searchEngine.Search(null);
            Assert.IsEmpty(results.Shirts);
        }

        [Test]
        public void WhenSearchingGivenEmptyShirtsShouldReturnResult()
        {
            var searchEngine = new SearchEngine(new List<Shirt>());
            var results = searchEngine.Search(null);
            Assert.IsEmpty(results.Shirts);
        }

        [Test]
        public void WhenSearchingGivenNoOptionsShouldReturnResult()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var results = searchEngine.Search(null);
            Assert.AreEqual(3, results.Shirts.Count);
        }

        [Test]
        public void WhenSearchingGivenNoOptionsShouldReturnResultItems()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var results = searchEngine.Search(null);
            AssertResults(results.Shirts, new SearchOptions());
        }

        [Test]
        public void WhenSearchingGivenNoOptionsShouldReturnResultSizeCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var results = searchEngine.Search(null);
            AssertSizeCounts(shirts, new SearchOptions(), results.SizeCounts);
        }

        [Test]
        public void WhenSearchingGivenNoOptionsShouldReturnResultColorCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var results = searchEngine.Search(null);
            AssertColorCounts(shirts, new SearchOptions(), results.ColorCounts);
        }

        [Test]
        public void WhenSearchingGivenEmptyOptionsShouldReturnResultCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);
            var searchOptions = new SearchOptions();

            var results = searchEngine.Search(searchOptions);
            Assert.AreEqual(3, results.Shirts.Count);
        }

        [Test]
        public void WhenSearchingGivenEmptyOptionsShouldReturnResultItems()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);
            var searchOptions = new SearchOptions();

            var results = searchEngine.Search(searchOptions);
            AssertResults(results.Shirts, searchOptions);
        }

        [Test]
        public void WhenSearchingGivenEmptyOptionsShouldReturnResultSizeCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);
            var searchOptions = new SearchOptions();

            var results = searchEngine.Search(searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
        }

        [Test]
        public void WhenSearchingGivenEmptyOptionsShouldReturnResultColorCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);
            var searchOptions = new SearchOptions();

            var results = searchEngine.Search(searchOptions);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void WhenSearchingGivenColorShouldReturnResultCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);
            Assert.AreEqual(1, results.Shirts.Count);
        }

        [Test]
        public void WhenSearchingGivenColorShouldReturnResultItems()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);
            AssertResults(results.Shirts, searchOptions);
        }

        [Test]
        public void WhenSearchingGivenColorShouldReturnResultSizeCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
        }

        [Test]
        public void WhenSearchingGivenColorShouldReturnResultColorCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void WhenSearchingGivenColorAndSizeOptionsShouldReturnResultCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };

            var results = searchEngine.Search(searchOptions);
            Assert.AreEqual(1, results.Shirts.Count);
        }

        [Test]
        public void WhenSearchingGivenColorAndSizeOptionsShouldReturnResultItems()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red },
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);
            AssertResults(results.Shirts, searchOptions);
        }

        [Test]
        public void WhenSearchingGivenColorAndSizeOptionsShouldReturnResultColorSize()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red },
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void WhenSearchingGivenColorAndSizeOptionsShouldReturnResultSizeCount()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red },
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
        }
    }
}