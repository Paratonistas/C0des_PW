using ConsoleBordingCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBordingCards.Helpers
{
    internal interface IBoardingCardsSort
    {
        void Run();
    }
        internal class BordingCardsSort : IBoardingCardsSort
    {
        public static List<BoardingCard> BoardingCardlst = new List<BoardingCard>() {
            new BoardingCard() { Id = 25, Departure = "H", Destination = "I", MeansOfTransportation ="Plane", SeatAssignment ="45B"} ,
             new BoardingCard() { Id = 29, Departure = "R", Destination = "S", MeansOfTransportation ="Plane", SeatAssignment ="ERZA3"} ,
             new BoardingCard() { Id = 32, Departure = "E", Destination = "F", MeansOfTransportation ="Plane", SeatAssignment ="ERZA3"} ,
             new BoardingCard() { Id = 220, Departure = "S", Destination = "T", MeansOfTransportation ="Plane", SeatAssignment ="ERZA3"} ,
             new BoardingCard() { Id = 20, Departure = "T", Destination = "U", MeansOfTransportation ="Bus", SeatAssignment ="ERZA3"},
              new BoardingCard() { Id = 26, Departure = "I", Destination = "J", MeansOfTransportation ="Plane", SeatAssignment ="ERZA3"} ,
             new BoardingCard() { Id = 26, Departure = "J", Destination = "K", MeansOfTransportation ="Bus", SeatAssignment ="ERA3"} ,
             new BoardingCard() { Id = 27, Departure = "K", Destination = "L", MeansOfTransportation ="Bus", SeatAssignment ="ERA3"} ,
              new BoardingCard() { Id = 12, Departure = "B", Destination = "c", MeansOfTransportation ="Plane", SeatAssignment ="DS45"} ,
             new BoardingCard() { Id = 8, Departure = "L", Destination = "M", MeansOfTransportation ="Bus", SeatAssignment ="DS45"} ,
             new BoardingCard() { Id = 28, Departure = "N", Destination = "P", MeansOfTransportation ="Bus", SeatAssignment ="DS45"} ,
             new BoardingCard() { Id = 27, Departure = "P", Destination = "Q", MeansOfTransportation ="Plane", SeatAssignment ="DS45"} ,
             new BoardingCard() { Id = 28, Departure = "Q", Destination = "R", MeansOfTransportation ="Plane", SeatAssignment ="S45"},
             new BoardingCard() { Id = 2, Departure = "A", Destination = "B", MeansOfTransportation ="Bus", SeatAssignment ="S45"} ,
             new BoardingCard() { Id = 29, Departure = "M", Destination = "N", MeansOfTransportation ="Plane", SeatAssignment ="S45"} ,
              new BoardingCard() { Id = 21, Departure = "c", Destination = "D", MeansOfTransportation ="Bus", SeatAssignment ="S45"} ,
             new BoardingCard() { Id = 23, Departure = "D", Destination = "E", MeansOfTransportation ="Bus", SeatAssignment ="SA45"} ,
             new BoardingCard() { Id = 22, Departure = "F", Destination = "G", MeansOfTransportation ="Bus", SeatAssignment ="SA45"} ,
             new BoardingCard() { Id = 24, Departure = "G", Destination = "H", MeansOfTransportation ="Bus", SeatAssignment ="45B"}


         };


        public static List<BoardingCard> SortBoardingCards(List<BoardingCard> boardingCards)
        {
            BoardingCard  lastBoardingCard = null;
            List<BoardingCard> sortedList = new List<BoardingCard>();
            List<string> allDepartures = boardingCards.Select(x => x.Destination).ToList();
            //Console.WriteLine("card list:" + allDepartures.Count);
            BoardingCard originCard = boardingCards.Where(x => allDepartures.Contains(x.Departure) == false).FirstOrDefault();
            // Pick an unvisited boarding card and push it to the stack
            //stack.Push(boardingCards[0]);
            BoardingCard temp = originCard;
            sortedList.Add(originCard);
            //Console.WriteLine("card 1 departure:");
            //Console.WriteLine(originCard.Departure);
            while (lastBoardingCard == null)
            {
                // Find the next boarding card that has the same Destination location as the current card's departure location
                BoardingCard next = boardingCards.Find(x => x.Departure == temp.Destination);
               

                if (next == null)
                {
                    lastBoardingCard = temp;
                }
                else
                {
                    //Console.WriteLine("card :");
                    //Console.WriteLine(next.Departure);
                    temp = next;
                    sortedList.Add(temp);
                }
            }

            return sortedList;
        }
        public static string BuildJourneyDescription(List<BoardingCard> sortedBoardingCards)
        {
            StringBuilder description = new StringBuilder();

            for (int i = 0; i < sortedBoardingCards.Count; i++)
            {
                BoardingCard current = sortedBoardingCards[i];

                if (i == 0)
                {
                    description.Append($"Take {current.MeansOfTransportation} from {current.Departure} to {current.Destination}.");
                }
                else if (i == sortedBoardingCards.Count - 1)
                {
                    description.Append($"\nYou have arrived at your final destination.");
                }
                else
                {
                    BoardingCard next = sortedBoardingCards[i + 1];
                    description.Append($"\nTake {current.MeansOfTransportation} from {current.Departure} to {next.Destination}.");
                }

                if (current.SeatAssignment != null)
                {
                    description.Append($" Sit in SeatAssignment {current.SeatAssignment}.");
                }

                if (current.LuggageDropArea != null)
                {
                    description.Append($" {current.LuggageDropArea}.");
                }
            }

            return description.ToString();
        }

        public void Run()
        {
            var mysortedList = SortBoardingCards(boardingCardsForTest);
            var tripToDisplay= BuildJourneyDescription(mysortedList);
            Console.WriteLine(tripToDisplay);
        }

        public static List<BoardingCard> boardingCardsForTest = new List<BoardingCard>
        {
 
            
            
            
            new BoardingCard { Departure = "Stockholm", Destination = "New York JFK", MeansOfTransportation = "Flight SK22", SeatAssignment = "7B", LuggageDropArea = "LuggageDropArea will be automatically transferred from your last leg" },
            new BoardingCard { Departure = "Gerona Airport", Destination = "Stockholm", MeansOfTransportation = "Flight SK455", SeatAssignment = "3A", LuggageDropArea = "LuggageDropArea drop at ticket counter 344" },
             new BoardingCard { Departure = "Barcelona", Destination = "Gerona Airport", MeansOfTransportation = "Airport bus", SeatAssignment = null, LuggageDropArea = "No SeatAssignment assignment" },

            new BoardingCard { Departure = "Madrid", Destination = "Barcelona", MeansOfTransportation = "Train 78A", SeatAssignment = "45B", LuggageDropArea = null }
        };

    }
}
