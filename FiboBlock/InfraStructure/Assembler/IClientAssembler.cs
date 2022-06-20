using FiboBlock.Src.Dto;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboBlock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboBlock.InfraStructure.Assembler
{
    public interface IClientAssembler
    {
        void copyTo(Client item, ClientDto dto);
        void copyFrom(ClientDto dto, Client client);
        void modifyTo(Client lient, ClientDto dto);
    }

    public class ClientAssembler : IClientAssembler
    {
        public void copyFrom(ClientDto dto, Client client)
        {
            dto.Id = client.Id;
            dto.CreatedBy = client.CreatedBy;
            dto.CreatedDate = client.CreatedDate;
            dto.BusinessName = client.BusinessName;
            dto.Address = client.Address;
            dto.ContactNumber = client.ContactNumber;
            dto.CitizenShipNo = client.CitizenShipNo;
            dto.Collateral = client.Collateral;
            dto.Date = client.Date;
            dto.PanNo = client.PanNo;
            dto.OwnerName = client.OwnerName;
            dto.RentDue = client.RentDue;
            dto.ElectricityDue = client.ElectricityDue;

        }

        public void copyTo(Client client, ClientDto dto)
        {
            client.CreatedBy = dto.CreatedBy;
            client.CreatedDate = DateTime.Now;
            client.BusinessName = dto.BusinessName;
            client.Address = dto.Address;
            client.ContactNumber = dto.ContactNumber;
            client.CitizenShipNo = dto.CitizenShipNo;
            client.Collateral = dto.Collateral;
            client.Date = dto.Date;
            client.PanNo = dto.PanNo;
            client.OwnerName = dto.OwnerName;
            client.RentDue = dto.RentDue;
            client.ElectricityDue = dto.ElectricityDue;
        }

        public void modifyTo(Client client, ClientDto dto)
        {
            client.Id = dto.Id;
            client.CreatedBy = dto.CreatedBy;
            client.CreatedDate = dto.CreatedDate;
            client.ModifiedBy = dto.ModifiedBy;
            client.ModifiedDate = DateTime.Now;
            client.BusinessName = dto.BusinessName;
            client.Address = dto.Address;
            client.ContactNumber = dto.ContactNumber;
            client.CitizenShipNo = dto.CitizenShipNo;
            client.Collateral = dto.Collateral;
            client.Date = dto.Date;
            client.PanNo = dto.PanNo;
            client.OwnerName = dto.OwnerName;
            client.RentDue = dto.RentDue;
            client.ElectricityDue = dto.ElectricityDue;
        }
    }
}
