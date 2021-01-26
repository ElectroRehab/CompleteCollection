/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package plantarraylistexample;

import java.util.Scanner;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class PlantArrayListExample {

    // TODO: Define a PrintArrayList method that prints an ArrayList of plant (or flower) objects                                                       
    static void PrintArrayList(ArrayList<Plant> myGarden){
        for (int i = 0; i < myGarden.size(); i++){
            myGarden.get(i).printInfo();
            System.out.println();
        }
    }
    public static void main(String[] args) {
        Scanner scnr = new Scanner(System.in);
        String input;
        // TODO: Declare an ArrayList called myGarden that can hold object of type plant
        // TODO: Declare variables - plantName, plantCost, colorOfFlowers, isAnnual
        ArrayList<Plant> myGarden = new ArrayList<>();
        String plantName, plantCost, colorOfFlowers;
        boolean isAnnual;
        
        input = scnr.next();
        while(!input.equals("-1")){
            // TODO: Check if input is a plant or flower
            //       Store as a plant object or flower object
            //       Add to the ArrayList myGarden
            plantName = scnr.next();
            plantCost = scnr.next();
            
            if(input.equals("plant")){
                Plant p = new Plant();
                p.setPlantName(plantName);
                p.setPlantCost(plantCost);
                myGarden.add(p);
            }
            else if(input.equals("flower")){
                Flower f = new Flower();
                f.setPlantName(plantName);
                f.setPlantCost(plantCost);
                isAnnual = scnr.nextBoolean();
                colorOfFlowers = scnr.next();
                f.setPlantType(isAnnual);
                f.setColorOfFlowers(colorOfFlowers);
                myGarden.add(f);
            }
            input = scnr.next();
        }
        // TODO: Call the method PrintArrayList to print myGarden
        PrintArrayList(myGarden);
    }
}
