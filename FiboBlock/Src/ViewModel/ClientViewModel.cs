using FiboInfraStructure.Entity.FiboBilling;
using FiboInfraStructure.Entity.FiboBlock;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboBlock.Src.ViewModel
{
   public class ClientViewModel
    {
        public List<Billing> Billings { get; set; }
        public List<Client> Clients { get; set; }
        public List<ClientViewModel> ClientVMList { get; set; }
        public string OwnerName { get; set; }
        public string BusinessName { get; set; }
        public long? ClientId { get; set; }
        [NotMapped]
        public DateTime? FromDate { get; set; }
        [NotMapped]
        public DateTime? ToDate { get; set; }
        [NotMapped]
        public string FromMiti { get; set; }
        [NotMapped]
        public string ToMiti { get; set; }
        public List<Block> Blocks { get; set; }
        public List<Room> Rooms { get; set; }
        public IList<Client> ClientList { get; set; } = new List<Client>();
        public SelectList ClientSelectList => new SelectList(ClientList, nameof(Client.Id), nameof(Client.OwnerName));
    }
}
