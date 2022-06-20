using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboBlock.InfraStructure.Service
{
    public interface IRoomService
    {
        Task<RoomDto> Insertasync(RoomDto dto);
        Task<Room> Delete(long Id);
        Task<RoomDto> UpdateAsync(RoomDto dto);
        Task<List<RoomDto>> InsertAndDelete(List<RoomDto> dtos);
    }
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomAssembler _roomAssembler;

        public RoomService(IRoomRepository roomRepository
            , IRoomAssembler roomAssembler)
        {
            _roomAssembler = roomAssembler;
            _roomRepository = roomRepository;
        }
        public async Task<Room> Delete(long Id)
        {
            var room = await _roomRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _roomRepository.DeleteAsync(room).ConfigureAwait(true);
        }

        public async Task<RoomDto> UpdateAsync(RoomDto dto)
        {
            Room room = new Room();
            _roomAssembler.modifyTo(room, dto);
            await _roomRepository.UpdateAsync(room);
            return dto;
        }

        public async Task<RoomDto> Insertasync(RoomDto dto)
        {
            Room room = new Room();
            _roomAssembler.copyTo(room, dto);
            await _roomRepository.AddSync(room);
            dto.Id = room.Id;
            return dto;
        }

        public  async Task<List<RoomDto>> InsertAndDelete(List<RoomDto> dtos)
        {
            var room = await _roomRepository.GetAllByRoomId(dtos.First().BlockId.Value);
            if (room.Count > 0)
            {
                foreach (var detail in room)
                {
                    await Delete(detail.Id);
                }
            }

            foreach (var dto in dtos)
            {
                await Insertasync(dto);
            }
            return dtos;
        }
    }
}
