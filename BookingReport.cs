using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_tylerlle
{
    public class BookingReport
    {
        private Booking[] bookings;
        private BookingUtility bookingUtility;

        public BookingReport(BookingUtility bookingUtility)
        {
            this.bookingUtility = bookingUtility;
        }

        public void SortByCustomerAndDate()
        {
            // if (bookings == null|| bookings.Length == 0)
            // {
            //     return;
            // }
            for (int i = 0; i < Booking.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Booking.GetCount(); j++)
                {
                    //     bookings[j].GetCustomerEmail() == bookings[min].GetCustomerEmail() && DateTime.Parse(bookings[j].GetTrainingDate()) < DateTime.Parse(bookings[min].GetTrainingDate())
                    if(this.bookings[j].GetCustomerEmail().CompareTo(this.bookings[min].GetCustomerEmail()) < 0) 
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i);
                }
            }
        }

        public void HistoricalCustomerSessions()
        {
            SortByCustomerAndDate();
            System.Console.WriteLine($"Total Bookings: {Booking.GetCount()}");
            if (bookings == null || bookings.Length == 0)
            {
                System.Console.WriteLine("no bookings found.");
                return;
            }
            string currEmail = bookings[0].GetCustomerEmail();
            int count = 1;
            System.Console.WriteLine("current email:" + currEmail);

            for (int i = 1; i < bookings.Length; i++)
            {
                Console.WriteLine("Processing booking: " + i); // Debug line
                Console.WriteLine("Booking email: " + bookings[i].GetCustomerEmail()); // Debug line
                if (bookings[i].GetCustomerEmail() == currEmail)
                {
                    count++;
                }
                else
                {
                    System.Console.WriteLine($"{currEmail} has {count} sessions");
                    currEmail = bookings[i].GetCustomerEmail();
                    count = 1;
                    ProcessBreak(currEmail, count, bookings[i]);
                }
            }
            ProcessBreak(currEmail, count);
        }

        public void ProcessBreak(string currEmail, int count, Booking newBooking)
        {
            System.Console.WriteLine($"{currEmail}\t{count}");
            currEmail = newBooking.GetCustomerEmail();
            count = 1;
        }

        private void ProcessBreak(string currEmail, int count)
        {
            Console.WriteLine($"{currEmail}\t{count}");
        }
        public void Swap(int x, int y)
        {
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }
    }
}