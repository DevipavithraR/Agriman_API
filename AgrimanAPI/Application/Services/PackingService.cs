using AgrimanAPI.Application.Ports;
using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Services
{
    public class PackingService
    {
        private readonly IPackingRepository _repository;

        public PackingService(IPackingRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PackingDetail>> GetAllAsync()
            => _repository.GetAllAsync();
        public async Task<PackingDetail> CreateAsync(int packingId, int numberOfUnits)
        {
            if (numberOfUnits <= 0)
                throw new ArgumentException("NumberOfUnits must be greater than 0");

            // ✅ Get MASTER packing
            var packingMaster = await _repository.GetPackingByIdAsync(packingId);
            if (packingMaster == null)
                throw new Exception("PackingId does not exist");

            // ✅ Calculate
            float totalAmount = packingMaster.UnitAmount * numberOfUnits;

            // ✅ Create TRANSACTION
            var detail = new PackingDetail
            {
                PackingId = packingMaster.Id,
                PackingName = packingMaster.PackingName,
                NumberOfUnits = numberOfUnits,
                UnitAmount = totalAmount
            };

            // ✅ Save transaction
            return await _repository.AddAsync(detail);
        }

    }
}

