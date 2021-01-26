/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package artworklabel;
import java.util.Scanner;
public class ArtworkLabel {
    public static void main(String[] args) {
      Scanner scnr = new Scanner(System.in);

      String userTitle, userArtistName;
      int yearCreated, userBirthYear, userDeathYear;

      userArtistName = scnr.nextLine();
      userBirthYear = scnr.nextInt();
      scnr.nextLine();
      userDeathYear = scnr.nextInt();
      scnr.nextLine();
      userTitle = scnr.nextLine();
      yearCreated = scnr.nextInt();

      Artist userArtist = new Artist(userArtistName, userBirthYear, 
              userDeathYear);

      Artwork newArtwork = new Artwork(userTitle, yearCreated, userArtist);

      newArtwork.printInfo();
   }
}