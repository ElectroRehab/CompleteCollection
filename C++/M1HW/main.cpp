/*

M1HW - Rock Paper Scissors

This assignment should serve as a quick warmup, and a reminder that even a
simple set of requirements can get complicated.

At times, I will pull from computer games of the 70s and 80s, especially
text based games, for ideas for simple assignments and projects. As well
as giving an interesting look back at the programming scene of that era,
these are often just complicated enough to be a bit more challenging than
you might expect.

In other words: If someone says "Hey, write a Rock, Paper, Scissors program",
you might say "Sure, that'd take like five minutes." It's probably going to
take you longer than that to do it right.

Instructions and Grading

Bronze Tier (max 80/100):
Write a program that will play a single round of "Rock, Paper, Scissors"
against a human player.

The user should make a selection (this could be by typing, say, "rock", or
by choosing from a numbered menu).

The program should make a selection at random (searching Zybooks should
point you to the relevant section from CSC134 that explains random number
generation).

Based on the player and computer choices, a winner (or a tie) is announced.
As a reminder: Rock breaks scissors, scissors cut paper, paper covers rock.

Silver Tier (max 90/100):
As Bronze, but the program should play a best of five series of RPS, and
then announce the winner of the series. It should then ask the user if they
want to play again.

Gold Tier (max 100/100):
As Silver, but the program should instead play "Rock, Paper, Scissors,
Lizard, Spock". This variant is attributed to Sam Kass and Karen Bryla.

I apologize in advance for the fact that a search for "Rock, Paper, Scissors,
Lizard, Spock" is probably going to point you to a Big Bang Theory clip.
(I only found this out after creating the assignment. I've seen maybe 10
 seconds total of that show.)

Useful links for RPSLS: https://dodona.ugent.be/en/activities/1647887074/#
and http://www.samkass.com/theories/RPSSL.html

To quote:
The rules of rock-paper-scissors-lizard-Spock are:

scissors cut paper
paper covers rock
rock crushes lizard
lizard poisons Spock
spock smashes scissors
scissors decapitate lizard
lizard eats paper
paper disproves Spock
Spock vaporizes rock
rock crushes scissors

Completing the Assignment

Upload your source code and a screenshot of a sample run to Blackboard.
Description shown above.^^^
M1HW - Rock Paper Scissors
Jon King
20AUG20
*/
// Import Section
#include <iostream>
#include <cstdlib>
using namespace std;
// Display Redo Question
int playAgain(){
    cout << "|-------------------------------|\n";
    cout << "|  Do you want to play again?!  |\n";
    cout << "|-------------------------------|\n";
    cout << "| Enter 1 -                     |\n";
    cout << "|     Yes, I want to play again |\n";
    cout << "|-------------------------------|\n";
    cout << "| Anything Other Key -          |\n";
    cout << "|         No, I am a quitter... |\n";
    cout << "|-------------------------------|\n";
}
// Display Ending
int ending(){
    cout << "-------------------------------------" << endl;
    cout << "|THANK YOU FOR USING THIS PROGRAM!!!|" << endl;
    cout << "-------------------------------------" << endl;
}
// Display the Menu Options
int menu(){
    cout << "-------------------------------------" << endl;
    cout << "| PLEASE ENTER ONE OF THE FOLLOWING |" << endl;
    cout << "-------------------------------------" << endl;
    cout << "| 1 = ROCK                          |" << endl;
    cout << "| 2 = PAPER                         |" << endl;
    cout << "| 3 = SCISSORS                      |" << endl;
    cout << "| 4 = LIZARD                        |" << endl;
    cout << "| 5 = SPOCK                         |" << endl;
    cout << "-------------------------------------" << endl;
}
// Main Module
int main(){
    //Declare Counting Variables
    int soulLessCount = 0;
    int mortalCount = 0;
    int gameCount = 0;
    int reDo = 0;
    gameCount;
    // Intro of program
    cout << "---------------------------" << endl;
    cout << "|       LET'S PLAY        |" << endl;
    cout << "---------------------------" << endl;
    cout << "| ROCK - PAPER - SCISSORS |" << endl;
    cout << "|     LIZARD - SPOCK      |" << endl;
    cout << "---------------------------" << endl;
    // While loop used to ensure 5 games are played or first to 3.
    while (gameCount < 5 || soulLessCount == 3 || mortalCount == 3){
        // Start count for each game.
        gameCount++;
        /* Computer Random Choices:
        1 = Rock
        2 = Paper
        3 = Scissors
        4 = Lizard
        5 = Spock
        */
        // Computer random pick from 1 - 5.
        int stupidComp = rand() % 5 + 1;
        // User Input Question Display.
        menu();
        // Variable smartUser used to represent choice of player 1.
        int smartUser;
        // Enter number to represent the choice from menu.
        cout << " ENTER HERE:";
        cin >> smartUser;
        // While loop to ensure user inputs proper number for results.
        while (smartUser < 1 || smartUser > 5){
            cout << "\n--------------------------------\n";
            cout << "| You Entered an invalid key!!!|\n";
            cout << "|           Try Again!!!       |\n";
            cout << "--------------------------------\n\n";
            cout << " ENTER HERE:";
            cin >> smartUser;
            break;
        }
        // If statement to represent User throwing Rock and Computer
        // throwing Scissors or Lizard.
        if ((smartUser == 1 && stupidComp == 3) ||
            (smartUser == 1 && stupidComp == 4)){
                if (stupidComp == 3){
                    cout << "\n---------------------------------------\n";
                    cout << "| You CRUSHED that pair of scissors!!!|\n";
                    cout << "---------------------------------------\n";
                }
                else{
                    cout << "\n----------------------------\n";
                    cout << "|You CRUSHED that lizard!!!|\n";
                    cout << "----------------------------\n\n";
                }
                // Add 1 to player 1's win variable.
                mortalCount++;
        }
        // Else If statement to represent User throwing Paper and Computer
        // throwing Rock or Spock.
        else if((smartUser == 2 && stupidComp == 1) ||
            (smartUser == 2 && stupidComp == 5)){
                if (stupidComp == 1){
                    cout << "|\n--------------------------------|\n";
                    cout << "| You COVERED that rock, champ!!!|\n";
                    cout << "|--------------------------------|\n\n";
                }
                else{
                    cout << "|\n-----------------------------|\n";
                    cout << "|Your paper disproves Spock!!!|\n";
                    cout << "|-----------------------------|\n\n";
                }
                // Add 1 to player 1's win variable.
                mortalCount++;
        }
        // Else If statement to represent User throwing Scissors and Computer
        // throwing Paper or Lizard.
        else if((smartUser == 3 && stupidComp == 2) ||
            (smartUser == 3 && stupidComp == 4)){
                if (stupidComp == 2){
                    cout << "|\n---------------------------------|\n";
                    cout << "| You CUT that paper...surprise!!!|\n";
                    cout << "|---------------------------------|\n\n";
                }
                else{
                    cout << "|\n-----------------------------|\n";
                    cout << "| You decapitate the liz...?! |\n";
                    cout << "|YOU DECAPITATED THE LIZARD!!!|\n";
                    cout << "|-----------------------------|\n\n";
                }
                // Add 1 to player 1's win variable.
                mortalCount++;
        }
        // Else If statement to represent User throwing Lizard and Computer
        // throwing Spock or Paper.
        else if((smartUser == 4 && stupidComp == 5) ||
            (smartUser == 4 && stupidComp == 2)){
                if (stupidComp == 5){
                    cout << "|\n-----------------------------|\n";
                    cout << "|Your lizard POISONED Spock!!!|\n";
                    cout << "|-----------------------------|\n\n";
                }
                else{
                    cout << "|\n------------------------------------|\n";
                    cout << "|Your lizard ate some paper... weird.|\n";
                    cout << "|------------------------------------|\n\n";
                }
                // Add 1 to player 1's win variable.
                mortalCount++;
        }
        // Else If statement to represent User throwing Spock and Computer
        // throwing Scissors or Rock.
        else if((smartUser == 5 && stupidComp == 3) ||
            (smartUser == 5 && stupidComp == 1)){
                if (stupidComp == 3){
                    cout << "|\n-----------------------------------------|\n";
                    cout << "|Spock grabbed and SMASHED the scissors!!!|\n";
                    cout << "|-----------------------------------------|\n\n";
                }
                else{
                    cout << "|\n---------------------------|\n";
                    cout << "|Spock VAPORIZED the rock!!!|\n";
                    cout << "|---------------------------|\n\n";
                }
                // Add 1 to player 1's win variable.
                mortalCount++;
        }
        // If statement to represent Computer throwing Rock and User
        // throwing Scissors or Lizard.
        else if ((stupidComp == 1 && smartUser == 3) ||
            (stupidComp == 1 && smartUser == 4)){
                if (smartUser == 3){
                    cout << "|\n-------------------------------------|\n";
                    cout << "| Your pair of scissors got CRUSHED!!!|\n";
                    cout << "|-------------------------------------|\n\n";
                }
                else{
                    cout << "\n----------------------------\n";
                    cout << "|Your lizard got CRUSHED!!!|\n";
                    cout << "----------------------------\n\n";
                }
                // Add 1 to computer's win variable.
                soulLessCount++;
        }
        // Else If statement to represent Computer throwing Paper and User
        // throwing Rock or Spock.
        else if((stupidComp == 2 && smartUser == 1) ||
            (stupidComp == 2 && smartUser == 5)){
                if (smartUser == 1){
                    cout << "|\n---------------------------------------|\n";
                    cout << "| Your rock got COVERED... still a rock.|\n";
                    cout << "|---------------------------------------|\n\n";
                }
                else{
                    cout << "|\n-----------------------------|\n";
                    cout << "|Your paper disproves Spock!!!|\n";
                    cout << "|-----------------------------|\n\n";
                }
                // Add 1 to computer's win variable.
                soulLessCount++;
        }
        // Else If statement to represent Computer throwing Scissors and
        // User throwing Paper or Lizard.
        else if((stupidComp == 3 && smartUser == 2) ||
            (stupidComp == 3 && smartUser == 4)){
                if (smartUser == 2){
                    cout << "|\n---------------------------------|\n";
                    cout << "| Your paper was CUT...surprise!!!|\n";
                    cout << "|---------------------------------|\n\n";
                }
                else{
                    cout << "|\n------------------------------|\n";
                    cout << "|   Your lizard was dec...?!   |\n";
                    cout << "|YOUR LIZARD WAS DECAPITATED!!!|\n";
                    cout << "|------------------------------|\n\n";
                }
                // Add 1 to computer's win variable.
                soulLessCount++;
        }
        // Else If statement to represent Computer throwing Lizard and
        // User throwing Spock or Paper.
        else if((stupidComp == 4 && smartUser == 5) ||
            (stupidComp == 4 && smartUser == 2)){
                if (smartUser == 5){
                    cout << "|\n-------------------------------|\n";
                    cout << "|A lizard POISONED your Spock!!!|\n";
                    cout << "|-------------------------------|\n\n";
                }
                else{
                    cout << "|\n---------------------------------|\n";
                    cout << "|A lizard ate your paper... weird.|\n";
                    cout << "|---------------------------------|\n\n";
                }
                // Add 1 to computer's win variable.
                soulLessCount++;
        }
        // Else If statement to represent Computer throwing Spock and
        // User throwing Scissors or Rock.
        else if((stupidComp == 5 && smartUser == 3) ||
            (stupidComp == 5 && smartUser == 1)){
                if (smartUser == 3){
                    cout << "|\n----------------------------------------|\n";
                    cout << "|Spock grabbed & SMASHED your scissors!!!|\n";
                    cout << "|----------------------------------------|\n\n";
                }
                else{
                    cout << "|\n----------------------------|\n";
                    cout << "|Spock VAPORIZED your rock!!!|\n";
                    cout << "|----------------------------|\n\n";
                }
                // Add 1 to computer's win variable.
                soulLessCount++;
        }
        // Tied Choice
        else{
            cout << "\n|----------------------------|\n";
            cout << "|You tried and failed to beat|\n";
            cout << "|    the stupid computer.    |\n";
            cout << "|      ---MATCH TIED---      |\n";
            cout << "|----------------------------|\n\n";
        }
    }
    // If Statement to display user winning the game
    if (mortalCount > soulLessCount){
        cout << "\n|----------------------------|\n";
        cout << "|---------CONGRATS!!!--------|\n";
        cout << "|    You beat that stupid    |\n";
        cout << "| computer with your big ol' |\n";
        cout << "|          brain!!!          |\n";
        cout << "|---------CONGRATS!!!--------|\n";
        cout << "|----------------------------|\n\n";
        cout << "Your score was: " << mortalCount << "\n";
        cout << "Stupid Computer: " << soulLessCount << "\n";
        // Display whether or not to play again.
        playAgain();
        cout << "|Enter Here:";
        // User input with the variable name of reDo
        cin >> reDo;
        //Restart
        if (reDo == 1){
            main();
        }
        // End Game
        else{
            ending();
        }
    }
    // Else If Statement to display user lost the game
    else if (soulLessCount > mortalCount){
        cout << "\n|----------------------------|\n";
        cout << "|---------HAHAHAHA!!!--------|\n";
        cout << "|  You got beat by a stupid  |\n";
        cout << "| computer with your big ol' |\n";
        cout << "|          brain!!!          |\n";
        cout << "|---------HAHAHAHA!!!--------|\n";
        cout << "|----------------------------|\n\n";
        cout << "Your score was: " << mortalCount << endl;
        cout << "Stupid Computer: " << soulLessCount << endl;
        // Display whether or not to play again.
        playAgain();
        cout << "|Enter Here:";
        // User input with the variable name of reDo
        cin >> reDo;
        //Restart
        if (reDo == 1){
            main();
        }
        // End Game
        else{
            ending();
        }
    }
    // Else if Statement to display user tied the game
    else if(soulLessCount == mortalCount){
        cout << "\n|----------------------------|\n";
        cout << "|---------HAHAHAHA!!!--------|\n";
        cout << "|     You tied a stupid      |\n";
        cout << "| computer with your big ol' |\n";
        cout << "|          brain!!!          |\n";
        cout << "|---------HAHAHAHA!!!--------|\n";
        cout << "|----------------------------|\n\n";
        cout << "Your score was: " << mortalCount << endl;
        cout << "Stupid Computer: " << soulLessCount << endl;
        // Display whether or not to play again.
        playAgain();
        // User input to play or quit.
        cout << "|Enter Here:";
        // User input with the variable name of reDo
        cin >> reDo;
        //Restart
        if (reDo == 1){
            main();
        }
        // End Game
        else{
            ending();
        }
    }
    return 0;
}
