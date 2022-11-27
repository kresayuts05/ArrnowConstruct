using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository repo;
        private readonly ICategoryService categoryService;

        public RequestService(
            IRepository _repo,
            ICategoryService _categoryService,
            IClientService _clientService)
        {
            repo = _repo;
            categoryService = _categoryService;
        }

        public async Task<IEnumerable<RequestViewModel>> AllRequestsByClientId(int id)
        {
            //   var user = await clientService.GetUserByClientId(id);

            return await repo.All<Request>()
                .Where(r => r.IsActive == true)
                .Where(r => r.ClientId == id)
                .Select(r => new RequestViewModel
                {
                    ClientAddress = r.Client.User.Address,
                    Id = r.Id,
                    RoomsCount = r.RoomsCount,
                    Area = r.Area,
                    RequiredDate = r.RequiredDate.ToString("yyyy-MM-dd"),
                    Status = r.Status,
                    Budget = r.Budget,
                    ConstructorEmail = r.Constructor.User.Email,
                    RoomsTypes = new List<CategoryModel>
                    (r.RoomsTypes.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name }).ToList()),
                    IsActive = r.IsActive
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RequestViewModel>> AllRequestsForConstructorById(int id)
        {
            //   var user = await clientService.GetUserByClientId(id);

            return await repo.All<Request>()
                .Where(r => r.IsActive == true && r.Status == "Waiting")
                .Where(r => r.ConstructorId == id)
                .Select(r => new RequestViewModel
                {
                    ClientAddress = r.Client.User.Address,
                    Id = r.Id,
                    RoomsCount = r.RoomsCount,
                    Area = r.Area,
                    RequiredDate = r.RequiredDate.ToString("yyyy-MM-dd"),
                    Status = r.Status,
                    Budget = r.Budget,
                    ClientEmail = r.Client.User.Email,
                    RoomsTypes = new List<CategoryModel>
                    (r.RoomsTypes.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name }).ToList()),
                    IsActive = r.IsActive
                })
                .ToListAsync();
        }

        public async Task<int> ConstructorWithEmailExists(string email)
        {
            var user = await repo.AllReadonly<User>()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                Constructor constructor = await repo.All<Constructor>()
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

                if (constructor != null)
                {
                    return constructor.Id;
                }
            }

            return -1;
        }

        public async Task Create(AddRequestViewModel model, int clientId)
        {
            int constructorId = await this.ConstructorWithEmailExists(model.ConstructorEmail);
            var categories = await categoryService.CategoriesById(model.CategoryId);

            var request = new Request()
            {
                RoomsCount = model.RoomsCount,
                Area = model.Area,
                RequiredDate = DateTime.ParseExact(model.RequiredDate, "yyyy-MM-dd", CultureInfo.CurrentCulture),
                Budget = model.Budget,
                Status = "Waiting",
                ClientId = clientId,
                ConstructorId = constructorId,
                RoomsTypes = categories.ToList(),
                IsActive = true
            };

            await repo.AddAsync(request);
            await repo.SaveChangesAsync();
        }

        public async Task Edit(int requestId, AddRequestViewModel model)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);

            var sth = repo.All<Category>()
                .Include(c => c.Requests)
                .Where(r => r.Requests.All(c => c.Id == requestId));

            foreach (var c in sth)
            {
                c.Requests.Remove(request);
            }
            await repo.SaveChangesAsync();

            int constructorId = await this.ConstructorWithEmailExists(model.ConstructorEmail);
            var categories = await categoryService.CategoriesById(model.CategoryId);

            request.RoomsCount = model.RoomsCount;
            request.Area = model.Area;
            request.RequiredDate = DateTime.ParseExact(model.RequiredDate, "yyyy-MM-dd", CultureInfo.CurrentCulture);
            request.Budget = model.Budget;
            request.ConstructorId = constructorId;
            request.RoomsTypes = categories.ToList();
            request.IsActive = model.IsActive;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Request>()
                .AnyAsync(r => r.Id == id && r.Status == "Waiting" && r.IsActive == true);
        }

        public async Task<AddRequestViewModel> RequestById(int id)
        {
            var request = await repo.All<Request>()
             .Where(r => r.IsActive == true)
             .Where(r => r.Id == id)
             .Select(r => new AddRequestViewModel()
             {
                 Id = r.Id,
                 ClientId = r.ClientId,
                 RoomsCount = r.RoomsCount,
                 Area = r.Area,
                 RequiredDate = r.RequiredDate.ToString("yyyy-MM-dd"),
                 Budget = r.Budget,
                 ConstructorEmail = r.Constructor.User.Email,
                 RoomsTypes = new List<CategoryModel>
                 (r.RoomsTypes.Select(r => new CategoryModel() { Id = r.Id, Name = r.Name }).ToList()),
                 IsActive = r.IsActive
             })
             .FirstAsync();

            return request;
        }


        public async Task Delete(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            request.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<string> GetStatus(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            
            return request.Status;
        }

        public async Task<RequestViewModel> GetDetailsRequest(int id)
        {
            var request = await repo.All<Request>()
              .Where(r => r.IsActive == true && r.Status == "Waiting")
              .Where(r => r.Id == id)
              .Select(r => new RequestViewModel()
              {
                  Id = r.Id,
                  ClientEmail = r.Client.User.Email,
                  ClientAddress = r.Client.User.Address,
                  RoomsCount = r.RoomsCount,
                  Area = r.Area,
                  RequiredDate = r.RequiredDate.ToString("yyyy-MM-dd"),
                  Budget = r.Budget,
                  ConstructorEmail = r.Constructor.User.Email,
                  RoomsTypes =r.RoomsTypes.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name }).ToList(),
                  IsActive = r.IsActive
              })
              .FirstAsync();

            return request;
        }

        public async Task Reject(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            request.Status = "Rejected";

            await repo.SaveChangesAsync();
        }

        public async Task Confirm(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            request.Status = "Confirmed";

            await repo.SaveChangesAsync();
        }
    }
}
