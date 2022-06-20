using FiboInfraStructure.Entity.FiboParty;
using FiboParty.Infrastructure.Assembler;
using FiboParty.Infrastructure.Repository;
using FiboParty.Src.Dto;
using System;
using System.Threading.Tasks;

namespace FiboParty.Infrastructure.Service
{
    public interface IPartyService
    {
        Task<PartyDto> Insertasync(PartyDto dto);
        Task<Party> Delete(long Id);
        Task<PartyDto> UpdateAsync(PartyDto dto);
    }
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;
        private readonly IPartyAssembler _assembler;
        //private readonly ILocalLevelRepository _localRepo;
        //private readonly IDistrictRepository _districtRepo;
        public PartyService(IPartyRepository partyRepository,
            IPartyAssembler assembler
            //ILocalLevelRepository localLevelRepository,
            //IDistrictRepository districtRepository
            )
        {
            _partyRepository = partyRepository;
            _assembler = assembler;
            //_localRepo = localLevelRepository;
            //_districtRepo = districtRepository;
        }
        public async Task<PartyDto> Insertasync(PartyDto dto)
        {
            Party party = new Party();
            _assembler.copyTo(party, dto);
            //await setAddress(dto.LocalLevelId.Value, dto.DistrictId.Value, party);
            await _partyRepository.AddSync(party);
            dto.Id = party.Id;
            return dto;
        }

            public async Task<PartyDto> UpdateAsync(PartyDto dto)
        {
            Party party = new Party();
            _assembler.modifyTo(party, dto);
            //await setAddress(dto.LocalLevelId.Value, dto.DistrictId.Value, party);
            await _partyRepository.UpdateAsync(party);
            return dto;
        }

            public async Task<Party> Delete(long Id)
        {
            var localLevel = await _partyRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _partyRepository.DeleteAsync(localLevel).ConfigureAwait(true);
        }

        //private async Task<string> setAddress(long LocalLevelId, long DistrictId, Party party)
        //{
        //    string address = string.Empty;
        //    var local = await _localRepo.GetByIdAsync(LocalLevelId);
        //    var district = await _districtRepo.GetByIdAsync(DistrictId);
        //    if (local != null && district != null)
        //    {
        //        address = party.setAddress(local, district);
        //    }
        //    return address;
        //}
    }
}
