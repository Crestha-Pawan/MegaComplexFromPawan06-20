using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.InfraStructure.Assembler;
using FiboOffice.InfraStructure.Repository;
using FiboOffice.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboOffice.InfraStructure.Service
{
    public interface IFineSetupService
    {
        Task<FineSetupDto> Insertasync(FineSetupDto dto);
        Task<FineSetup> Delete(long Id);
        Task<FineSetupDto> UpdateAsync(FineSetupDto dto);
    }
    public class FineSetupService : IFineSetupService
    {
        private readonly IFineSetupRepository _finerepo;
        private readonly IFineSetupAssembler _assembler;
        public FineSetupService(IFineSetupRepository fineSetupRepository, IFineSetupAssembler assembler)
        {
            _finerepo = fineSetupRepository;
            _assembler = assembler;
        }
        public async Task<FineSetupDto> Insertasync(FineSetupDto dto)
        {
            FineSetup fineSetup = new FineSetup();
            _assembler.copyTo(fineSetup, dto);
            await _finerepo.AddSync(fineSetup);
            dto.Id = fineSetup.Id;
            return dto;
        }

        public async Task<FineSetupDto> UpdateAsync(FineSetupDto dto)
        {
            FineSetup fineSetup = new FineSetup();
            _assembler.modifyTo(fineSetup, dto);
            await _finerepo.UpdateAsync(fineSetup);
            return dto;
        }

        public async Task<FineSetup> Delete(long Id)
        {
            var office = await _finerepo.GetByIdAsync(Id) ?? throw new Exception();
            return await _finerepo.DeleteAsync(office).ConfigureAwait(true);
        }

    }
}
