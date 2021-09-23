using OperationBier.Data;
using OperationBier.Models.BeerModels;
using OperationBier.Models.RetailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Services
{
    public class BeerService
    {
        private readonly Guid _userId;

        public BeerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBeer(BeerCreate model)
        {
            var entity =
                new Beer()
                {
                    AuthorId = _userId,
                    BeerName = model.BeerName,
                    ABV = model.ABV,
                    IsRecommended = model.IsRecommended,
                    BreweryId = model.BreweryId,
                    //StyleId = model.StyleId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Beers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BeerListItem> GetBeers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Beers
                    .Select(e => new BeerListItem
                    {
                        BeerId = e.BeerId,
                        BeerName = e.BeerName
                    });
                return query.ToArray();
            }
        }

        public BeerDetail GetBeerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Beers
                    .Single(e => e.BeerId == id);
                return
                    new BeerDetail
                    {
                        BeerId = entity.BeerId,
                        BeerName = entity.BeerName,
                        ABV = entity.ABV,
                        IsRecommended = entity.IsRecommended,
                        BreweryName = entity.Brewery.BreweryName,
                        //StyleName = entity.Style.StyleName,
                        Retailers = entity.Retailers.Select(e => new RetailDetail
                        {
                            RetailId = e.RetailId,
                            RetailName = e.RetailName,
                            Address = e.Address,
                            State = e.State,
                            ZipCode = e.ZipCode,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                            IsOnPremise = e.IsOnPremise
                        }).ToList()
                    };
            }
        }

        public BeerDetail GetBeerByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Beers
                    .Single(e => e.BeerName == name);
                return
                    new BeerDetail
                    {
                        BeerId = entity.BeerId,
                        BeerName = entity.BeerName,
                        BreweryName = entity.Brewery.BreweryName,
                        //StyleName = entity.Style.StyleName,
                        ABV = entity.ABV,
                        IsRecommended = entity.IsRecommended,
                        Retailers = entity.Retailers.Select(e => new RetailDetail
                        {
                            RetailId = e.RetailId,
                            RetailName = e.RetailName,
                            Address = e.Address,
                            State = e.State,
                            ZipCode = e.ZipCode,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                            IsOnPremise= e.IsOnPremise
                        }).ToList()
                    };
            }
        }

        public IEnumerable<BeerRecommended> GetRecommendedBeers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Beers
                    .Where(e => e.IsRecommended == true)
                    .Select(e => new BeerRecommended
                    {
                        BeerId = e.BeerId,
                        BeerName = e.BeerName,
                        IsRecommended = e.IsRecommended
                    });
                return query.ToArray();
            }
        }

        public IEnumerable<BeerABVListItem> GetBeersByABV(double abv)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Beers
                    .Where(e => e.ABV == abv)
                    .Select(e => new BeerABVListItem
                    {
                        BeerId = e.BeerId,
                        BeerName = e.BeerName,
                        ABV = e.ABV
                    });
                return query.ToArray();
            }
        }

        public IEnumerable<BeerABVListItem> GetBeersGreaterThan(double abv)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Beers
                    .Where(e => e.ABV > abv)
                    .Select(e => new BeerABVListItem
                    {
                        BeerId = e.BeerId,
                        BeerName = e.BeerName,
                        ABV = e.ABV
                    });
                return query.ToArray();
            }
        }

        public bool UpdateBeer(BeerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Beers
                    .Single(e => e.BeerId == model.BeerId);

                entity.BeerName = model.BeerName;
                entity.ABV = model.ABV;
                entity.IsRecommended = model.IsRecommended;
                entity.BreweryId = model.BreweryId;
                //entity.StyleId = model.StyleId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateBeerRetailers (BeerRetailers model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var beerEntity =
                    ctx
                    .Beers
                    .Single(e => e.BeerId == model.BeerId);

                var retailEntity =
                    ctx
                    .Retailers
                    .Single(e => e.RetailId == model.RetailId);

                beerEntity.Retailers.Add(retailEntity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBeer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Beers
                    .Single(e => e.BeerId == id);

                ctx.Beers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
