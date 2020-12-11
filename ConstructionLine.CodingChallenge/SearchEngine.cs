using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts ?? new List<Shirt>();
        }


        public SearchResults Search(SearchOptions options)
        {
            if (options == null) return ConvertToDto(_shirts);

            var shirts = _shirts.AsQueryable();

            if (options.Colors.Any())
            {
                shirts = shirts.Where(x => options.Colors.Contains(x.Color));
            }

            if (options.Sizes.Any())
            {
                shirts = shirts.Where(x => options.Sizes.Contains(x.Size));
            }

            var results = shirts.ToList();
            return ConvertToDto(results);
        }

        private SearchResults ConvertToDto(List<Shirt> shirts)
        {
            return new SearchResults
            {
                Shirts = shirts,
                ColorCounts = Color.All.Select(x => new ColorCount { Color = x, Count = shirts.Count(z => z.Color == x) }).ToList(),
                SizeCounts = Size.All.Select(x => new SizeCount { Size = x, Count = shirts.Count(z => z.Size == x) }).ToList()
            };
        }
    }
}