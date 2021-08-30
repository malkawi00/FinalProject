using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
   public interface IFavoritAdvService
    {
        List<Dtofavoritadv> GetAll();
        string Create(FavoritAdv favoritadv);
        string Delete(FavoritAdv favoritadv);
        Dtofavoritadv GetById(FavoritAdv favoritadv);
    }
}
