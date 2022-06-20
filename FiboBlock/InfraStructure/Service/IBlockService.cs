using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboBlock.InfraStructure.Service
{
    public interface IBlockService
    {
        Task<BlockDto> Insertasync(BlockDto dto);
        Task<Block> Delete(long Id);
        Task<BlockDto> UpdateAsync(BlockDto dto);
    }
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IBlockAssembler _blockAssembler;
        private readonly IRoomService _roomService;
        private readonly IRoomAssembler _roomAssembler;
        private readonly IRoomRepository _roomRepo;
        public BlockService(IBlockRepository blockRepository,
            IBlockAssembler blockAssembler, IRoomService roomService
            , IRoomAssembler roomAssembler
            , IRoomRepository roomRepo
            )
        {
            _blockAssembler = blockAssembler;
            _blockRepository = blockRepository;
            _roomService =  roomService;
            _roomAssembler = roomAssembler;
            _roomRepo = roomRepo;
        }
        public async Task<Block> Delete(long Id)
        {
            var block = await _blockRepository.GetByIdAsync(Id) ?? throw  new Exception();
            return await _blockRepository.DeleteAsync(block).ConfigureAwait(true);
        }

        public async Task<BlockDto> Insertasync(BlockDto dto)
        {
            Block block = new Block();
            _blockAssembler.copyTo(block, dto);
            await _blockRepository.AddSync(block);
            if (dto.RoomDtos != null)
            {
                if (dto.hasRoom())
                {
                    foreach (var _room in dto.RoomDtos)
                    {
                        var temp = await _roomRepo.GetByIdAsync(_room.Id);
                        RoomDto _dto = new RoomDto();
                        _roomAssembler.copyFrom(_dto, temp);
                        _dto.Id= _room.Id;
                        _dto.BlockId = block.Id;
                        _dto.MonthlyAmount = _room.MonthlyAmount;
                        _dto.Name = temp.Name;
                        _roomAssembler.modifyTo(temp, _dto);
                        await _roomRepo.UpdateAsync(temp);

                    }
                }
            }
            //else
            //{
            //    Block block = new Block();
            //    _blockAssembler.copyTo(block, dto);
            //    await _blockRepository.AddSync(block);
            //    dto.Id = block.Id;
            //}
            return dto;
        }

        public async Task<BlockDto> UpdateAsync(BlockDto dto)
        {
            Block block = new Block();
            _blockAssembler.modifyTo(block, dto);
            await _blockRepository.UpdateAsync(block);
            return (dto);
        }
    }
}
