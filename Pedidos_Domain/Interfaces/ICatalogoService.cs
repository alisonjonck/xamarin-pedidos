﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos_Domain.Entities;

namespace Pedidos_Domain.Interfaces
{
    public interface ICatalogoService
    {
        Task<List<CatalogoPromocao>> GetPromocoesAsync();
    }
}
