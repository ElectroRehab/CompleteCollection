/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.util.Scanner;
public class NutritionalInformation {
    public static void main(String[] args) {
      Scanner scnr = new Scanner(System.in);
      
      FoodItem foodItem1 = new FoodItem();
      
      String itemName = scnr.next();
      double amountFat = scnr.nextDouble();
      double amountCarbs = scnr.nextDouble();
      double amountProtein = scnr.nextDouble();
      
      FoodItem foodItem2 = new FoodItem(itemName, amountFat, amountCarbs, 
              amountProtein);
      
      double numServings = scnr.nextDouble();
      
      foodItem1.printInfo();
      System.out.printf("Number of calories for %.2f serving(s): %.2f\n", 
              numServings, foodItem1.getCalories(numServings));
                           
      System.out.println("\n");
                           
      foodItem2.printInfo();
      System.out.printf("Number of calories for %.2f serving(s): %.2f\n", 
              numServings, foodItem2.getCalories(numServings));
   }
}