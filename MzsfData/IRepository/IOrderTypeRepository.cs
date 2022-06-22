using MzsfData.Entities;
using System;
using System.Collections.Generic;

namespace MzsfData.IRepository
{
    public interface IOrderTypeRepository
    {
        List<OrderType> GetOrderTypes();
    }
}