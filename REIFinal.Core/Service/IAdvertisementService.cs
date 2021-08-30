using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
  public  interface IAdvertisementService
    {
        List<DtoAdvertisement> GetAll();
        string Create(Advertisement advertisement);
        string Update(Advertisement advertisement);
        string Delete(Advertisement advertisement);
        Advertisement GetById(Advertisement advertisement);
    }
}
