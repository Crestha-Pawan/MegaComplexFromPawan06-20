
using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using FiboParty.Infrastructure.Assembler;
using FiboParty.Infrastructure.Repository;
using FiboParty.Src.Dto;
using System;
using System.Threading.Tasks;
using FiboInfraStructure;

namespace FiboParty.Infrastructure.Service
{
    public interface ILedgerDetailService
    {
        Task<LedgerDetailDto> Insertasync(LedgerDetailDto dto);
        Task<LedgerDetail> Delete(long Id);
        Task<LedgerDetailDto> UpdateAsync(LedgerDetailDto dto);
        Task<LedgerDto> InsertAsyncFromAddEntry(LedgerDto dto);
        Task<LedgerDetail> UpdateLedgerDetail(LedgerDetail detail);
        Task<LedgerDto> SaveAndDelete(LedgerDto dto);
    }
    public class LedgerDetailService : ILedgerDetailService
    {
        private readonly ILedgerDetailRepository _ledgerDetailRepository;
        private readonly ILedgerDetailAssembler _assembler;
        //private readonly ILocalLevelRepository _localRepo;
        //private readonly IDistrictRepository _districtRepo;
        public LedgerDetailService(ILedgerDetailRepository ledgerDetailRepository,
            ILedgerDetailAssembler assembler
            //ILocalLevelRepository localLevelRepository,
            //IDistrictRepository districtRepository
            )
        {
            _ledgerDetailRepository = ledgerDetailRepository;
            _assembler = assembler;
            //_localRepo = localLevelRepository;
            //_districtRepo = districtRepository;
        }
        public async Task<LedgerDetailDto> Insertasync(LedgerDetailDto dto)
        {
            LedgerDetail ledgerDetail = new LedgerDetail ();
            _assembler.copyTo(ledgerDetail, dto);
            await _ledgerDetailRepository.AddSync(ledgerDetail);
            dto.Id = ledgerDetail.Id;
            return dto;
        }

        public async Task<LedgerDetailDto> UpdateAsync(LedgerDetailDto dto)
        {
            LedgerDetail ledgerDetail = new LedgerDetail();
            _assembler.modifyTo(ledgerDetail, dto);
            await _ledgerDetailRepository.UpdateAsync(ledgerDetail);
            return dto;
        }
        public async Task<LedgerDto> InsertAsyncFromAddEntry(LedgerDto dto)
        {
            foreach (var item in dto.LedgerDetailDtos)
            {
                LedgerDetail ledgerDetail = new LedgerDetail();
                ledgerDetail.CreatedDate = DateTime.Now;
                ledgerDetail.CreatedBy = dto.CreatedBy;
                ledgerDetail.BillNo = item.BillNo;
                ledgerDetail.CreditAmount = item.CreditAmount;
                ledgerDetail.DebitAmount = item.DebitAmount;
                ledgerDetail.Remarks = item.Remarks;
                ledgerDetail.LedgerId = dto.Id;
                ledgerDetail.PartyId = dto.PartyId;
                ledgerDetail.Date = item.Date.ToEnglishDate();
                await _ledgerDetailRepository.AddSync(ledgerDetail);
            }
            return dto;
        }
        public async Task<LedgerDetail> Delete(long Id)
        {
            var localLevel = await _ledgerDetailRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _ledgerDetailRepository.DeleteAsync(localLevel).ConfigureAwait(true);
        }

        public async Task<LedgerDetail> UpdateLedgerDetail(LedgerDetail dto)
        {
            LedgerDetail ledgerDetail = new LedgerDetail();
            ledgerDetail.Id = dto.Id;
            ledgerDetail.CreatedBy = dto.CreatedBy;
            ledgerDetail.CreatedDate = dto.CreatedDate;
            ledgerDetail.ModifiedBy = dto.ModifiedBy;
            ledgerDetail.ModifiedDate = DateTime.Now.Date;
            ledgerDetail.BillNo = dto.BillNo;
            ledgerDetail.CreditAmount = dto.CreditAmount;
            ledgerDetail.DebitAmount = dto.DebitAmount;
            ledgerDetail.Remarks = dto.Remarks;
            ledgerDetail.LedgerId = dto.LedgerId;
            ledgerDetail.Date = dto.Date.ToEnglishDate();
            await _ledgerDetailRepository.UpdateAsync(ledgerDetail);
            return dto;
        }

        public async Task<LedgerDto> SaveAndDelete(LedgerDto dto)
        {
            var ledgerdetails = await _ledgerDetailRepository.GetByLedgerDetailsId(dto.Id);
            foreach (var item in ledgerdetails)
            {
                await Delete(item.Id);
            }

            foreach (var dto_info in dto.LedgerDetailDtos)
            {
                dto_info.LedgerId = dto.Id;
                dto_info.CreatedBy = dto.CreatedBy;
                await Insertasync(dto_info);
            }
            return dto;
        }
    }
}
