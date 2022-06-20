using FiboInfraStructure.Entity.Payroll;
using Payroll.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.InfraStructure.Assembler
{

    public interface IPostAssembler
    {
        void copyTo(Post post, PostDto dto);
        void copyFrom(PostDto dto, Post post);
        void modifyTo(Post post, PostDto dto);
    }
    public class PostAssembler : IPostAssembler
    {


        public void copyFrom(PostDto dto, Post post)
        {
            dto.Id = post.Id;
            dto.CreatedBy = post.CreatedBy;
            dto.CreatedDate = post.CreatedDate;
            dto.Name = post.Name;
        }
        public void modifyTo(Post post, PostDto dto)
        {
            post.Id = dto.Id;
            post.CreatedBy = dto.CreatedBy;
            post.CreatedDate = DateTime.Now;
            post.Name = dto.Name;
            post.ModifiedBy = dto.ModifiedBy;
            post.ModifiedDate = DateTime.Now;
        }

        public void copyTo(Post post, PostDto dto)
        {
            post.CreatedBy = dto.CreatedBy;
            post.CreatedDate = DateTime.Now;
            post.Name = dto.Name;
        }

    }
}

