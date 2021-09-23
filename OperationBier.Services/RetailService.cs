using OperationBier.Data;
using OperationBier.Models.RetailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Services
{
    public class RetailService
    {
        private readonly Guid _userId;
        public RetailService(Guid userId)
        {
            _userId = userId;
        }
        public bool RetailCreate(CreateRetail model)
        {
            var entity =
                new Retail()
                {
                    AuthorId = _userId,
                    RetailId = model.RetailId,
                    RetailName = model.RetailName,
                    Address = model.Address,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    IsOnPremise = model.IsOnPremise,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Retailers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RetailListItem> GetRetail()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Retailers
                    .Select( e => new RetailListItem
                        {
                            RetailId = e.RetailId,
                            RetailName = e.RetailName,
                        }
                );

                return query.ToArray();
            }
        }
        public RetailDetail GetRetailById(int id)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Retailers
                    .Single(e => e.RetailId == id);
                return
                    new RetailDetail
                    {
                        RetailId = entity.RetailId,
                        RetailName = entity.RetailName,
                    };
            }
        }
        public bool UpdateRetail(EditRetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Retailers
                    .Single(e => e.RetailId == model.RetailId);

                entity.RetailName = model.RetailName;
                entity.Address = model.Address;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.IsOnPremise = model.IsOnPremise;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RetailIsOnPremise> GetRetailIsOnPremise()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Retailers
                    .Where(e => e.IsOnPremise == true)
                    .Select(e => new RetailIsOnPremise
                    {
                        RetailId = e.RetailId,
                        RetailName = e.RetailName,
                        IsOnPremise = e.IsOnPremise
                    });
                return query.ToArray();
            }
        }
        public bool DeleteRetail(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Retailers
                    .Single(e => e.RetailId == id);

                ctx.Retailers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
