using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBordingCards.Models
{
    internal class BoardingCard
    {
        public int Id { get; set; }
        public string SeatAssignment { get; set; }
        public string Departure { get; set; }
        public string Gate { get; set; }
        public string LuggageDropArea { get; set; }
        public string Destination { get; set; }
        public string MeansOfTransportation { get; set; }
    }
}
