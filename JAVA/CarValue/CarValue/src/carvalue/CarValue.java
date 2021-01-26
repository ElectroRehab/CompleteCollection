/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package carvalue;
import java.util.Scanner;
import java.lang.Math;
public class CarValue {
    public static void main(String[] args) {
        Scanner scnr = new Scanner(System.in);
        
        Car myCar = new Car();
        
        int userYear = scnr.nextInt();
        int userPrice = scnr.nextInt();
        int userCurrentYear = scnr.nextInt();
        
        myCar.setModelYear(userYear);
        myCar.setPurchasePrice(userPrice);
        myCar.calcCurrentValue(userCurrentYear);
        
        myCar.printInfo();
   }
}