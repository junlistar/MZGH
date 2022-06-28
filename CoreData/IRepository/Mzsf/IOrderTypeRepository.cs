using Data.Entities.Mzsf;
using System;
using System.Collections.Generic;

namespace Data.IRepository.Mzsf
{
    public interface IOrderTypeRepository
    {
        List<OrderType> GetOrderTypes();
    }
}