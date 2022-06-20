using FiboBilling.InfraStructure.Assembler;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.Src.Dto;
using FiboInfraStructure;
using FiboInfraStructure.Entity.FiboBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboBilling.InfraStructure.Service
{
    
    public interface IBillingService
    {
        Task<BillingDto> InsertAsync(BillingDto dto);
        Task<Billing> Delete(long Id);
        Task<BillingDto> UpdateAsync(BillingDto dto);

        Task<BillingDto> UpdateFromBillPaymentAsync(BillingDto dto);
    }
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _repo;
        private readonly IBillingAssembler _assembler;
        private readonly IBillingDetailRepository _dbRepo;
        public BillingService(IBillingRepository repo
            , IBillingAssembler assembler
            , IBillingDetailRepository dbRepo
        )
        {
            _repo = repo;
            _assembler = assembler;
            _dbRepo = dbRepo;
        }

        public async Task<Billing> Delete(long Id)
        {
            var billing = await _repo.GetByIdAsync(Id) ?? throw new Exception();
            return await _repo.DeleteAsync(billing).ConfigureAwait(true);
        }

        public async Task<BillingDto> InsertAsync(BillingDto dto)
        {
            try
            {
                Billing billing = new Billing();
                _assembler.copyTo(billing, dto);
                await _repo.AddSync(billing);
                dto.Id = billing.Id;
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Billing with {dto.Id} not found.");
            }
        }

        public async Task<BillingDto> UpdateAsync(BillingDto dto)
        {
            try
            {
                Billing billing = new Billing();
                _assembler.modifyTo(billing, dto);
                await _repo.UpdateAsync(billing);
                dto.Id = billing.Id;
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Billing with {dto.Id} not found.");
            }
        }
        public async Task<BillingDto> UpdateFromBillPaymentAsync(BillingDto dto)
        {
            try
            {
                Billing billing = new Billing();
                _assembler.modifyTo(billing, dto);
                billing.IsPaid = true;
                billing.Id= (long)dto.billingDetails.FirstOrDefault().BillingId;
                await _repo.UpdateAsync(billing);
                dto.Id = billing.Id;
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Billing with {dto.Id} not found.");
            }
        }

    }
}
