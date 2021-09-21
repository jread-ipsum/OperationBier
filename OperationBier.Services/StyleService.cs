using OperationBier.Data;
using OperationBier.Models.StyleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Services
{
    public class StyleService
    {
        private readonly Guid _userId;

        public StyleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStyle(StyleCreate model)
        {
            var entity =
                new Style()
                {
                    AuthorId = _userId,
                    StyleName = model.StyleName,
                    Description = model.Description,
                    IBU = model.IBU,
                    FoodPairing = model.FoodPairing,
                    CountryOfOrigin = model.CountryOfOrigin,
                    RecommendedGlassware = model.RecommendedGlassware
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Styles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StyleListItem> GetStyles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Styles.Select(e => new StyleListItem
                    {
                        StyleName = e.StyleName,
                        StyleId = e.StyleId
                    });
                return query.ToArray();
            }
        }

        public bool UpdateStyle(StyleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Styles.Single(e => e.StyleId == model.StyleId);

                entity.StyleName = model.StyleName;
                entity.Description = model.Description;
                entity.IBU = model.IBU;
                entity.FoodPairing = model.FoodPairing;
                entity.CountryOfOrigin = model.CountryOfOrigin;
                entity.RecommendedGlassware = model.RecommendedGlassware;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStyle(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Styles.Single(e => e.StyleId == id);

                ctx.Styles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
