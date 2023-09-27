// MIS 3033 002
// September 27, 2023
// Start at 10:30 AM, due time is 11:45 AM, closes at 11:50 AM
// Braden Fisher, 113492081

using a;
using Microsoft.EntityFrameworkCore;
using MIS3033_Exam1_BradenFisher.Migrations;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("MIS 3033 Exam 1");

string menuOpt = @"
********************************************************
1. Add a new patient
2. Show all patients
3. Search for one patient based on a given id
4. Delete one patient based on a given id
5. Show the average age of all patients
6. Show the patient information with lowest age
********************************************************
";
ExamDB db = new ExamDB();
Patient pat = new Patient();

while (true)
{
    Console.WriteLine(menuOpt);
    string userInput;
    Console.WriteLine("Please choose one option");
    userInput = Console.ReadLine();

    if (userInput == "1")
    {
        Console.WriteLine("Add a new patient");

        Console.WriteLine("ID: ");
        string id = Console.ReadLine();

        Console.WriteLine("Age: ");
        string age = Console.ReadLine();
        int ageInt = Convert.ToInt32(age);
        
        Patient p = new Patient() { PID = id, Age = ageInt};
        p.GetAgeLevel();
        db.patTbl.Add(p);
        db.SaveChanges();
        

        Console.WriteLine(p);
        
    }
    else if (userInput == "2")
    {
        Console.WriteLine("Show all patients");
        ExamDB dB = new ExamDB();

        List<Patient> patList = dB.patTbl.ToList();
        for (int i = 0; i < patList.Count; i++)
        {
            Console.WriteLine(patList[i]);
        }
    }
    else if (userInput == "3")
    {
        
        Console.WriteLine("Search for one patient based on given ID");
        Console.WriteLine("ID: ");
        string id = Console.ReadLine();
        Patient p = db.patTbl.Where(x => x.PID == id).FirstOrDefault();

        if (id == null)
        {
            Console.WriteLine($"Sorry, Patient ID: {p} does not exist");
        }
        else
        {
            Console.WriteLine(p);
        }

    }
    else if (userInput == "4")
    {
        
        Console.WriteLine("Delete patient based on given ID");
        Console.WriteLine("ID: ");
        string id = Console.ReadLine();
        Patient p = db.patTbl.Where(x => x.PID == id).FirstOrDefault();

        if (id == null)
        {
            Console.WriteLine($"Sorry, Patient ID: {id} does not exist");
        }
        else
        {
            db.patTbl.Remove(p);
            db.SaveChanges();
            Console.WriteLine("Patient has been deleted successfully");
        }
    }
    else if (userInput == "5")
    {
        Console.WriteLine("Show average age of all patients");

        double ageDBl = db.patTbl.Average(x => x.Age);
        Console.WriteLine($"{ageDBl:F2}");
    }
    else if (userInput == "6")
    {
        Console.WriteLine("Show the patient info with the lowest age");
        Patient p = db.patTbl.ToList().MinBy(x => x.Age);
        Console.WriteLine(p);
    }
    else
    {

        Console.WriteLine("Thank you and goodbye!");
        db.Dispose();
        break;
    }


}