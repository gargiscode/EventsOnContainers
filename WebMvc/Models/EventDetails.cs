﻿using System;

namespace WebMvc.Models
{
    public class EventDetails
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        //public int Ticket { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public int Likes { get; set; }
        public int TypeId { get; set; }
        public int LocationId { get; set; }
        public string TicketType { get; set; } //free/paid/subscription/trial
        public int AvailableSeats { get; set; }
        public string State { get; set; }
        public  string EventType { get; set; }
        public  string EventLocation { get; set; }
    }
}