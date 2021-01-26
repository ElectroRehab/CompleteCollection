/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package heartrateexcepthandling;
import java.util.Scanner;

public class HeartRateExceptHandling {
   public static void main(String[] args) {
      Scanner scnr = new Scanner(System.in);
      int userAge;             // A person's age
      int avgMaxHeartRate;     // Avg Max heart rate

      try {
         userAge = scnr.nextInt();

         // Throw exception if age is negative
         if (userAge < 0) {
            throw new Exception("Invalid age");
         }

         // Calculate avg max heart rate and print if no input error
         // Source: https://www.heart.org/en/healthy-living/fitness
         avgMaxHeartRate = 220 - userAge;

         System.out.println("Avg: " + avgMaxHeartRate);
      }
      catch (Exception excpt) {
         // Prints the error message passed by throw statement
         System.out.println(excpt.getMessage());
         System.out.println("Cannot compute");
      }

   }
}