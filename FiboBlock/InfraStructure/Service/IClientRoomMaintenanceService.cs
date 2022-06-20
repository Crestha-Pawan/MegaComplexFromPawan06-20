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
    public interface IClientRoomMaintenanceService
    {
        Task<ClientRoomMaintenanceDto> Insertasync(ClientRoomMaintenanceDto dto);
        Task<ClientRoomMaintenance> Delete(long Id);
        Task<ClientRoomMaintenanceDto> UpdateAsync(ClientRoomMaintenanceDto dto);
    }
    public class ClientRoomMaintenanceService : IClientRoomMaintenanceService
    {
        private readonly IClientRoomMaintenanceRepository _clientRepository;
        private readonly IClientRoomMaintenanceAssembler _clientAssembler;

        public ClientRoomMaintenanceService(IClientRoomMaintenanceRepository clientRepository
            , IClientRoomMaintenanceAssembler clientAssembler)
        {
            _clientAssembler = clientAssembler;
            _clientRepository = clientRepository;
        }
        public async Task<ClientRoomMaintenance> Delete(long Id)
        {
            var client = await _clientRepository.GetByIdAsync(Id)??throw new Exception();
            return await _clientRepository.DeleteAsync(client).ConfigureAwait(true);
        }

        public async Task<ClientRoomMaintenanceDto> UpdateAsync(ClientRoomMaintenanceDto dto)
        {
            ClientRoomMaintenance client = new ClientRoomMaintenance();
            _clientAssembler.modifyTo(client, dto);
            await _clientRepository.UpdateAsync(client);
            return dto;
        }

        public async Task<ClientRoomMaintenanceDto> Insertasync(ClientRoomMaintenanceDto dto)
        {
            foreach (var item in dto.clientRoomMaintenanceDtos)
            {
                ClientRoomMaintenance client = new ClientRoomMaintenance();
                _clientAssembler.copyTo(client, item);
                client.ClientId = dto.ClientId;
                client.YearId = dto.YearId;
                client.MonthId = dto.MonthId;
                await _clientRepository.AddSync(client);
                dto.Id = client.Id;
            }
            return dto;
        }
    }
}
