﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryContracts.BindingModels
{
    // Данные от клиента, для создания заказа
    public class CreateOrderBindingModel
    {
        public int GarmentId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
