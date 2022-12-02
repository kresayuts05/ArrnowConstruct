using ArrnowConstruct.Core.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface IPostService
    {
        Task<bool> Exists(int id);

        Task Create(PostFormViewModel model);

        Task<IEnumerable<PostViewModel>> AllPostsByConstructor(int id);

        Task<PostViewModel> PostDetailsById(int id);
    }
}
