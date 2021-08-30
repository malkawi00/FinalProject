using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Infra.Service
{
    public class FavoritAdvService : IFavoritAdvService
    {
        private readonly IFavoritAdvRepository favoritAdvRepository;

        public FavoritAdvService(IFavoritAdvRepository favoritAdvRepository)
        {
            this.favoritAdvRepository = favoritAdvRepository;
        }

        public string Create(FavoritAdv favoritadv)
        {
            favoritAdvRepository.Create(favoritadv);
            return "Sucessfully";
        }

        public string Delete(FavoritAdv favoritadv)
        {
            favoritAdvRepository.Delete(favoritadv);
            return "Deleted";
        }

        public List<Dtofavoritadv> GetAll()
        {
          return  favoritAdvRepository.GetAll();
        }

        public Dtofavoritadv GetById(FavoritAdv favoritadv)
        {
            return favoritAdvRepository.GetById(favoritadv);
        }

    }
}
