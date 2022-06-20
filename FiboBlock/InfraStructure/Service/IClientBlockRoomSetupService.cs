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
    public interface IClientBlockRoomSetupService
    {
        Task<ClientBlockRoomSetupDto> Insertasync(ClientBlockRoomSetupDto dto);
        Task<ClientBlockRoomSetup> Delete(long Id);
        Task<ClientBlockRoomSetupDto> UpdateAsync(ClientBlockRoomSetupDto dto);
    }
    public class ClientBlockRoomSetupService : IClientBlockRoomSetupService
    {
        private readonly IClientBlockRoomSetupRepository _repo;
        private readonly IClientBlockRoomSetupAssembler _assembler;       
        public ClientBlockRoomSetupService(IClientBlockRoomSetupRepository repo,
            IClientBlockRoomSetupAssembler assembler
            )
        {
            _assembler = assembler;
            _repo = repo;
        }

        public async Task<ClientBlockRoomSetup> Delete(long Id)
        {
            var obj = await _repo.GetByIdAsync(Id) ?? throw  new Exception();
            return await _repo.DeleteAsync(obj).ConfigureAwait(true);
        }

        public async Task<ClientBlockRoomSetupDto> Insertasync(ClientBlockRoomSetupDto dto)
        {
            foreach(var item in dto.clientBlockRoomSetupDtos)
            {
                if (item.RoomList != null)
                {
                    item.RoomId = string.Join(",", item.RoomList);
                }
                ClientBlockRoomSetup obj = new ClientBlockRoomSetup();
                _assembler.copyTo(obj, item);
                obj.ClientId = dto.ClientId;
                await _repo.AddSync(obj);
            }
            return (dto);
        }

        public async Task<ClientBlockRoomSetupDto> UpdateAsync(ClientBlockRoomSetupDto dto)
        {
            ClientBlockRoomSetup obj = new ClientBlockRoomSetup();
            _assembler.modifyTo(obj, dto);
            await _repo.UpdateAsync(obj);
            return (dto);
        }
    }
}
