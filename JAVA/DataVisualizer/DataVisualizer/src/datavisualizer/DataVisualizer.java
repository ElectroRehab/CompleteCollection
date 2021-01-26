/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package datavisualizer;

import java.util.ArrayList;
import java.util.Scanner;

public class DataVisualizer {
    
    static void printInfo(String titleLine, String colOne, String colTwo,
            ArrayList<String> letterList, ArrayList<Integer> numList){
        System.out.printf("%33s\n", titleLine);
        System.out.printf("%-20s|%23s\n", colOne, colTwo);
        System.out.println("--------------------------------------------");
        for (int i = 0; i < letterList.size(); i++){
            System.out.printf("%-20s|%23d\n", letterList.get(i), 
                    numList.get(i));
        }
    }
    
    static void printHisto(ArrayList<String> letterList, 
            ArrayList<Integer> numList){
        for (int i = 0; i < letterList.size(); i++){
            System.out.printf("%20s ", letterList.get(i));
            for (int j = 0; j < numList.get(i); j++) {
                System.out.print("*");
            }
            System.out.println();
        }
    }
    
    static int countCommas(String letters){
        int comma = 0;
        for (Character characters : letters.toCharArray()){
            if (characters == ',') {
                comma++;
            }
        }
        return comma;
    }
    static boolean intOrNot(String ques){
        try {
            int nums = Integer.parseInt(ques.trim());
            return true;
        } 
        catch (Exception e) {
        }
        return false;
    }
//////START PROGRAM//////    
    public static void main(String[] args) {
        Scanner scnr = new Scanner(System.in);
        System.out.println("Enter a title for the data:");
        String titleLine = scnr.nextLine();
        System.out.println("You entered: " + titleLine + "\n");
        System.out.println("Enter the column 1 header:");
        String colOneHeader = scnr.nextLine();
        System.out.println("You entered: " + colOneHeader + "\n");
        System.out.println("Enter the column 2 header:");
        String colTwoHeader = scnr.nextLine();
        System.out.println("You entered: " + colTwoHeader);
        ArrayList<String> lettersList = new ArrayList<>();
        ArrayList<Integer> numList = new ArrayList<>();
        while (true) {
            System.out.println("\nEnter a data point (-1 to stop input):");
            String userInput = scnr.nextLine();
            if (userInput.equals("-1")) {
                break;
            }
            int commaCount = countCommas(userInput);
            
            if (commaCount == 0) {
                System.out.println("Error: No comma in string.");
            } 
            else if (commaCount > 1) {
                System.out.println("Error: Too many commas in input.");
            }
            else if (!intOrNot(userInput.substring(userInput.indexOf(",") 
                    + 1))){
                System.out.println("Error: Comma not followed by an integer.");
            }
            else {
                String letters = userInput.substring(
                        0, userInput.indexOf(",")).trim();
                int num = Integer.parseInt(userInput.substring(
                        userInput.indexOf(",") + 1).trim());
                lettersList.add(letters);
                numList.add(num);
                System.out.println("Data string: " + letters);
                System.out.println("Data integer: " + num);
            }
        }
       System.out.println("");
       printInfo(titleLine, colOneHeader, colTwoHeader, lettersList, numList);
       System.out.println("");
       printHisto(lettersList, numList);
    }
}