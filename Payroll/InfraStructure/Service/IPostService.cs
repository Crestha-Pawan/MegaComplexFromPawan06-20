using FiboInfraStructure.Entity.Payroll;
using Payroll.InfraStructure.Assembler;
using Payroll.InfraStructure.Repository;
using Payroll.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.InfraStructure.Service
{
    public interface IPostService
    {
        Task<PostDto> InsertAsync(PostDto dto);
        Task<Post> Delete(long Id);
        Task<PostDto> UpdateAsync(PostDto dto);
    }
    public class PostService : IPostService
    {
        private readonly IPostRepository _repo;
        private readonly IPostAssembler _assembler;
        public PostService(IPostRepository repo, IPostAssembler assembler)
        {
            _repo = repo;
            _assembler = assembler;
        }
        public async Task<Post> Delete(long Id)
        {
            var fy = await _repo.GetByIdAsync(Id) ?? throw new Exception();
            return await _repo.DeleteAsync(fy).ConfigureAwait(true);
        }

        public async Task<PostDto> InsertAsync(PostDto dto)
        {
            Post post = new Post();
            _assembler.copyTo(post, dto);
            await _repo.AddSync(post);
            dto.Id = post.Id;
            return dto;
        }


        public async Task<PostDto> UpdateAsync(PostDto dto)
        {
            Post post = new Post();
            _assembler.modifyTo(post, dto);
            await _repo.UpdateAsync(post);
            return dto;
        }
    }
}
