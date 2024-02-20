using System;
using System.Collections.Generic;
using System.IO;

namespace GPA131.ProjektUppgift.ToDoLista
{
    class Program
    {
        class Account // Klass för att hantera inloggningsuppgifter
        {
            public string userName;
            public string password;


            public Account(string userName1, string password1) //Konstruktor (klassens metod) som säger att vi vill ha inmatning och tilldelar sedan inmatningen till ovanstående klassfält.
            {
                userName = userName1;
                password = password1;
            }
        }
        
        static void Main(string[] args)
        {
                       
            Console.WriteLine("Välkommen till ToDo!\n\n1. Logga in\n2. Registrera dig" );
            int logIn= int.Parse(Console.ReadLine());
            List<Account> account = new List<Account>(); //Skapar en lista av typen "Account" klassen. Lagrar varje konto (objekt) från klassen.
            string inputUserName;
            string inputPassword;

            switch (logIn)
            {
                case 1:
                    Console.WriteLine("Ange användnamn");
                    inputUserName = Console.ReadLine();
                    Console.WriteLine("Ange lösenordet");
                    inputPassword = Console.ReadLine();
                    string[] accountArray = File.ReadAllLines("Account.txt"); //Områden där jag använt mig File.ReadAllLines har jag tagit insperation från ChatGPT.
                    
                    bool UserFound = UserExists(inputUserName, inputPassword, "Account.txt"); //Inparametrar från UserExists metoden.

                    if (UserFound == true)
                    {
                        Console.WriteLine("Inloggningen lyckades");

                    }
                    else
                    {
                        Console.WriteLine("Fel användarinmatning");
                        return; //Om användarinmatningen inte stämmer avslutas programmet. Den fortsätter inte i loopen.
                    }
                    break; 

                    


                case 2:
                    Console.WriteLine("Skapa ett användarnamn: ");
                    inputUserName = Console.ReadLine();

                    Console.WriteLine("Skapa ett lösenord");
                    inputPassword = Console.ReadLine();                  
                    Account NewAccount = new Account(inputUserName, inputPassword);
                    account.Add(NewAccount); //Lägger till nya objektet i "account" listan.                    
                   
                    //!!Inspererad av ChatGPT, "Steamwriter" var jag inte bekant med innan, men som jag försått är det ett sätt att skriva data till en textfil.
                    using(StreamWriter writer = new StreamWriter("Account.txt", true)) // Lägger till användaren i en textfil, "true" gör att den inte skriver över det som redan är sparat i textfilen.
                    {
                        writer.WriteLine(NewAccount.userName + " " + NewAccount.password); //Lägger till klassens variabel fält i textfilen + ett mellanrum för att förtydliga vad som är vad.
                    }
                    Console.WriteLine("\nRegistreringen lyckades!");

                    break;
            }

            static bool UserExists(string inputUsername1, string inputPassword1, string accountFileName) //Metod som kollar om användaren existerar i textfilen.
            {
                
                if (File.Exists(accountFileName))
                {
          
                    string[] accountArray = File.ReadAllLines("Account.txt"); 
                    foreach (var CheckAccountExists in accountArray) //Loopar igenom accountArrayen lika många gånger som det finns objekt i listan.
                    {
                        string[] AccountParts = CheckAccountExists.Split(); //!!Inspererad av ChatGPT, möjliggjör att särskilja på "användnamn" och "lösenord" Så att de ses som två separata delar.

                        if (AccountParts.Length == 2 && AccountParts[0] == inputUsername1 && AccountParts[1] == inputPassword1) //Kollar om arrayen är i två delar (Användarnamn & Lösenord). Sedan söker igenom om varje del i arrayen matchar användarens input av namn + lösen.
                        {
                            return true;
                        }
                    }
                }
                return false; // Om kontot i filen inte hittas, returnera false.
                
            } 

         

            int inputMenuChoice;           
            Console.WriteLine("\nMenyval\n");
            Console.WriteLine("1. Lägg till uppgift");
            Console.WriteLine("2. Visa nuvarande uppgifter");
            Console.WriteLine("3. Ta bort uppgift");
            inputMenuChoice = int.Parse(Console.ReadLine());

            // Anropar menyval metod
            MenuChoice(inputMenuChoice);            
        }

        // Metod som hanterar menyvalen
        static void MenuChoice(int inputMenuChoice1)
        {
            List<string> savedTasks = new List<string>();
            string inputTask = "";
            int inputPriority;

            if (inputMenuChoice1 == 1)
            {
                while(true)
                {
                    try
                    {
                        Console.WriteLine("\nEnter för + | \"Klar\" för att avsluta.  ");

                        Console.WriteLine("\nNy uppgift:");
                        inputTask = Console.ReadLine();

                        if (inputTask.ToLower() == "klar")
                        {
                            Console.WriteLine("Dina uppgifter har sparats.");
                            File.WriteAllLines("Uppgifter.txt", savedTasks);
                            break;
                        }

                        Console.WriteLine("Ange prioritet: (1 - 3)");
                        inputPriority = int.Parse(Console.ReadLine());

                        PriorityOfTasks(inputPriority); // Anropar metoden som hanterar prioritet

                        savedTasks.Add($"{inputPriority}. {inputTask}"); //Tilldelar listan "savedTasks" både prioritet värde och Uppgiften som användaren angett.

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Error!" + ex.Message); //Om användaren anger fel format i detta fall en sträng, så skickas ett felmeddelande. 
                    }
                }
                                            
                
            }
            else if (inputMenuChoice1 == 2)
            {
                int raknare = 0;

                Console.WriteLine("Dina uppgifter:\n");
                savedTasks = new List<string>(File.ReadAllLines("Uppgifter.txt")); //Skapar en ny lista och sparar inmatade uppgifter till textfil med namn "Uppgifter.txt".
                

                if (File.Exists("Uppgifter.txt")) // Kollar av om det finns en existerande textfil sparad med namn "Uppgifter.txt".
                {                   
                    foreach (var uppgifter in savedTasks)
                    {
                        raknare++; //Håller koll på numret av varje uppgift.
                        Console.WriteLine(raknare + ":" + " P" + uppgifter );
                    }
                }

               
            }
            else
            {
                savedTasks = new List<string>(File.ReadAllLines("Uppgifter.txt")); //Skapar en ny lista och sparar den informationen igen i en textfil.
                

                if (File.Exists("Uppgifter.txt")) //If sats som läser av om det finns några sparade uppgifter i programmet.
                {

                    Console.WriteLine("Dina uppgifter: \n");
                    savedTasks.Sort();
                    for (int i = 0; i < savedTasks.Count; i++)
                    {
                     
                        Console.WriteLine("Nr " + i + " P" + savedTasks[i]);
                    }

                    RemoveFinishedTask(savedTasks); // Anropar metoden för att ta bort avklarad uppgift.                    
                }
                
            }
        }

        static void RemoveFinishedTask(List<string> savedTasks)
        {
            while(true)
            {
                try
                {
                    int taskToRemove;
                    string wantToQuitProgram;
                                                          
                    while (true)
                    {
                        Console.WriteLine("\nAnge nummer för uppgift som du vill ta bort.");


                        if (int.TryParse(Console.ReadLine(), out taskToRemove) && taskToRemove < savedTasks.Count) /* TryParse förösker göra en typkonvertering.  out tilldelar koverteringen från tryParse till Uppgift att ta bort.
                                                                                                                              * Uppgift att ta bort förstår att det är en int.*/
                        {                           
                            savedTasks.RemoveAt(taskToRemove);

                            Console.WriteLine("Uppgift " + taskToRemove + " är bortaggen. " + "\n\n1. Tryck enter för att ta bort fler uppgifter" + "\n2. Ange \"klar\" för att avsluta");
                            File.WriteAllLines("Uppgifter.txt", savedTasks); //Uppdaterar textfilen efter att användaren tagit bort ett objekt i listan.
                            wantToQuitProgram = Console.ReadLine();

                            if (wantToQuitProgram.ToLower() == "klar")
                            {
                                Console.WriteLine("\nDina ändringar har sparats");
                                return;                               
                            }
                        }                   
                        else
                        {
                            throw new InvalidOperationException("Objektet finns inte med i listan"); //Kastar in exceptionen från catchen.
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
           
        }


        static int[] PriorityOfTasks(int inputPriority) //Metod som tar hand om prioriteten beronde på vad användaren anger när de lägger till en uppgift.
        {
            int[] PriorityArray = new int[3]; //Array av tre platser

            switch (inputPriority)
            {
                case 1:
                    inputPriority = PriorityArray[0]; // Prioritetsval 1 - 3, varje case motsvarar siffran 1 -3 när användaren väljer prioritet på uppgift.
                    break;

                case 2:
                    inputPriority = PriorityArray[1];
                    break;
                case 3:
                    inputPriority = PriorityArray[2];
                    break;
            }
            return PriorityArray;

        }
      


    }  




}


