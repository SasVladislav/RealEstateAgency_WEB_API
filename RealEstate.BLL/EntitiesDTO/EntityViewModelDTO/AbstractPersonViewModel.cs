﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO
{
    public abstract class AbstractPersonViewModel<T>
    {
        public AddressViewDTO AddressView { get; set; }
        public T Person { get; set; }
    }
}
