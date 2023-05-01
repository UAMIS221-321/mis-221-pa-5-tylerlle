using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_tylerlle
{
    public class Trainer
    {
        private int trainerID; /*start at 1, make a max ID variable. 
        */
        private int maxTrainerID;
        private string name;
        private string mailAddress;
        private string email;
        static private int count;
        private bool isDeleted;

        //no arg and arg constructors to instantiate 
        public Trainer(){

        }

        public Trainer(int trainerID, string name, string mailAddress, string email){
            this.trainerID = trainerID;
            this.name = name;
            this.mailAddress = mailAddress;
            this.email = email;
        }

        public void SetTrainerID(){
            this.trainerID = count++;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetMailAddress(string mailAddress)
        {
            this.mailAddress = mailAddress;
        }

        public string GetMailAddress()
        {
            return mailAddress;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        static public void SetCount(int count){
            Trainer.count = count;
        }
        static public int GetCount(){
            return count;
        }
        static public void IncCount(){
            count++;
        }

        public void SetIsDeleted(bool isDeleted)
        {
            this.isDeleted = isDeleted;
        }

        public bool GetIsDeleted()
        {
            return isDeleted;
        }

        public string ToFile(){
            return $"{trainerID}#{name}#{mailAddress}#{email}#{isDeleted}";
        }
    }
}