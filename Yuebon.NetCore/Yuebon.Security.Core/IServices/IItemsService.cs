using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface IItemsService:IService<Items, ItemsOutputDto, string>
    {
    }
}
