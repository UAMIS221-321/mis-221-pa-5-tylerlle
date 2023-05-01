using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_tylerlle
{
    public class Booking
    {
        private int bookingID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        private int trainerID;
        private string trainerName;
        private string status;
        private static int count;

        public Booking(int bookingID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, string status)
        {
            this.bookingID = bookingID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }

        public Booking()
        {
        }

        public int GetBookingID()
        {
            return bookingID;
        }

        public void SetBookingID(int bookingID)
        {
            this.bookingID = bookingID;
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public string GetCustomerEmail()
        {
            return customerEmail;
        }

        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }

        public string GetTrainingDate()
        {
            return trainingDate;
        }

        public void SetTrainingDate(string trainingDate)
        {
            this.trainingDate = trainingDate;
        }

        public int GetTrainerID()
        {
            return trainerID;
        }

        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }

        public string GetStatus()
        {
            return status;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }

        public static int GetCount()
        {
            return count;
        }
        public static void SetCount(int count){
            Booking.count = count;
        }

        public static void IncCount()
        {
            count++;
        }

        public string ToFile()
        {
            return $"{bookingID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{status}";
        }
    }
}