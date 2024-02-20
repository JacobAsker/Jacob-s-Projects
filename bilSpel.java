import java.lang.invoke.SwitchPoint;
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        Car Volvo = new Car("XC60", 600000); //Volvo
        Car Tesla = new Car("model 3", 700000); // Tesla
        Car BMW = new Car("M5", 1500000); //BMW
                  
       System.out.println("Välj bil:\n\n1. Volvo\n\n2. Tesla\n\n3: BMW");
       Scanner s = new Scanner(System.in);
       int valjaBil = s.nextInt();
       
       switch(valjaBil){ // Menu to choose car and turn on

        case 1:
       
        Volvo.TurnOn();
        break;

        case 2:
       
        Tesla.TurnOn();
        break;

        case 3:
        BMW.TurnOn();
        break;

       }

       if(valjaBil == 1){ // Volvo direction of travel

        System.out.println("\n1: Kör framåt\n2: Backa"); 
        Scanner valjaRiktning = new Scanner(System.in);
        int fardRiktningVolvo = valjaRiktning.nextInt();

        if(fardRiktningVolvo== 1){

            Volvo.DriveForward();

            for(int i = 0; i < 10; i++){

                System.out.print("*->*\t");
            }
            


            
        }
        else{

            Volvo.Reverse();
            for(int i = 0; i < 10; i++){

                System.out.print("*<-*\t");
            }

        }

        System.out.println("\nTryck 0 för att stänga av"); 
       Scanner turnOff = new Scanner(System.in); 
       int input = turnOff.nextInt(); 

       if(input == 0){
        Volvo.TurnOff();

       }

        

               
       }
       else if(valjaBil == 2){ // Tesla direction of travel

        
        System.out.println("\n1: Kör framåt\n2: Backa"); 
        Scanner valjaRiktning = new Scanner(System.in);
        int fardRiktningTesla = valjaRiktning.nextInt();

        if(fardRiktningTesla == 1){

            Tesla.DriveForward();
            for(int i = 0; i < 10; i++){

                System.out.print("*->*\t");
            }
        }
        else{

            Tesla.Reverse();
            for(int i = 0; i < 10; i++){

                System.out.print("*<-*\t");
            }

        }

        System.out.println("Tryck 0 för att stänga av"); 
       Scanner turnOff = new Scanner(System.in); 
       int input = turnOff.nextInt(); 

       if(input == 0){
        Tesla.TurnOff();

       }


       }

       else if(valjaBil == 3){ // BMW direction of travel
        System.out.println("\n1: Kör framåt\n2: Backa"); 
        Scanner valjaRiktning = new Scanner(System.in);
        int fardRiktningBMW = valjaRiktning.nextInt();

        if(fardRiktningBMW == 1){

            BMW.DriveForward();
            for(int i = 0; i < 10; i++){

                System.out.print("*->*\t");
            }
        }
        else{
            BMW.Reverse();
            for(int i = 0; i < 10; i++){

                System.out.print("<*-*\t");
            }
        }

        System.out.println("Tryck 0 för att stänga av"); 
       Scanner turnOff = new Scanner(System.in); 
       int input = turnOff.nextInt(); 

       if(input == 0){
        BMW.TurnOff();

       }


       }
       

       

       


       

       
       
       






       


        


        

    }
}
