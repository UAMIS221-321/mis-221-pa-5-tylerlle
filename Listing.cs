using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_tylerlle
{
    public class Listing
    {
        private int listingID;
        private string trainerName;
        private string sessionDate;
        private string sessionTime;
        private double sessionCost; //$50 dollars, Extra: trainer can set their own rate. 
        private bool isTaken;
        private bool isDeleted;
        private int trainerID;
        static private int count;

        public Listing()
        {

        }
        public Listing(int listingID, string trainerName, string sessionDate, string sessionTime, double sessionCost, bool isTaken,bool isDeleted)
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.isTaken = isTaken;
            this.isDeleted = isDeleted;

        }

        public void SetListingID(){
            this.listingID = count++;
        }
        public int GetListingID(){
            return listingID;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public void SetSessionDate(string sessionDate)
        {
            this.sessionDate = sessionDate;
        }
        public string GetSessionDate()
        {
            return sessionDate;
        }

        public void SetSessionTime(string sessionTime)
        {
            this.sessionTime = sessionTime;
        }
        public string GetSessionTime()
        {
            return sessionTime;
        }

        public void SetSessionCost(double sessionCost)
        {
            this.sessionCost = sessionCost;
        }
        public double GetSessionCost()
        {
            return sessionCost;
        }

        public void SetIsTaken(bool isTaken)
        {
            this.isTaken = isTaken;
        }
        public bool GetIsTaken()
        {
            return isTaken;
        }

        static public void SetCount(int count){
            Listing.count = count;
        }

        static public int GetCount(){
            return count;
        }

        static public void IncCount(){
            count++;
        }
        public void SetIsDeleted(bool isDeleted){
            this.isDeleted = isDeleted;
        }

         public bool GetIsDeleted(){
            return isDeleted;
        }

        public int GetTrainerID(){
            return trainerID;
        }
        public string ToFile()
        {
            return $"{listingID}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{isTaken}#{isDeleted}";
        }

    }
}