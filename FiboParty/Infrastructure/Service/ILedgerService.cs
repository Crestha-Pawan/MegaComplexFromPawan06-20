using FiboInfraStructure.Entity.Ledger;
using FiboParty.Infrastructure.Assembler;
using FiboParty.Infrastructure.Repository;
using FiboParty.Src.Dto;
using System;
using System.Threading.Tasks;
using FiboInfraStructure;
using FiboOffice.InfraStructure.Repository;
using System.Linq;
namespace FiboParty.Infrastructure.Service
{
    public interface ILedgerService
    {
        Task<LedgerDto> Insertasync(LedgerDto dto);
        Task<Ledger> Delete(long Id);
        Task<LedgerDto> UpdateAsync(LedgerDto dto);
    }
    public class LedgerService : ILedgerService
    {
        private readonly ILedgerRepository _ledgerRepository;
        private readonly ILedgerAssembler _assembler;
        //private readonly ILocalLevelRepository _localRepo;
        //private readonly IDistrictRepository _districtRepo;
        private readonly IPartyAssembler _partyAssembler;
        private readonly IPartyRepository _partyRepository;
        private readonly ILedgerDetailService _ledgerDetailService;
        private readonly ILedgerDetailRepository _ledgerDetailRepository;
        private readonly IFiscalYearRepository _fiscalYearRepository;


        public LedgerService(ILedgerRepository ledgerRepository,
            ILedgerAssembler assembler,
            //ILocalLevelRepository localLevelRepository,
            //IDistrictRepository districtRepository,
            IPartyAssembler partyAssembler,
            IPartyRepository partyRepository,
            ILedgerDetailService ledgerDetailService,
            ILedgerDetailRepository ledgerDetailRepository
            , IFiscalYearRepository fiscalYearRepository)
        {
            _ledgerRepository = ledgerRepository;
            _assembler = assembler;
            //_localRepo = localLevelRepository;
            //_districtRepo = districtRepository;
            _partyAssembler = partyAssembler ;
            _partyRepository = partyRepository;
            _ledgerDetailService = ledgerDetailService;
            _ledgerDetailRepository = ledgerDetailRepository;
            _fiscalYearRepository = fiscalYearRepository;
        }
        public async Task<LedgerDto> Insertasync(LedgerDto dto)
        {
            var fiscalyear = await _fiscalYearRepository.GetAllFiscalYearAsync();
            var fiscalyr = fiscalyear.Where(x => x.IsActive()).FirstOrDefault();
            Ledger ledger = new Ledger();
            _assembler.copyTo(ledger, dto);
            ledger.FiscalYearId = fiscalyr.Id;
             await _ledgerRepository.AddSync(ledger);

            if (dto.LedgerDetailDtos.Count > 0)
            {
                foreach (var detail in dto.LedgerDetailDtos)
                {
                    detail.LedgerId = ledger.Id;
                    detail.PartyId = ledger.PartyId;
                    await _ledgerDetailService.Insertasync(detail);
                }
                
            }
            return dto;
            //Ledger ledger = new Ledger();
            //_assembler.copyTo(ledger, dto);
            //await _ledgerRepository.AddSync(ledger);
            //dto.Id = ledger.Id;
            //return dto;
        }

        public async Task<LedgerDto> UpdateAsync(LedgerDto dto)
         {
            Ledger ledger = new Ledger();
            _assembler.modifyTo(ledger, dto);
            await _ledgerRepository.UpdateAsync(ledger);
            foreach (var detail in dto.ledgerDetails)
            {
                await _ledgerDetailService.UpdateLedgerDetail(detail);
            }
            return dto;
        }

        public async Task<Ledger> Delete(long Id)
        {
            var localLevel = await _ledgerRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _ledgerRepository.DeleteAsync(localLevel).ConfigureAwait(true);
        }
    }
}
