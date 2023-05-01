using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_tylerlle
{
    public class ListingUtility
    {
        private Listing[] listings;


        public ListingUtility(Listing[] listings)
        {
            this.listings = listings;
        }

        public ListingUtility()
        {
        }
        public void GetAllListings()
        {
            //open
            StreamReader inFile = new StreamReader("listings.txt");
            //process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), bool.Parse(temp[5]), bool.Parse(temp[6]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }

        public void AddListing()
        {
            Listing myList = new Listing();

            System.Console.WriteLine("Enter the trainer name for the listing:");
            myList.SetTrainerName(Console.ReadLine());

            System.Console.WriteLine("Enter the date of the session (mm/dd/yy):");
            myList.SetSessionDate(Console.ReadLine());

            System.Console.WriteLine("Enter the time of the session (hh:mm):");
            myList.SetSessionTime(Console.ReadLine());

            System.Console.WriteLine("Enter the cost of the session:");
            myList.SetSessionCost(int.Parse(Console.ReadLine()));

            string choice = "";
            while (choice == "")
            {
                System.Console.WriteLine("Enter 1 if the session has been taken or 2 if the session is available:");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        myList.SetIsTaken(true);
                        break;
                    case "2":
                        myList.SetIsTaken(false);
                        break;
                    default:
                        System.Console.WriteLine("Invalid Choice!");
                        choice = "";
                        break;
                }

            }
            myList.SetListingID();
            for (int i = 0; i < listings.Length; i++)
            {
                if (listings[i] == null)
                {
                    listings[i] = myList;
                    break;
                }
            }
            Save();
            System.Console.WriteLine(myList.GetListingID());

        }

        public void EditListing()
        {
            System.Console.WriteLine("Enter the listing ID for which you'd like to edit:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != 1)
            {
                System.Console.WriteLine("Enter the trainer name for the listing:");
                listings[foundIndex].SetTrainerName(Console.ReadLine());

                System.Console.WriteLine("Enter the date of the session:");
                listings[foundIndex].SetSessionDate(Console.ReadLine());

                System.Console.WriteLine("Enter the time of the session (HH:mm):");
                listings[foundIndex].SetSessionTime(Console.ReadLine());

                System.Console.WriteLine("Enter the cost of the session:");
                listings[foundIndex].SetSessionCost(int.Parse(Console.ReadLine()));

                string choice = "";
                while (choice == "")
                {
                    System.Console.WriteLine("Enter 1 if the session has been taken or 2 if the session is available:");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            listings[foundIndex].SetIsTaken(true);
                            break;
                        case "2":
                            listings[foundIndex].SetIsTaken(false);
                            break;
                        default:
                            System.Console.WriteLine("Invalid Choice!");
                            choice = "";
                            break;
                    }

                    Save();
                }
            }
            else
            {
                System.Console.WriteLine("listing ID not found :(");
            }
        }

        public void DeleteListing()
        {
            System.Console.WriteLine("Enter the listing ID for which you'd like to delete:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1)
            {
                System.Console.WriteLine($"Confirm that you would like to delete the listing with ID {listings[foundIndex].GetListingID()}.\n1 to confirm\n2 to cancel");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        listings[foundIndex].SetIsDeleted(true);
                        Save();
                        break;
                    case "2":
                        break;
                    default:
                        System.Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Listing ID not found :(");
            }
        }

        public void UpdateListing(Listing updatedListing){
            for (int i = 0; i < listings.Length; i++)
            {
                if (listings[i] != null && listings[i].GetListingID() == updatedListing.GetListingID()){
                    listings[i] = updatedListing;
                    break;
                }
            }
        }


        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                if (listings[i] != null)
                {
                outFile.WriteLine(listings[i].ToFile());
                }
            }
            outFile.Close();
        }

        public int Find(int searchVal)
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                if (listings[i].GetListingID() == searchVal)
                {
                    return i;
                }
            }
            return searchVal;
        }
    }
}