﻿using OrderApi.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Autogenerated ID; same as ValueGeneratedOnAdd in CatalogContext
        public int Id { get; set; }

        public string EventName { get; set; }
        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }

        public int Units { get; set; } //quantity
        public int EventId { get; private set; }
        public Order Order { get; set; } //relationship with order (1:M mapping) order item should associated with only one order
        public int OrderId { get; set; } //foreign key relationship with order

        public OrderItem(int eventId, string eventName, decimal unitPrice, string pictureUrl, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }

            EventId = eventId;

            EventName = eventName;
            UnitPrice = unitPrice;

            Units = units;
            PictureUrl = pictureUrl;
        }

        public void SetPictureUri(string pictureUri) //method to change picture in the future if you want to 
        {
            if (!String.IsNullOrWhiteSpace(pictureUri))
            {
                PictureUrl = pictureUri;
            }
        }

        public void AddUnits(int units) //incase you want to update the quantity in order page
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }

            Units += units;
        }
    }
}
