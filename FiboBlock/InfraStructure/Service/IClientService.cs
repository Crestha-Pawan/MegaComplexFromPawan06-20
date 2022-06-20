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
    public interface IClientService
    {
        Task<ClientDto> Insertasync(ClientDto dto);
        Task<Client> Delete(long Id);
        Task<ClientDto> UpdateAsync(ClientDto dto);
    }
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientAssembler _clientAssembler;
        
        public ClientService(IClientRepository clientRepository
            , IClientAssembler clientAssembler)
        {
            _clientAssembler = clientAssembler;
            _clientRepository = clientRepository;
        }
        public async Task<Client> Delete(long Id)
        {
           var client = await _clientRepository.GetByIdAsync(Id)??throw new Exception();
            return await _clientRepository.DeleteAsync(client).ConfigureAwait(true);
        }

        public async Task<ClientDto> UpdateAsync(ClientDto dto)
        {
            Client client = new Client();
            _clientAssembler.modifyTo(client, dto);
            await _clientRepository.UpdateAsync(client);
            return dto;
        }

      public async  Task<ClientDto>Insertasync(ClientDto dto)
        {
            Client client = new Client();
            _clientAssembler.copyTo(client, dto);
            await _clientRepository.AddSync(client);
            dto.Id = client.Id;
            return dto;
        }
    }
}
