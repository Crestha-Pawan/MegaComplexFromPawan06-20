using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.Src.Dto
{
    public class ClientBlockRoomSetupDto : BaseDto
    {
        public long? ClientId { get; set; }
        public long? BlockId { get; set; }
        public string RoomId { get; set; }
        public string[] RoomList { get; set; }
        public List<ClientBlockRoomSetupDto> clientBlockRoomSetupDtos { get; set; }
        public IList<Client> Clients { get; set; } = new List<Client>();
        public SelectList Clientlist => new SelectList(Clients, nameof(Client.Id), nameof(Client.OwnerName));
        public IList<Room> Rooms { get; set; } = new List<Room>();
        public SelectList Roomlist => new SelectList(Rooms, nameof(Room.Id), nameof(Room.Name));
        public IList<Block> Blocks { get; set; } = new List<Block>();
        public SelectList Blocklist => new SelectList(Blocks, nameof(Block.Id), nameof(Block.Name));
    }
}
