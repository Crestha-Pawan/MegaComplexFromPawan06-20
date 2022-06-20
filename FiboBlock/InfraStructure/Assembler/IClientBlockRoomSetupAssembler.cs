using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.InfraStructure.Assembler
{
    
    public interface IClientBlockRoomSetupAssembler
    {
        void copyTo(ClientBlockRoomSetup client, ClientBlockRoomSetupDto dto);
        void copyFrom(ClientBlockRoomSetupDto dto, ClientBlockRoomSetup client);
        void modifyTo(ClientBlockRoomSetup client, ClientBlockRoomSetupDto dto);
    }

    public class ClientBlockRoomSetupAssembler : IClientBlockRoomSetupAssembler
    {
        public void copyFrom(ClientBlockRoomSetupDto dto, ClientBlockRoomSetup client)
        {
            dto.Id = client.Id;
            dto.CreatedBy = client.CreatedBy;
            dto.CreatedDate = client.CreatedDate;
            dto.BlockId = client.BlockId;
            dto.RoomId = client.RoomId;
            dto.ClientId = client.ClientId;
        }

        public void copyTo(ClientBlockRoomSetup client, ClientBlockRoomSetupDto dto)
        {
            client.CreatedBy = dto.CreatedBy;
            client.CreatedDate = DateTime.Now;
            client.BlockId = dto.BlockId;
            client.RoomId = dto.RoomId;
            client.ClientId = dto.ClientId;
        }

        public void modifyTo(ClientBlockRoomSetup client, ClientBlockRoomSetupDto dto)
        {
            client.Id = dto.Id;
            client.CreatedBy = dto.CreatedBy;
            client.CreatedDate = dto.CreatedDate;
            client.ModifiedBy = dto.ModifiedBy;
            client.ModifiedDate = DateTime.Now;
            client.BlockId = dto.BlockId;
            client.RoomId = dto.RoomId;
            client.ClientId = dto.ClientId;
        }
    }
}
