﻿namespace Northwind.Services.Order.Model
{
    public class OrderResponse
    {
        public double Total { get; set; }

        public bool Status { get; set; }

        public string Message { get; set; }
    }
}