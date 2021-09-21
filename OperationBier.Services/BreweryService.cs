using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationBier.Data;
using OperationBier.Models.BreweryModels;
using OperationBier.Models.RetailModels;


namespace OperationBier.Services
{
    public class BreweryService
    {
        private readonly Guid _userId;

        public BreweryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBrewery(BreweryCreate model)
        {
            var entity =
                new Brewery()
                {
                    AuthorId = _userId,
                    BreweryName = model.BreweryName,
                    BreweryDescription = model.BreweryDescription,
                    IsStillInBusiness = model.IsStillInBusiness,
                    Address = model.Address,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    CountryOfOrigin = model.CountryOfOrigin
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Breweries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BreweryListItem> GetBreweries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Breweries
                    .Select(e => new BreweryListItem
                    {
                        BreweryId = e.BreweryId,
                        BreweryName = e.BreweryName
                    });
                return query.ToArray();
            }
        }

        public BreweryDetails GetBreweryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Breweries
                    .Single(e => e.BreweryId == id);
                return
                    new BreweryDetails
                    {
                        BreweryName = entity.BreweryName,
                        BreweryDescription = entity.BreweryDescription,
                        IsStillInBusiness = entity.IsStillInBusiness,
                        Address = entity.Address,
                        State = entity.State,
                        ZipCode = entity.ZipCode,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email,
                        CountryOfOrigin = entity.CountryOfOrigin
                    };
            }
        }

        public bool UpdateBrewery(BreweryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Breweries
                    .Single(e => e.BreweryId == model.BreweryId);

                entity.BreweryName = model.BreweryName;
                entity.BreweryDescription = model.BreweryDescription;
                entity.IsStillInBusiness = model.IsStillInBusiness;
                entity.Address = model.Address;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.CountryOfOrigin = model.CountryOfOrigin;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBrewery(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Breweries
                    .Single(e => e.BreweryId == id);

                ctx.Breweries.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}