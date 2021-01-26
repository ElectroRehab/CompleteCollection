/*
Jon King
Brick Project 
23NOV20
Description:
    Java Brick Project:
        23NOV20 - Created Calculations & Font Formatting
        24NOV20 - Began implementing JOptionPane
        25NOV20 - Removal of Single Door Voids Finished
        30NOV20 - Removal of Double Doors, Mech Room Doors, & Elevators.
        06DEC20 - Fiished removal of Double Doors, Mech Room Doors, & Elevators.
                  Organized program.
        
*/
package brickproject_kingjon;

import java.awt.BorderLayout;
import java.awt.Font;
import java.awt.HeadlessException;
import java.text.DecimalFormat;
import javax.swing.ImageIcon;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.UIManager;
import javax.swing.plaf.ColorUIResource;

public class BrickProject_KingJon {
////////////////////////////////////////////////////////////////////////////////
///// Menu Selection Module
    public static void menu(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[]){
        double userSelect = 0;
        // Starting code for HTML formatting Strings within JOptionPane
        String sC = startStringTwo();
        // Ending code for HTML formatting Strings within JOptionPane
        String eC = endString();
        ////////// Create Labels for formatting of menu
        ImageIcon image = new ImageIcon("src/pics/Title2.png");
        // Create JLabel Object pic to use current image.
        JLabel title = new JLabel(image);
////////// Create Panel Layouts and placements of picture/text Labels 
////////// from most recent user inputs
        JPanel panel = new JPanel();
        panel.setLayout(new BorderLayout());
        // Create JLabel Object info to show current user input's on new lines
        String results = readBackResults(measureAllBricks, totalCount, 
                userSelect, checkUp, removeSpace);
        JLabel info = new JLabel(results);
        // Format font displayed in JOptionPane for user inputs
        info.setFont(new Font("VERDANA", Font.BOLD, 20));
        info.setHorizontalAlignment(JLabel.LEFT);
////////// Create Panel Layouts and placements of picture/text Labels 
////////// from most recent user inputs
        panel.setLayout(new BorderLayout());        
        panel.add(info,BorderLayout.EAST);
        panel.add(title,BorderLayout.WEST);
        // String array for the selections formatted into JOptionPane buttons.
        String selectionOptions[] = {sC+"Length"+eC, sC+"Height"+eC, 
            sC+"Reset"+eC, sC+"Remove Voids"+eC, sC+"Custom Additions"+eC, 
            sC+"Quit"+eC};
        // JOptionPane to display initial user inputs.
        int answer = JOptionPane.showOptionDialog(null, panel, "", 
                JOptionPane.PLAIN_MESSAGE, 3, null, selectionOptions, 
                selectionOptions[3]);
        if (answer == 0){
            // User entering the dimensions of the facility in question.
            userSelect = input(answer, totalCount);
            // Calculations for all designs sections of the walls.
            totalCount[0] = baseBrickCount(measureAllBricks, userSelect);
            totalCount[1] = midBrickCount(measureAllBricks, userSelect);
            totalCount[2] = keyStoneCount(measureAllBricks, userSelect);
            totalCount[3] = topSideCount(measureAllBricks, userSelect);
            // Calculate the totals of all inputed information to give a count
            // of how many bricks will be required for a single story facility.
            for (int i = 0; i < 4; i++){
                totalCount[4] = totalCount[i] + totalCount[4];
            }
            // Calculate the number of stories by each individual floor by the 
            // current design of the walls. 
            totalCount[6] = totalCount[4] * totalCount[5];
            // Ensure that the user has inputted all information neccesarry to 
            // continue in the process.
            checkUp[0] = userSelect;
        }
        // Else IF Statement for the user to enter how many total stories will 
        // be required for the project.
        else if (answer == 1){
            // Call the method of input to show how many floor(s) the user would
            // like to add to their project.
            userSelect = input(answer, totalCount);
            // Ensure the user has inputted proper information to conintue on
            // with using the program.
            checkUp[1] = 1;
            // How many floors the user wants.
            totalCount[5] = userSelect;
            // Calculations for the total number of bricks with the stories.
            totalCount[6] = totalCount[4] * totalCount[5];
        }
        // Reset all previously input user info and restart the program.
        else if (answer == 2){
            // Reset Check-Up variables to ensure proper looping of the program.
            checkUp[0] = 0;
            checkUp[1] = 0;
            // For Loop to reset all variables inside the brick count array.
            for(int i = 0; i < totalCount.length; i++){
                totalCount[i] = 0;
            }
        }
        // Else If Statement to ensure that the user can continue on the program
        // and begin or continue to remove voids.
        else if (answer == 3){            
            checkUpInfo(measureAllBricks, totalCount, checkUp, userSelect,
                removeSpace);
        }
        else if (answer == 4){
            // 
            double customCount[] = new double[8];
            // User entering the dimensions of the facility in question.
            userSelect = input(answer + 2, totalCount);
            // Calculations for all designs sections of the walls.
            customCount[0] = baseBrickCount(measureAllBricks, userSelect);
            customCount[1] = midBrickCount(measureAllBricks, userSelect);
            customCount[2] = keyStoneCount(measureAllBricks, userSelect);
            customCount[3] = topSideCount(measureAllBricks, userSelect);
            // Calculate the totals of all inputed information to give a count
            // of how many bricks will be required for a single story facility.
            for (int i = 0; i < 4; i++){
                totalCount[4] = customCount[i] + totalCount[4];
            }
            for (int j = 0; j < 4; j ++){
                totalCount[j] = customCount[j] + totalCount[j];
            }
            // Calculate the number of stories by each individual floor by the 
            // current design of the walls. 
            totalCount[6] = totalCount[4] * totalCount[5];
            // Ensure that the user has inputted all information neccesarry to 
            // continue in the process.
            checkUp[0] = userSelect;
        }
        // Else Statement to end the program safelt
        else{
            endProg();
        }
        // Check to see if all info has been inputed to continue onto the void
        // brick removals.
        checkUpInfo(measureAllBricks, totalCount, checkUp, userSelect,
                removeSpace);
        
    }
////// Resuable input section for user
    public static double input(int userSelect, double totalCount[]){
        // Initiate variable to be returned
        double answer = 0;
        // Create image to be diplayed in option window
        ImageIcon image = null;
        ImageIcon imageTwo = null;
        // If Statement to show length as the image and input the information 
        // to determine proper calculations
        if (userSelect == 0){
            // Wall One and Wall Two images to guide the user through the 
            // process.
            image = new ImageIcon("src/pics/Length3.png");
            imageTwo = new ImageIcon("src/pics/Length4.png");
            // Try statement to make sure the user inputs the proper info 
            // without crashing the program due to erroneous inputs.
            try{
                // First Wall input
                String userInput = JOptionPane.showInputDialog(null, image);
                double firstWall = Double.valueOf(userInput);      
                // Turn feet into inches to ensure more accurate calcs.
                firstWall = firstWall * 12;
                // Second Wall Input
                String userInput2 = JOptionPane.showInputDialog(null, imageTwo);
                double secondWall = Double.valueOf(userInput2);      
                // Turn feet into inches to ensure more accurate calcs.
                secondWall = secondWall * 12;
                // Calculate the dimensions of the entire program requirements.
                answer = (firstWall * 2) + (secondWall * 2);            
            }
            // Catch the bad selections and call the Try Again method.
            catch(HeadlessException | NumberFormatException e){
                tryAgain(totalCount);
            }
            // Return user inputs
            return answer;
        }
        // Else If Statement to show height input as the image
        else if (userSelect == 1){
            image = new ImageIcon("src/pics/Height3.png");
        }
        // Else If Statement to show single door input as the image
        else if (userSelect == 2){
            image = new ImageIcon("src/pics/SingleDoor.png");
        }
        // Else If Statement to show double door input as the image
        else if (userSelect == 3){
            image = new ImageIcon("src/pics/DoubleDoors.png");
        }
        // Else If Statement to show elevator input as the image
        else if (userSelect == 4){
            image = new ImageIcon("src/pics/Elevator.png");
        }
        // Else If Statement to show mech room input as the image
        else if (userSelect == 5){
            image = new ImageIcon("src/pics/MechRoom.png");
        }
        //
        else if (userSelect == 6) {
            image = new ImageIcon("src/pics/CustomLength.png");
            try{
                // First Wall input
                String userInput = JOptionPane.showInputDialog(null, image);
                double customWall = Double.valueOf(userInput);      
                // Turn feet into inches to ensure more accurate calcs.
                customWall = customWall * 12;
                // Calculate the dimensions of the entire program requirements.
                answer = customWall;        
            }
            // Catch the bad selections and call the Try Again method.
            catch(HeadlessException | NumberFormatException e){
                tryAgain(totalCount);
            }
            // Return user inputs
            return answer;
        }
        // Else If Statement to show double door input as the image
        else if (userSelect == 7){
            image = new ImageIcon("src/pics/WindowVoidOne.png");
        }
        // Else If Statement to show elevator input as the image
        else if (userSelect == 8){
            image = new ImageIcon("src/pics/SingleDoorWindow.png");
        }
        // Else If Statement to show mech room input as the image
        else if (userSelect == 9){
            image = new ImageIcon("src/pics/LargeWindow.png");
        }
        // Else If Statement to show mech room input as the image
        else if (userSelect == 10){
            image = new ImageIcon("src/pics/MediumWindows.png");
        }
        // Else If Statement to show mech room input as the image
        else if (userSelect == 11){
            image = new ImageIcon("src/pics/CustomerService.png");
        }
        // Try to parse string from user input into a double variable to 
        // be returned
        try{
            String userInput = JOptionPane.showInputDialog(null, image);
            answer = Double.valueOf(userInput);            
        }
        // Catch the bad selections and call the Try Again method.
        catch(HeadlessException | NumberFormatException e){
            tryAgain(totalCount);
        }
        // Return user inputs
        return answer;
    }
////// Display what the calcuations should be after user completes inputs.    
    public static void addLength(double measureAllBricks[][], 
            double totalCount[], double userSelect, double checkUp[], 
            double removeSpace[]){
        // Ensure that user's total calculations get add together. 
        for (int i = 0; i < 4; i++){
            totalCount[4] = (totalCount[i] * totalCount[5]) + totalCount[4];
        }
        // Call Module to be displayed in each JOptionPane in the form of 
        // HTML Frames.
        readBackResults(measureAllBricks, totalCount, userSelect, checkUp,
                removeSpace);
        // Continue to on with program to remove the spaces.
        removeSpaceMod(measureAllBricks, totalCount, userSelect, checkUp,
                removeSpace);
    }
////// Removal of voids by user section.
    public static void removeSpaceMod(double measureAllBricks[][], 
            double totalCount[], double userSelect, double checkUp[], 
            double removeSpace[]){
        // Initiate variable to be used in the selection process in the 
        // removal of voids.
        userSelect = 0;
        // Initial the total number of bricks to be passed back.
        double bricksRemoved = 0;
        // Starting code for HTML formatting Strings within JOptionPane
        String sC = startString();
        // Ending code for HTML formatting Strings within JOptionPane
        String eC = endString();
        ////////// Create Labels for formatting of menu
        ImageIcon image = new ImageIcon("src/pics/VoidChoices2.png");
        // Create JLabel Object pic to use current image.
        JLabel title = new JLabel(image);
        String results = readBackResults(measureAllBricks, totalCount,
                userSelect, checkUp, removeSpace);
        JLabel info = new JLabel(results);
        // Format font displayed in JOptionPane for user inputs
        info.setFont(new Font("VERDANA", Font.BOLD, 20));
        info.setHorizontalAlignment(JLabel.CENTER);
////////// Create Panel Layouts and placements of picture/text Labels 
////////// from most recent user inputs
        JPanel panel = new JPanel();
        panel.setLayout(new BorderLayout());
        panel.add(title,BorderLayout.WEST);
        panel.add(info,BorderLayout.EAST);
        // String array for the selections formatted into JOptionPane buttons.
        String selectionOptions[] = {sC+"Single Door"+eC, sC+"Double Doors"+eC, 
            sC+"Elevator"+eC, sC+"Mech Room"+eC, sC+"Page 2"+eC, 
            sC+"Main Menu"+eC};
        // JOptionPane to display initial user inputs.
        int answer = JOptionPane.showOptionDialog(null, panel, "", 
                JOptionPane.PLAIN_MESSAGE, 3, null, selectionOptions, 
                selectionOptions[3]);
        // If statement to start the calculation of Single Door Removals.
        if (answer == 0){
            // Total Number of Single Doors to remove
            userSelect = input(answer+2, totalCount);
            // Total brick calculation removal
            bricksRemoved = singleDoorSpace(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
        }
        // Else If statement to start the calculation of Double Door Removals.
        else if (answer == 1){
            // Total Number of Double Doors to remove
            userSelect = input(answer+2, totalCount);
            // Total brick calculation removal
            bricksRemoved = doubleDoorSpace(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            // No negatives allowed
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            
        }
        else if (answer == 2){
            // Total Number of Elevators to remove
            userSelect = input(answer+2, totalCount);
            // Total brick calculation removal
            bricksRemoved = elevatorSpace(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
        }
        else if (answer == 3){
            // Total Number of Single Doors to remove
            userSelect = input(answer+2, totalCount);
            // Total brick calculation removal
            bricksRemoved = mechRoomSpace(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            // Display all of the bricks in the Array 'totalCount'
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
        }
        else if (answer == 4){
            removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                    checkUp, removeSpace);
        }        
        
        else{
            menu(measureAllBricks, totalCount, checkUp, removeSpace);
        }
    }
    ////// Removal of voids by user section.
    public static void removeSpacePageTwo(double measureAllBricks[][], 
            double totalCount[], double userSelect, double checkUp[], 
            double removeSpace[]){
        // Initiate variable to be used in the selection process in the 
        // removal of voids.
        userSelect = 0;
        // Initial the total number of bricks to be passed back.
        double bricksRemoved = 0;
        // Starting code for HTML formatting Strings within JOptionPane
        String sC = startCenterString();
        // Ending code for HTML formatting Strings within JOptionPane
        String eC = endString();
        ////////// Create Labels for formatting of menu
        ImageIcon image = new ImageIcon("src/pics/VoidChoices2.png");
        // Create JLabel Object pic to use current image.
        JLabel title = new JLabel(image);
        String results = readBackResults(measureAllBricks, totalCount,
                userSelect, checkUp, removeSpace);
        JLabel info = new JLabel(results);
        // Format font displayed in JOptionPane for user inputs
        info.setFont(new Font("VERDANA", Font.BOLD, 20));
        info.setHorizontalAlignment(JLabel.CENTER);
////////// Create Panel Layouts and placements of picture/text Labels 
////////// from most recent user inputs
        JPanel panel = new JPanel();
        panel.setLayout(new BorderLayout());
        panel.add(title,BorderLayout.WEST);
        panel.add(info,BorderLayout.EAST);
        // String array for the selections formatted into JOptionPane buttons.
        String selectionOptions[] = {sC+"Window Display"+eC, 
            sC+"Single Doors<br>With Windows"+eC, 
            sC+"Large Window"+eC, sC+"Medium Windows"+eC, 
            sC+"Customer<br>Service"+eC, sC+"Page 1"+eC};
        // JOptionPane to display initial user inputs.
        int answer = JOptionPane.showOptionDialog(null, panel, "", 
                JOptionPane.PLAIN_MESSAGE, 3, null, selectionOptions, 
                selectionOptions[3]);
        // If statement to start the calculation of Single Door Removals.
        if (answer == 0){
            // Total Number of Window Displays to remove
            userSelect = input(answer+7, totalCount);
            // Total brick calculation removal
            bricksRemoved = windowDisplaySpace(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
        }
        // Else If statement to start the calculation of Double Door Removals.
        else if (answer == 1){
            // Total Number of Double Doors to remove
            userSelect = input(answer+7, totalCount);
            // Total brick calculation removal
            bricksRemoved = singleDoorWindow(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            // No negatives allowed
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            
        }
        else if (answer == 2){
            // Total Number of Elevators to remove
            userSelect = input(answer+7, totalCount);
            // Total brick calculation removal
            bricksRemoved = upperFloorWindow(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
        }
        else if (answer == 3){
            // Total Number of Single Doors to remove
            userSelect = input(answer+7, totalCount);
            // Total brick calculation removal
            bricksRemoved = mediumWindow(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            // Display all of the bricks in the Array 'totalCount'
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
        }
        else if (answer == 4){
            // Total Number of Single Doors to remove
            userSelect = input(answer+7, totalCount);
            // Total brick calculation removal
            bricksRemoved = customerService(measureAllBricks, totalCount, 
                    checkUp, removeSpace, (int) userSelect);
            // Total bricks required for the project after single door 
            // bricks have been removed.
            totalCount[6] = (totalCount[6]) - bricksRemoved;
            // Display all of the bricks in the Array 'totalCount'
            if (totalCount[6] < 0){
                // Display error message
                tryAgain(totalCount);
                // Reset last user input
                totalCount[6] = (totalCount[6]) + bricksRemoved;
                // return to remove spaces for doors and windows.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                // Display all of the bricks in the Array 'totalCount'
                readBackResults(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
                // Return to beggining of the module to see if the user needs 
                // to remove anymore bricks for other voids in the facility.
                removeSpacePageTwo(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
        }
        else if (answer == 5){
            removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
        }        
        
        else{
            removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
        }
    }
////// Lowest Level of bricks in the current design
    public static double baseBrickCount(double measureAllBricks[][],
            double userInput){
        // Create removal from total distance
        double subtractGrout = (measureAllBricks[1][0]) * userInput;
        // Brick and grout combined lengths
        double totalSpace = (measureAllBricks[0][0] + measureAllBricks[1][0]);
        // Brick Count after removing grout 
        double brickCount = (userInput - subtractGrout) / totalSpace;
        return brickCount;
    }
////// Mid-Level of bricks in the current design
    public static double midBrickCount(double measureAllBricks[][],
            double userInput){
        // Create removal from total distance
        double subtractGrout = (measureAllBricks[1][0]) * userInput;
        // Brick length multiplied by user input
        double answer = measureAllBricks[0][2] * userInput;
         // Brick and grout combined lengths
        double totalSpace = (measureAllBricks[0][2] + measureAllBricks[1][0]);
        // Brick Count after removing grout 
        double singleRow = (userInput - subtractGrout) / totalSpace;
        // 30 Bricks High for Section of the Wall
        double brickCount = singleRow * 30;
        return brickCount;
    }
////// Key-Stone Level of bricks in the current design        
    public static double keyStoneCount(double measureAllBricks[][],
            double userInput){
        // Create removal from total distance
        double subtractGrout = (measureAllBricks[1][0]) * userInput;
        // Brick length multiplied by user input
        double answer = measureAllBricks[0][0] * userInput;
         // Brick and grout combined lengths
        double totalSpace = (measureAllBricks[0][0] + measureAllBricks[1][0]);
        // Brick Count after removing grout 
        double singleRow = (userInput - subtractGrout) / totalSpace;
        // 2 Bricks High for Section of the Wall
        double brickCount = singleRow * 2.5;
        return brickCount;
    }
////// Top-Level of bricks in the current design        
    public static double topSideCount(double measureAllBricks[][],
            double userInput){
        // Create removal from total distance
        double subtractGrout = (measureAllBricks[1][0]) * userInput;
        // Brick length multiplied by user input
        double answer = measureAllBricks[0][2] * userInput;
         // Brick and grout combined lengths
        double totalSpace = (measureAllBricks[0][2] + measureAllBricks[1][0]);
        // Brick Count after removing grout 
        double singleRow = (userInput - subtractGrout) / totalSpace;
        // Brick Count rows for final section of floor.
        double brickCount = (singleRow) * 21;
        return brickCount;
    }
    
    public static double calcAll(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
         // Brick and grout combined lengths
        double totalSpace = (measureAllBricks[0][2] + measureAllBricks[1][0]);
        // Create removal from total distance
        double subtractGroutWidth = (measureAllBricks[1][0]) * removeSpace[0];
        // Brick length multiplied by user input
        double answer = measureAllBricks[0][2] * removeSpace[0];
        // Brick Count after removing grout 
        double widthRemove = (answer - subtractGroutWidth) / totalSpace;
        // Create removal from total distance
        double subtractGroutHeight = (measureAllBricks[1][0]) * removeSpace[1];
        // Brick length multiplied by user input
        double answerTwo = measureAllBricks[0][2] * removeSpace[1];
        // Brick Count after removing grout 
        double HeightRemove = (answerTwo - subtractGroutHeight) / totalSpace;
        // Total Bricks to remove.
        double bricksBeforeStory = widthRemove + HeightRemove;
        // Number of doors to remove
        double bricksRemoved = bricksBeforeStory * userSelect;
        // Return Calculations
        return bricksRemoved;
    }
////// Create the spaces and brick removals
    public static double customerService(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Single Door base level removal
        removeSpace[0] = 77.875;
        // Single Door mid level removal
        removeSpace[1] = 88.5625; 
        // Calculate single door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
////// Create the spaces and brick removals
    public static double mediumWindow(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Single Door base level removal
        removeSpace[0] = 88.5;
        // Single Door mid level removal
        removeSpace[1] = 113.84375; 
        // Calculate single door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
////// Create the spaces and brick removals
    public static double windowDisplaySpace(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Single Door base level removal
        removeSpace[0] = 131.75;
        // Single Door mid level removal
        removeSpace[1] = 88.59375; 
        // Calculate single door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
////// Create the spaces and brick removals
    public static double singleDoorWindow(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Single Door base level removal
        removeSpace[0] = 43.96875;
        // Single Door mid level removal
        removeSpace[1] = 88.59375; 
        // Calculate single door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
////// Create the spaces and brick removals
    public static double singleDoorSpace(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Single Door base level removal
        removeSpace[0] = 64.25;
        // Single Door mid level removal
        removeSpace[1] = 88.59375; 
        // Calculate single door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
////// Create the spaces and brick removals
    public static double doubleDoorSpace(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Double Door base level removal
        removeSpace[0] = 76.09375;
        // Double Door mid level removal
        removeSpace[1] = 88.59375; 
        // Calculate double door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
////// Create the spaces and brick removals
    public static double elevatorSpace(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Double Door base level removal
        removeSpace[0] = 46;
        // Double Door mid level removal
        removeSpace[1] = 86; 
        // Calculate single door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
////// Create the spaces and brick removals
    public static double mechRoomSpace(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Double Door base level removal
        removeSpace[0] = 76.40625;
        // Double Door mid level removal
        removeSpace[1] = 88.59375;
        // Calculate single door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
    ////// Create the spaces and brick removals
    public static double upperFloorWindow(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double removeSpace[], 
            int userSelect){
        // Double Door base level removal
        removeSpace[0] = 185.375;
        // Double Door mid level removal
        removeSpace[1] = 113.84375; 
        // Calculate single door spaces
        double bricksRemoved = calcAll(measureAllBricks, totalCount, checkUp,
                removeSpace, userSelect);
        // Return Calculations
        return bricksRemoved;
    }
    ////// Bricks & Grout Measurements in the current design        
    public static void createBlocks(double measureAllBricks[][]){
        // Length of brick in inches
        measureAllBricks[0][0] = 2.25;
        // Width of brick in inches
        measureAllBricks[0][1] = 0.0;
        // Height of brick in inches
        measureAllBricks[0][2] = 7.6875;
        
        // Grout around brick in inches
        measureAllBricks[1][0] = 0.4375;
        // Width of brick in inches
        measureAllBricks[1][1] = 0.0;
        // Grout around brick in inches
        measureAllBricks[1][2] = 0.4375;
        
    }
    ///// Check to see if user has completed both Length and Stories to 
    ///// calculate
    public static void checkUpInfo(double measureAllBricks[][], 
            double totalCount[], double checkUp[], double userSelect, 
            double removeSpace[]){
        // If Statement to ensure that both the dimesions and stories have been
        // properly inputted. If one section is missing, program will loop back
        // to allow user to continue inputs on the amount of bricks required.
        if (checkUp[0] == 0 || checkUp[1] == 0){
            menu(measureAllBricks, totalCount, checkUp, removeSpace);
        }
        // Else Statement to all point the user to the removal of bricks section
        // of the program.
        else{
            // Ensure that the user has completed required fields prior to 
            // continuing with the program.
            if (totalCount[4] != 0){
                removeSpaceMod(measureAllBricks, totalCount, userSelect, 
                        checkUp, removeSpace);
            }
            else{
                addLength(measureAllBricks, totalCount, userSelect, checkUp,
                        removeSpace);
            }            
        }
    }
    ///////// HTML Code for current results of user's inputs and calculaltions 
    ///// displayed in frames for easier reading of answer. 
    public static String readBackResults(double measureAllBricks[][], 
            double totalCount[], double userSelect, double checkUp[], 
            double removeSpace[]){
        // Decimal Formatting
        DecimalFormat df = new DecimalFormat("#,###,###.####");
        double storyRound = Math.ceil(totalCount[6]);
        // Formatted Frames for displaying the results of the user's inputs 
        // on a constant basis in all JOPtionPanes.
        String userInfo = (
                "<html>" +
                "<body>" +
                "" +
                "<font size = 5>" +
                "<font color=#726d6d>"+
                "<em>"+
                "<strong>" +
                "<center>" +
                "<h2><font size = 20>Current Results</font></h2>" +
                "" +
                "<table border='1'"+
                "       align='left'>" +
                "  <tr>" +
                "    <th>Title</th>" +
                "    <th>CALC</th> " +
                "    <th>Brick Round</th>" +
                "  </tr>" +
                "  <tr>" +
                "    <td>Base Level</td>" +
                "    <td>" + df.format(totalCount[0]) + "</td>" +
                "    <td>" + df.format(Math.ceil(totalCount[0])) + "</td>" +
                "  </tr>" +
                "  <tr>" +
                "    <td>Mid Level</td>" +
                "    <td>" + df.format(totalCount[1]) + "</td>" +
                "    <td>" + df.format(Math.ceil(totalCount[1])) + "</td>" +
                "  </tr>" +
                "  <tr>" +
                "    <td>Keystone</td>" +
                "    <td>" + df.format(totalCount[2]) + "</td>" +
                "    <td>" + df.format(Math.ceil(totalCount[2])) + "</td>" +
                "  </tr>" +
                "  <tr>" +
                "    <td>Top Level</td>" +
                "    <td>" + df.format(totalCount[3]) + "</td>" +
                "    <td>" + df.format(Math.ceil(totalCount[3])) + "</td>" +
                "  </tr>" +
                "  <tr>" +
                "    <td>Total Story</td>" +
                "    <td>" + df.format(totalCount[4]) + "    </font></td>" +
                "    <td> " + df.format(Math.ceil(totalCount[4])) + "</td>" +
                "  </tr>" +
                "  <tr>" +
                "    <td>"+(int) totalCount[5]+" Story Facility</td>" +
                "    <td><font color=B94100>" + 
                                    df.format(totalCount[6]) + "</font></td>" +
                "    <td><font color=B94100>" + 
                                    df.format(storyRound)) + "</font></td>" +
                "  </tr>" +
                "  <tr>" +
                "    <td>        10% More</td>" +
                "    <td><font color=B94100>" + 
                                df.format(totalCount[6] * 1.1) + 
                                                        "</font></td>" +
                    "<td><font color=B94100>" + 
                                df.format(Math.ceil(storyRound * 1.1)) + 
                                                        "</font></td>" +
                "  </tr>" +
                "</table>" +
                "" +
                "</body></font></strong></em></center></html>";
        return userInfo;
    }
///////// HTML Code Button Formatting Header Smaller Letters
    public static String startStringTwo(){
        // Start the coding for JavaScript formatting within the JOptionPanes
        String startString = ("<html>"
                + "<font size = 6><font color=#726d6d><em><strong>"
                + "<font face='Garamond'>");
        return startString;
    }
///// HTML Code Button Formatting Header Larger Letters
    public static String startString(){
        // Start the coding for JavaScript formatting within the JOptionPanes
        String startString = ("<html><left>"
                + "<font size = 16><font color=#726d6d><em><strong>"
                + "<font face='Garamond'>");
        return startString;
    }
///// HTML Code Button Formatting Header Larger Letters
    public static String startCenterString(){
        // Start the coding for JavaScript formatting within the JOptionPanes
        String startString = ("<html><center>"
                + "<font size = 12><font color=#726d6d><em><strong>"
                + "<font face='Garamond'>");
        return startString;
    }
///// HTML Code Button Formatting Ending
    public static String endString(){
        // End the coding for JavaScript formatting within the JOptionPanes
        String endString = ("</br></font></strong></em></center></html>");
        return endString;
    }
    /////Error Reset
    public static void tryAgain(double totalCount[]){
        // Image of Try Again
        ImageIcon image = new ImageIcon("src/pics/TryAgain.png");
        if (totalCount[6] < 0){
            image = new ImageIcon("src/pics/TryAgainNeg.png");
        }
        // JOptionPane for the Error Message
        JOptionPane.showMessageDialog(null, image, "Display Image", 
                JOptionPane.PLAIN_MESSAGE);
    }
    ////// End the Program safely   
    public static void endProg(){
        ImageIcon image = new ImageIcon("src/pics/EndProg.png");
        // JOptionPane for the Error Message
        JOptionPane.showMessageDialog(null, image, "Display Image", 
                JOptionPane.PLAIN_MESSAGE);
        System.exit(0);
    }
////// Program Start    
    public static void main(String[] args) {
        // Format Each JOptionPane's Background to a blue/gray color
        UIManager.put("OptionPane.background", 
                new ColorUIResource(187, 209, 230));  
        // Format Each JOptionPane's MessageBox Background to a blue/gray color
        UIManager.put("OptionPane.messagebackground", 
                new ColorUIResource(187, 209, 230));
        // Format Each JOptionPane's Background to a blue/gray color
        UIManager.put("Panel.background", 
                new ColorUIResource(187, 209, 230));
        // Brick Measurements Array
        //      ROW[////L/W/H\\\\]      [////Type of Brick\\\\]COL
        double measureAllBricks [][]= new double [2][3];
        // Create Total Brick Count Calculation Collection Array
        double totalCount[] = new double[8];
        // Remove space array for the grout bedding
        double removeSpace[] = new double[12];
        // Check to see if the user has at least entered the length and width
        // prior to moving on to removing voids of doors and elevators
        double checkUp[] = new double [2];
        // Insert the dimensions of the each brick and the position of each to 
        // do multiple calculations throughout the program.
        createBlocks(measureAllBricks);
        // Go to the menu to start user inputs and other functions 
        // througout the brick counting project.
        menu(measureAllBricks, totalCount, checkUp, removeSpace);
    }
}