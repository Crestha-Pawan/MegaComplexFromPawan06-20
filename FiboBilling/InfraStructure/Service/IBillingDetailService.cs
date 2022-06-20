using FiboBilling.InfraStructure.Assembler;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.Src.Dto;
using FiboInfraStructure.Entity.FiboBilling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboBilling.InfraStructure.Service
{
   
    public interface IBillingDetailService
    {
        Task<BillingDetailDto> InsertAsync(BillingDetailDto dto);
        Task<BillingDetail> Delete(long Id);
        Task<BillingDetailDto> UpdateAsync(BillingDetailDto dto);
    }
    public class BillingDetailService : IBillingDetailService
    {
        private readonly IBillingDetailRepository _repo;
        private readonly IBillingDetailAssembler _assembler;
        public BillingDetailService(IBillingDetailRepository repo
            , IBillingDetailAssembler assembler
            )
        {
            _repo = repo;
            _assembler = assembler;
        }

        public async Task<BillingDetail> Delete(long Id)
        {
            var billingDetail = await _repo.GetByIdAsync(Id) ?? throw new Exception();
            return await _repo.DeleteAsync(billingDetail).ConfigureAwait(true);
        }

        public async Task<BillingDetailDto> InsertAsync(BillingDetailDto dto)
        {
            BillingDetail billingDetail = new BillingDetail();
            _assembler.copyTo(billingDetail, dto);
            await _repo.AddSync(billingDetail);
            dto.Id = billingDetail.Id;
            return dto;
        }

        public async Task<BillingDetailDto> UpdateAsync(BillingDetailDto dto)
        {
            try
            {
                BillingDetail billingDetail = new BillingDetail();
                _assembler.modifyTo(billingDetail, dto);
                await _repo.UpdateAsync(billingDetail);
                dto.Id = billingDetail.Id;
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Billing with {dto.Id} not found.");
            }
        }
    }
}
