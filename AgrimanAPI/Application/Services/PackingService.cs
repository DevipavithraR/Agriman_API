using AgrimanAPI.Application.Ports;
using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Services
{
    public class PackingService : IPackingService
    {
        private readonly IPackingRepository _repository;

        public PackingService(IPackingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Packing>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(PackingDto packingDto)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(packingDto.PackingName))
                throw new ArgumentException("Packing name is required");
            if (packingDto.UnitAmount <= 0)
                throw new ArgumentException("UnitAmount must be greater than 0");

            // Map DTO → Entity
            var packing = new Packing
            {
                PackingName = packingDto.PackingName,
                Unit = packingDto.Unit,
                UnitAmount = packingDto.UnitAmount
            };

            await _repository.AddAsync(packing);
        }

        public async Task AddDetailAsync(PackingDetailDto detailDto)
        {
            if (detailDto.NumberOfUnits <= 0)
                throw new ArgumentException("NumberOfUnits must be greater than 0");

            // Get the master Packing
            var packing = await _repository.GetByIdAsync(detailDto.PackingId);
            if (packing == null)
                throw new Exception("PackingId does not exist");

            // Calculate UnitAmount
            float calculatedAmount = packing.UnitAmount * detailDto.NumberOfUnits;

            // Map DTO → Entity
            var detail = new PackingDetail
            {
                PackingId = detailDto.PackingId,
                PackingName = packing.PackingName,
                NumberOfUnits = detailDto.NumberOfUnits,
                UnitAmount = calculatedAmount
            };

            await _repository.AddDetailAsync(detail);
        }
    }
}

