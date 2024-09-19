﻿using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO
{
    public class OrderStatusDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]

        public OrderStatus status { get; set; }
    }
}
