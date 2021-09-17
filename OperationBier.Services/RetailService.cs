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
        private readonly Guid AuthorId;
        public RetailService(Guid authorId)
        {
            AuthorId = authorId;
        }
        public bool RetailCreate(CreateRetail model)
        {
            var entity =
                new Retail()
                {
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
                    .Where(e => e.AuthorId == AuthorId)
                    .Select(
                        e =>
                        new RetailListItem
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
                    .Single(e => e.RetailId == model.RetailId && e.AuthorId == AuthorId);

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
        public bool DeleteRetail(int retailId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Retailers
                    .Single(e => e.RetailId == retailId && e.AuthorId == AuthorId);

                ctx.Retailers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
