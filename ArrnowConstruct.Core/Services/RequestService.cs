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
        private readonly IClientService clientService;

        public RequestService(
            IRepository _repo,
            ICategoryService _categoryService,
            IClientService _clientService)
        {
            repo = _repo;
            categoryService = _categoryService;
            clientService = _clientService;
        }

        public async Task<IEnumerable<RequestViewModel>> AllRequestsByClientId(int id)
        {
            //   var user = await clientService.GetUserByClientId(id);

            return await repo.All<Request>()
                .Where(r => r.ClientId == id)
                .Select(c => new RequestViewModel
                {
                    ClientAddress = c.Client.User.Email,
                    Id = c.Id,
                    RoomsCount = c.RoomsCount,
                    Area = c.Area,
                    RequiredDate = c.RequiredDate.ToString("yyyy-MM-dd"),
                    Status = c.Status,
                    Budget = c.Budget,
                    ConstructorAddress = c.Constructor.User.Email,
                    RoomsCategories = c.RoomsTypes.Select(r => r.Name).ToList()
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
                RoomsTypes = categories.ToList()
            };

            await repo.AddAsync(request);
            await repo.SaveChangesAsync();
        }

    }
}
