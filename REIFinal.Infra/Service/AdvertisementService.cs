using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository advertisementRepository;

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            this.advertisementRepository = advertisementRepository;
        }

        public string Create(Advertisement advertisement)
        {
             advertisementRepository.Create(advertisement);
            return "Sucessfully";
        }

        public string Delete(Advertisement advertisement)
        {
            advertisementRepository.Delete(advertisement);
            return "Deleted";
        }

        public List<DtoAdvertisement> GetAll()
        {
            return advertisementRepository.GetAll();
        }

        public Advertisement GetById(Advertisement advertisement)
        {
            return advertisementRepository.GetById(advertisement);
        }

        public string Update(Advertisement advertisement)
        {
            advertisementRepository.Update(advertisement);
            return "Updated";
        }
    }
}
