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
    public interface IElectricityFineSetupService
    {
        Task<ElectricityFineSetupDto> Insertasync(ElectricityFineSetupDto dto);
        Task<ElectricityFineSetup> Delete(long Id);
        Task<ElectricityFineSetupDto> UpdateAsync(ElectricityFineSetupDto dto);
    }
    public class ElectricityFineSetupService : IElectricityFineSetupService
    {
        private readonly IElectricityFineSetupRepository _finerepo;
        private readonly IElectricityFineSetupAssembler _assembler;
        public ElectricityFineSetupService(IElectricityFineSetupRepository fineSetupRepository, IElectricityFineSetupAssembler assembler)
        {
            _finerepo = fineSetupRepository;
            _assembler = assembler;
        }

        public async Task<ElectricityFineSetup> Delete(long Id)
        {
            var fine = await _finerepo.GetByIdAsync(Id) ?? throw new Exception();
            return await _finerepo.DeleteAsync(fine).ConfigureAwait(true);
        }

        public async Task<ElectricityFineSetupDto> Insertasync(ElectricityFineSetupDto dto)
        {
            ElectricityFineSetup fineSetup = new ElectricityFineSetup();
            _assembler.copyTo(fineSetup, dto);
            await _finerepo.AddSync(fineSetup);
            dto.Id = fineSetup.Id;
            return dto;
        }

        public async Task<ElectricityFineSetupDto> UpdateAsync(ElectricityFineSetupDto dto)
        {
            ElectricityFineSetup fineSetup = new ElectricityFineSetup();
            _assembler.modifyTo(fineSetup, dto);
            await _finerepo.UpdateAsync(fineSetup);
            return dto;
        }
    }
}
