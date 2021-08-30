using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
    public interface IFavoritAdvRepository
    {
        List<Dtofavoritadv> GetAll(); //stored proc dbo.GetAll
        void Create(FavoritAdv favoritadv);//stored proc dbo.Insert
        void Delete(FavoritAdv favoritadv);//stored proc dbo.Delete
        Dtofavoritadv GetById(FavoritAdv favoritadv);//stored proc dbo.Getbyid
    }
}
