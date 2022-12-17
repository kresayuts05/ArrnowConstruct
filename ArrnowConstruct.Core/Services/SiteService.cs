using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Core.Models.Site;
using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using ArrnowConstruct.Infrastructure.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class SiteService : ISiteService
    {
        private readonly IRepository repo;
        private readonly ICategoryService categoryService;

        public SiteService(
            IRepository _repo,
            ICategoryService _categoryService)
        {
            repo = _repo;
            categoryService = _categoryService;
        }

        public async Task<IEnumerable<SiteViewModel>> AllSitesByConstructorId(int id)
        {
            return await repo.All<Site>()
               .Where(s => s.ConstructorId == id && s.Status != SiteStatusEnum.Disactivated.ToString())
                .OrderByDescending(s => s.Id)
               .Select(s => new SiteViewModel
               {
                   Id = s.Id,
                   RoomsCount = s.RoomsCount,
                   Area = s.Area,
                   FromDate = s.FromDate.ToString("yyyy-MM-dd"),
                   ToDate = s.ToDate.ToString("yyyy-MM-dd"),
                   Status = s.Status,
                   Price = s.Price,
                   RoomsTypes = s.RoomsTypes.Select(c => c.Name).ToList(),
                   Client = new ClientModel()
                   {
                       ClientId = s.ClientId,
                       User = new UserModel()
                       {
                           Email = s.Client.User.Email,
                           Address = $"{s.Client.User.Address}, {s.Client.User.Address}, {s.Client.User.Address}"
                       }
                   },
                   Constructor = new ConstructorModel()
                   {
                       ConstructorId = s.ConstructorId,
                       User = new UserModel()
                       {
                           Email = s.Constructor.User.Email
                       }
                   }
               })
               .ToListAsync();
        }

        public async Task Create(RequestViewModel request, RequestConfirmViewModel model)
        {
            var categories = await categoryService.CategoriesById(request.CategoryId);

            var site = new Site()
            {
                RoomsCount = request.RoomsCount,
                Area = request.Area,
                FromDate = DateTime.ParseExact(model.FromDate, "yyyy-MM-dd", CultureInfo.CurrentCulture),
                ToDate = DateTime.ParseExact(model.ToDate, "yyyy-MM-dd", CultureInfo.CurrentCulture),
                Price = model.Price,
                Status = SiteStatusEnum.InProcess.ToString(),
                ClientId = request.Client.ClientId,
                ConstructorId = request.Constructor.ConstructorId,
                RoomsTypes = (ICollection<Category>)categories
                // IsActive = true
            };

            await repo.AddAsync(site);
            await repo.SaveChangesAsync();
        }

        public async Task<string> GetStatus(int siteId)
        {
            var site = await repo.GetByIdAsync<Site>(siteId);

            if (site == null || site.Status == SiteStatusEnum.Disactivated.ToString())
            {
                throw new NullReferenceException(GlobalExceptions.SiteDoesNotExistExceptionMessage);
            }

            return site.Status;
        }

        public async Task<SiteViewModel> SiteById(int id)
        {
            var site = await repo.All<Site>()
             .Where(s => s.Id == id && s.Status != SiteStatusEnum.Disactivated.ToString())
             .Select(s => new SiteViewModel()
             {
                 Id = s.Id,
                 RoomsCount = s.RoomsCount,
                 Area = s.Area,
                 Price = s.Price,
                 FromDate = s.FromDate.ToString("yyyy-M-d"),
                 ToDate = s.ToDate.ToString("yyyy-M-d"),
                 Status = s.Status,
                 Client = new ClientModel() { ClientId = s.ClientId,
                     User = new UserModel()
                     {
                         Email = s.Client.User.Email,
                         Address = $"Country: {s.Client.User.Address},{Environment.NewLine} City: {s.Client.User.Address},{Environment.NewLine} Street: {s.Client.User.Address}",
                         Phone = s.Client.User.PhoneNumber,
                         FirstName = s.Client.User.FirstName,
                         LastName = s.Client.User.LastName
                     }
                 },
                 Constructor = new ConstructorModel() { ConstructorId = s.ConstructorId,
                     User = new UserModel()
                     {
                        Id = s.Constructor.User.Id,
                        IsActive = s.Constructor.User.IsActive
                     }
                 },
                 RoomsTypes = s.RoomsTypes.Select(c => c.Name).ToList()
             })
             .FirstOrDefaultAsync();

            if (site == null )
            {
                throw new NullReferenceException(GlobalExceptions.SiteDoesNotExistExceptionMessage);
            }

            return site;
        }
        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Site>()
                .AnyAsync(s => s.Id == id && s.Status != SiteStatusEnum.Disactivated.ToString());
        }

        public async Task Finish(int siteId, SiteViewModel model)
        {
            var site = await repo.GetByIdAsync<Site>(siteId);

            if (site == null)
            {
                throw new NullReferenceException(GlobalExceptions.SiteDoesNotExistExceptionMessage);
            }

            if (site.Status != SiteStatusEnum.InProcess.ToString())
            {
                throw new ArgumentException(GlobalExceptions.SiteCannotBeFinished);
            }

            site.ToDate = DateTime.ParseExact(model.ToDate, "yyyy-MM-dd", CultureInfo.CurrentCulture);
            site.Status = SiteStatusEnum.Finished.ToString();

            await repo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var site = await repo.GetByIdAsync<Site>(id);

            if (site == null)
            {
                throw new NullReferenceException(GlobalExceptions.SiteDoesNotExistExceptionMessage);
            }

            if (site.Status == SiteStatusEnum.Disactivated.ToString())
            {
                throw new ArgumentException(GlobalExceptions.SiteIsAlreadyDisactivated);
            }

            site.Status = SiteStatusEnum.Disactivated.ToString();

            await repo.SaveChangesAsync();
        }
    }
}
