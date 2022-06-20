using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.InfraStructure.Assembler
{
    public interface IBlockAssembler
    {
        void copyTo(Block block, BlockDto dto);
        void copyFrom(BlockDto dto, Block block);
        void modifyTo(Block block, BlockDto dto);
    }

    public class BlockAssembler : IBlockAssembler
    {
        public void copyFrom(BlockDto dto, Block block)
        {
            dto.Id = block.Id;
            dto.CreatedBy = block.CreatedBy;
            dto.CreatedDate = block.CreatedDate;
            dto.Name = block.Name;
        }

        public void copyTo(Block block, BlockDto dto)
        {
            block.CreatedBy = dto.CreatedBy;
            block.CreatedDate = DateTime.Now;
            block.Name = dto.Name;
        }

        public void modifyTo(Block block, BlockDto dto)
        {
            block.Id = dto.Id;
            block.CreatedBy = dto.CreatedBy;
            block.CreatedDate = dto.CreatedDate;
            block.ModifiedBy = dto.ModifiedBy;
            block.ModifiedDate = DateTime.Now;
            block.Name = dto.Name;

        }
    }
}
