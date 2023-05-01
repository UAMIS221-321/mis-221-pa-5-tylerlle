/* EXTRAS:
Cool Welcome Display
test logs
trainers can set own rates
*/
//start main
using mis_221_pa_5_tylerlle;
Trainer[] trainers = new Trainer[50];
TrainerUtility trainerUtility = new TrainerUtility(trainers);
Listing[] listings = new Listing[100];
ListingUtility listingUtility = new ListingUtility(listings);
Booking[] bookings = new Booking[200];
BookingUtility bookingUtility = new BookingUtility(bookings, listingUtility);

trainerUtility.GetAllTrainers();
listingUtility.GetAllListings();
bookingUtility.GetAllBookings();
PauseAction();
BookingReport bookingReport = new BookingReport(bookingUtility);

WelcomeDisp();
DisplayMenu(trainerUtility, listingUtility, bookingUtility, bookingReport);

//end main



//in trainer reports: make sure it only prints with ShowTrainer as True



//METHODS BELOW

static void WelcomeDisp()
{
    bool show = true;
    do
    {
        while (!Console.KeyAvailable)
        {
            string alert = @"   _____         _        _    _ _                 ___ _                    _           
  |_   _| _ __ _(_)_ _   | |  (_) |_____   __ _   / __| |_  __ _ _ __  _ __(_)___ _ _   
    | || '_/ _` | | ' \  | |__| | / / -_) / _` | | (__| ' \/ _` | '  \| '_ \ / _ \ ' \  
  __|_||_| \__,_|_|_||_| |____|_|_\_\___| \__,_|  \___|_||_\__,_|_|_|_| .__/_\___/_||_| 
 | _ \___ _ _ ___ ___ _ _  __ _| | | __(_) |_ _ _  ___ ______         |_|               
 |  _/ -_) '_(_-</ _ \ ' \/ _` | | | _|| |  _| ' \/ -_|_-<_-<                           
 |_| \___|_| /__/\___/_||_\__,_|_| |_| |_|\__|_||_\___/__/__/
 ";
            Console.Clear();
            string details2 = @"________________________________________________________________________________________________ | | | Welcome to... | | | ";
            string details = @"| | | Press esc to continue | | |____________________________________________________________________________________| | |";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(details2);
            Console.ForegroundColor = show ? ConsoleColor.Red : ConsoleColor.White;
            show = !show;
            Console.WriteLine(alert);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(details); Thread.Sleep(800);
        }
    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    Console.Clear();
}

static void PauseAction()
{
    System.Console.WriteLine("Press any key to continue...");
    Console.ReadKey(true);
}

static void DisplayMenu(TrainerUtility trainerUtility, ListingUtility listingUtility, BookingUtility bookingUtility, BookingReport bookingReport)
{
    string choice = ""; // priming read
    while (choice != "5") // while loop
    {
        Console.Clear();
        System.Console.WriteLine("Welcome to TLAC!\n\nEnter the number for your choice:\n1: Manage trainer data\n2: Manage listing data\n3: Manage customer booking data\n4: Run Reports\n5: Exit TLAC");
        choice = Console.ReadLine(); //update read

        switch (choice)
        {
            case "1":
                Console.Clear();
                TrainerMenu(trainerUtility);
                break;
            case "2":
                Console.Clear();
                ListingMenu(listingUtility);
                //manage listing data
                break;
            case "3":
                Console.Clear();
                BookingMenu(bookingUtility);
                //manage customer booking data
                break;
            case "4":
                Console.Clear();
                ReportMenu(bookingUtility, bookingReport);
                //run reports
                break;
            case "5":
                System.Console.WriteLine("Exiting program...");
                break;
            default:
                System.Console.WriteLine("Invalid Choice :(");
                PauseAction();
                break;
        }
    }
}

static void TrainerMenu(TrainerUtility trainerUtility)
{
    string choice = ""; // priming read
    while (choice != "4") // while loop
    {
        Console.Clear();
        System.Console.WriteLine("*****TRAINER MANAGER*****\nEnter the number for your choice:\n1: Add Trainer\n2: Edit Trainer\n3: Delete Trainer\n4: Exit Trainer Manager");
        choice = Console.ReadLine(); //update read
        switch (choice)
        {
            case "1":
                Console.Clear();
                trainerUtility.AddTrainer();
                break;
            case "2":
                Console.Clear();
                trainerUtility.EditTrainer();
                break;
            case "3":
                Console.Clear();
                trainerUtility.DeleteTrainer();
                break;
            case "4":
                System.Console.WriteLine("Exiting Trainer Manager...");
                break;
            default:
                System.Console.WriteLine("Invalid Choice :(");
                PauseAction();
                break;
        }
    }
}

static void ListingMenu(ListingUtility listingUtility)
{
    string choice = ""; // priming read
    while (choice != "4") // while loop
    {
        Console.Clear();
        System.Console.WriteLine("*****LISTING MANAGER*****\nEnter the number for your choice:\n1: Add Listing\n2: Edit Listing\n3: Delete Listing\n4: Exit Listing Manager");
        choice = Console.ReadLine(); //update read
        switch (choice)
        {
            case "1":
                Console.Clear();
                listingUtility.AddListing();
                break;
            case "2":
                Console.Clear();
                listingUtility.EditListing();
                break;
            case "3":
                Console.Clear();
                listingUtility.DeleteListing();
                break;
            case "4":
                System.Console.WriteLine("Exiting Listing Manager...");
                break;
            default:
                System.Console.WriteLine("Invalid Choice :(");
                PauseAction();
                break;
        }
    }
}

static void BookingMenu(BookingUtility bookingUtility)
{
    string choice = ""; // priming read
    while (choice != "5") // while loop
    {
        Console.Clear();
        System.Console.WriteLine("*****BOOKING MANAGER*****\nEnter the number for your choice\n1: View available training sessions\n2: Book a session\n3: Update booking status\n4: Cancel session\n5: Exit Booking");
        choice = Console.ReadLine(); //update read
        switch (choice)
        {
            case "1":
                bookingUtility.ViewAvailableSessions();
                PauseAction();
                break;
            case "2":
                bookingUtility.BookSession();
                break;
            case "3":
                Console.WriteLine("Enter the booking ID to update status:");
                int bookingID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new status (booked/completed/cancelled):");
                string newStatus = Console.ReadLine();
                bookingUtility.UpdateBookingStatus(bookingID, newStatus);
                Console.WriteLine($"Booking status for ID {bookingID} updated to {newStatus}");
                PauseAction();
                break;
            case "4":
                Console.WriteLine("Enter the booking ID to cancel:");
                int cancelBookingID = int.Parse(Console.ReadLine());
                bookingUtility.CancelSession(cancelBookingID);
                Console.WriteLine($"Session with booking ID {cancelBookingID} has been cancelled.");
                PauseAction();
                break;
            case "5":
                System.Console.WriteLine("Exiting Booking Manager...");
                break;
            default:
                System.Console.WriteLine("Invalid Choice :(");
                PauseAction();
                break;
        }
    }
}

static void ReportMenu(BookingUtility bookingUtility, BookingReport bookingReport)
{
    string choice = ""; // priming read
    while (choice != "4") // while loop
    {
        System.Console.WriteLine("*****REPORT MANAGER*****\nEnter the number for your choice:\n1: Individual Customer Sessions\n2: Historical Customer Sessions\n3: Historical Revenue Report\n4: Exit");
        choice = Console.ReadLine(); //update read
        switch (choice)
        {
            case "1":
                // Console.Clear();
                // bookingReport.IndvidualCustomerSessions();
                break;
            case "2":
                // Console.Clear();
                bookingReport.HistoricalCustomerSessions();
                break;
            case "3":
                // Console.Clear();
                // bookingReport.HistoricalRevenueReport();
                break;
            case "4":
                System.Console.WriteLine("Exiting Report Manager...");
                break;
            default:
                System.Console.WriteLine("Invalid Choice :(");
                PauseAction();
                break;
        }
    }
}