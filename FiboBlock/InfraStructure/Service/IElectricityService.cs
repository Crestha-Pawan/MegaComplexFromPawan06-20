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
    public interface IElectricityService
    {
        Task<ElectricityDto> Insertasync(ElectricityDto dto);
        Task<Electricity> Delete(long Id);
        Task<ElectricityDto> UpdateAsync(ElectricityDto dto);
        Task<Electricity> ToggleStatus(Electricity electricity);
    }
    public class ElectricityService : IElectricityService
    {
        private readonly IElectricityRepository _electricityRepository;
        private readonly IElectricityAssembler _assembler;
        public ElectricityService(IElectricityRepository electricityRepository,
            IElectricityAssembler assembler)
        {
            _electricityRepository = electricityRepository;
            _assembler = assembler;
        }
        public async Task<Electricity> Delete(long Id)
        {
            var electricity = await _electricityRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _electricityRepository.DeleteAsync(electricity).ConfigureAwait(true);
        }

        public async Task<ElectricityDto> UpdateAsync(ElectricityDto dto)
        {
            Electricity electricity = new Electricity();
            _assembler.modifyTo(electricity, dto);
            await _electricityRepository.UpdateAsync(electricity);
            return dto;
        }

        public async Task<ElectricityDto> Insertasync(ElectricityDto dto)
        {
            Electricity electricity = new Electricity();
            _assembler.copyTo(electricity, dto);
            await _electricityRepository.AddSync(electricity);
            dto.Id = electricity.Id;
            return dto;
        }
        public async Task<Electricity> ToggleStatus(Electricity electricity)
        {
            if (electricity != null)
            {
                electricity.ChangeStatus();
            }
            return await _electricityRepository.UpdateAsync(electricity).ConfigureAwait(true);
        }
    }
}
