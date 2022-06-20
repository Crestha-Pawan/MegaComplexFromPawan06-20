using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboBlock.InfraStructure.Service
{
    public interface IElectricityUnitSetupService
    {
        Task<ElectricityUnitSetupDto> Insertasync(ElectricityUnitSetupDto dto);
        Task<ElectricityUnitSetup> Delete(long Id);
        Task<ElectricityUnitSetupDto> UpdateAsync(ElectricityUnitSetupDto dto);
    }
    public class ElectricityUnitSetupService : IElectricityUnitSetupService
    {
        private readonly IElectricityUnitSetupRepository _electricityRepository;
        private readonly IElectricityUnitSetupAssembler _assembler;
        public ElectricityUnitSetupService(IElectricityUnitSetupRepository electricityRepository,
            IElectricityUnitSetupAssembler assembler)
        {
            _electricityRepository = electricityRepository;
            _assembler = assembler;
        }
        public async Task<ElectricityUnitSetup> Delete(long Id)
        {
            var electricity = await _electricityRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _electricityRepository.DeleteAsync(electricity).ConfigureAwait(true);
        }

        public async Task<ElectricityUnitSetupDto> UpdateAsync(ElectricityUnitSetupDto dto)
        {
            try
            {
                ElectricityUnitSetup electricity = new ElectricityUnitSetup();
                _assembler.modifyTo(electricity, dto);
                await _electricityRepository.UpdateAsync(electricity);
                dto.Id = electricity.Id;
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"ElectricityUnitSetup with {dto.Id} not found.");
            }
        }

        public async Task<ElectricityUnitSetupDto> Insertasync(ElectricityUnitSetupDto dto)
        {
            ElectricityUnitSetup electricity = new ElectricityUnitSetup();
            _assembler.copyTo(electricity, dto);
            await _electricityRepository.UpdateAsync(electricity);
            dto.Id = electricity.Id;
            return dto;
        }
    }
}
