using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_tylerlle
{
    public class BookingUtility
    {
        private Booking[] bookings;
        private int maxBookings;
        private ListingUtility listingUtility = new ListingUtility();

        public BookingUtility(Booking[] bookings, int maxBookings, ListingUtility listingUtility)
        {
            this.bookings = bookings;
            this.maxBookings = maxBookings;
            this.listingUtility = listingUtility;
        }

        public BookingUtility()
        {

        }

        public BookingUtility(Booking[] bookings,ListingUtility listingUtility)
        {
            this.bookings = bookings;
            this.listingUtility = listingUtility;
        }

        public void GetAllBookings()
        {
            // Open file
            StreamReader inFile = new StreamReader("transactions.txt");

            // Process
            string line = inFile.ReadLine();
            Booking.SetCount(0);
            while (line != null)
            {
                System.Console.WriteLine("Processing line: " + line);
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }

            for (int i = 0; i < Booking.GetCount(); i++)
            {
                System.Console.WriteLine($"{bookings[i].ToFile()}");
                Console.ReadKey();
            }

            // closefile
            inFile.Close();
        }


        public void ViewAvailableSessions()
        {
            Console.WriteLine("Available training sessions:");
            StreamReader inFile = new StreamReader("listings.txt");
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                if (!bool.Parse(temp[5]) && !bool.Parse(temp[6]))
                {
                    Console.WriteLine($"ID: {temp[0]} - Trainer: {temp[1]} - Date: {temp[2]} - Time: {temp[3]} - Cost: ${temp[4]}");
                }
                line = inFile.ReadLine();
            }
            inFile.Close();
        }

        

        public Listing GetSelectedListing(int listingID)
        {
            StreamReader inFile = new StreamReader("listings.txt");
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                if (int.Parse(temp[0]) == listingID)
                {
                    inFile.Close();
                    return new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), bool.Parse(temp[5]), bool.Parse(temp[6]));
                }
                line = inFile.ReadLine();
            }
            inFile.Close();
            return null;
        }

        public void UpdateBookingStatus(int bookingID, string status)
        {
            for (int i = 0; i < bookings.Length; i++)
            {
                if (bookings[i] != null && bookings[i].GetBookingID() == bookingID)
                {
                    bookings[i].SetStatus(status);
                    Save();
                    break;
                }
            }
        }

        public void CancelSession(int bookingID)
        {
            UpdateBookingStatus(bookingID, "cancelled");
        }

        public void BookSession()
        {
            ViewAvailableSessions();
            Console.WriteLine("Enter the listing ID of the session you'd like to book:");
            int listingID = int.Parse(Console.ReadLine());

            Listing selectedListing = GetSelectedListing(listingID);

            if (selectedListing != null)
            {
                if (!selectedListing.GetIsTaken())
                {
                    Booking newBooking = new Booking();

                    newBooking.SetBookingID(Booking.GetCount());
                    Booking.IncCount();

                    Console.WriteLine("Enter the customer name:");
                    newBooking.SetCustomerName(Console.ReadLine());

                    Console.WriteLine("Enter the customer email:");
                    newBooking.SetCustomerEmail(Console.ReadLine());

                    newBooking.SetTrainingDate(selectedListing.GetSessionDate());
                    newBooking.SetTrainerID(selectedListing.GetTrainerID());
                    newBooking.SetTrainerName(selectedListing.GetTrainerName());
                    newBooking.SetStatus("booked");

                    for (int i = 0; i < bookings.Length; i++)
                    {
                        if (bookings[i] == null)
                        {
                            bookings[i] = newBooking;
                            break;
                        }
                    }
                    Save();

                    selectedListing.SetIsTaken(true);
                    listingUtility.UpdateListing(selectedListing);
                    listingUtility.Save();

                    Console.WriteLine($"Successfully booked session with ID: {newBooking.GetBookingID()}");
                }
                else
                {
                    Console.WriteLine("This session is already taken. Please select a different session.");
                }
            }
            else
            {
                Console.WriteLine("Listing ID not found :(");
            }
        }
    
        public void Save()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for (int i = 0; i < Booking.GetCount(); i++)
            {
                outFile.WriteLine(bookings[i].ToFile());
            }
            outFile.Close();
        }
    }
}