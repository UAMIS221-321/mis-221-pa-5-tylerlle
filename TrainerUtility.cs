using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_tylerlle
{
    public class TrainerUtility
    {
        //no arg constructor to instantiate trainer object?
        private Trainer[] trainers;

        //arg constructor to instantiate trainer information
        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }

        public void GetAllTrainers()
        {
            //open
            StreamReader inFile = new StreamReader("trainers.txt");
            Trainer.SetCount(0);
            //process
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }

        public void AddTrainer()
        {
            System.Console.WriteLine("Enter the name of the trainer or stop to stop.");
            string userInput = Console.ReadLine();
            while (userInput.ToUpper() != "STOP")
            {
                Trainer myTrainer = new Trainer();
                myTrainer.SetName(userInput);

                System.Console.WriteLine("Enter the trainer's email address:");
                myTrainer.SetEmail(Console.ReadLine());

                System.Console.WriteLine("Enter the trainer's mailing address:");
                myTrainer.SetMailAddress(Console.ReadLine());

                trainers[Trainer.GetCount()] = myTrainer;
                myTrainer.SetTrainerID();
                Save();
                System.Console.WriteLine(myTrainer.GetTrainerID());
                System.Console.WriteLine("Enter the name of the trainer or stop to stop.");
                userInput = Console.ReadLine();
            }

        }

        public void Save()
        {
            //open file
            StreamWriter outFile = new StreamWriter("trainers.txt");
            //process file
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].ToFile());
            }
            //close file
            outFile.Close();
        }

        public int Find(int searchVal)
        {
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                if (trainers[i].GetTrainerID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }
        public void EditTrainer()
        {
            System.Console.WriteLine("Enter the Trainer's ID for whom you'd like to edit:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                System.Console.WriteLine("Enter the name of the trainer:");
                trainers[foundIndex].SetName(Console.ReadLine());

                System.Console.WriteLine("Enter the trainer's email address:");
                trainers[foundIndex].SetEmail(Console.ReadLine());

                System.Console.WriteLine("Enter the trainer's mailing address:");
                trainers[foundIndex].SetMailAddress(Console.ReadLine());

                Save();
            }
            else
            {
                System.Console.WriteLine("Trainer ID not found :(");
            }
        }

        public void DeleteTrainer() //how do you delete the ID and update everyone elses?
        {
            System.Console.WriteLine("Enter the Trainer's ID for whom you'd like to delete:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                System.Console.WriteLine($"Confirm that you would like to delete {trainers[foundIndex].GetName()}.\n1 to confirm\n2 to cancel");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        trainers[foundIndex].SetIsDeleted(true);
                        break;
                    case "2": break;
                    default:
                        System.Console.WriteLine("Trainer not found :(");
                        break;

                }

                Save();
            }
            else
            {
                System.Console.WriteLine("Trainer ID not found :(");
            }
        }
    }
}