/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package petinformation;

import java.util.Scanner;

public class PetInformation {
    public static void main(String[] args) {
        Scanner scnr = new Scanner(System.in);
        
        Pet myPet = new Pet();
        Dog myDog = new Dog();
        
        String petName, dogName, dogBreed;
        int petAge, dogAge;
        
        petName = scnr.nextLine();
        petAge = scnr.nextInt();
        scnr.nextLine();
        dogName = scnr.next();
        dogAge = scnr.nextInt();
        scnr.nextLine();
        dogBreed = scnr.nextLine();
        
        // TODO: Create generic pet (using petName, petAge) and then call printInfo       
        myPet.setName(petName);
        myPet.setAge(petAge);
        myPet.printInfo();
        // TODO: Create dog pet (using dogName, dogAge, dogBreed) and then call printInfo
        myDog.setName(dogName);
        myDog.setAge(dogAge);
        myDog.setBreed(dogBreed);
        myDog.printInfo();
        // TODO: Use getBreed(), to output the breed of the dog
        String breedSpace = "   Breed: ";
        System.out.println(breedSpace + myDog.getBreed());      
    }
}
