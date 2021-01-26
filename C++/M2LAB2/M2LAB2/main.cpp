// Jon King
// M2LAB2 -  Adventure Call (first iteration)
// 13SEP20
// Description Below:
// The idea here is pretty straightforward -- using functions, we'll create
// a simple interactive game where a user can make decisions. For example,
// maybe wander around a location, or answer questions.
//
// For your version, you should do the following:
// 1) a main() that kicks things off
// 2) 3-5 named functions involving actions or locations that the user can
//    take some end state (perhaps going to a certain location is a win or
//    loss state)
// 3) If you want to go old school, Zork can be an inspiration; something
//    like 9:05 or Photopia or Galatea is more of an "indie" type of
//    approach.
// 4) In any case, this assignment simply involves being able to enter
//    commands to visit each node of the story (as implemented by a
//    function).
// Header file imports
#include <string>
#include <iostream>
#include <vector>
using namespace std;
// Function prototype list.
void burgerJoint();
void deadCar();
void endGame();
void endGameBad();
void trunkCheck();
// User items that you can collect. Current state of no possessions.
bool dumbDevice = false;
bool hammer = false;
bool houseKey = false;
bool screwDriver = false;
bool startUp = true;
// Starting point... so to speak.
void deadCar(){
    // Intro to your terrible day adventure.
    cout << "|-----------------------------------------------------------|\n";
    cout << "|                       What a Day!                         |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|You find yourself snapping back into reality while driving.|\n";
    cout << "|'SH**!!!' you scream as you swerve back into your lane.    |\n";
    cout << "|                                                           |\n";
    cout << "|Although, you really don't know where you are going. It has|\n";
    cout << "|not been your day. Today you lost your job, your apartment,|\n";
    cout << "|and found out that your significant other has been cheating|\n";
    cout << "|on you. What a day!!!                                      |\n";
    cout << "|                                                           |\n";
    cout << "|You think to yourself, 'How could this get any worse?!'    |\n";
    cout << "|(Enter any key to see...)                                  |\n";
    cout << "|-----------------------------------------------------------|\n";
    // User input String
    string input;
    cin >> input;
    // For Loop to make user's input all lowercase
    for(int i=0; i<input.length(); i++){
            input[i]=tolower(input[i]);
    }
    // If user input's n or no, which are not given as options.
    if (input == "n" || "no"){
        cout << "\n\n|----------|\n";
        cout << "|Too bad...|\n";
        cout << "|----------|\n";
    }
    // Continue through adventure
    else {
        cout << "\n\n|-------------|\n";
        cout << "|Here we go...|\n";
        cout << "|-------------|\n";
    }
    // Storyline of your car breaking down and your options from there.
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Another Fantastic Surprise :)                              |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|BOOM - Your engine's tie rod just shot through the hood of |\n";
    cout << "|of your vehicle. '*Sigh*, that is it...' you mumble under  |\n";
    cout << "|your breath as you lay your head on the steering wheel.    |\n";
    cout << "|                                                           |\n";
    cout << "|As you look up from your steering wheel, through the gray  |\n";
    cout << "|smoke coming from your engine, you realize that this day is|\n";
    cout << "|not going to be getting any better. As you reach into your |\n";
    cout << "|pocket, you feel your keys, and your phone. You attempt to |\n";
    cout << "|call for a ride, but your phone is dead.                   |\n";
    cout << "|                                                           |\n";
    cout << "|'Great, grand, wonderful; guess I am walking!' you say in  |\n";
    cout << "|a sarcastic manner. Now you contemplate your next move on  |\n";
    cout << "|places that you can walk to.                               |\n";
    cout << "|                                                           |\n";
    cout << "|The first place you see is the home of the WHOPPER, Burger |\n";
    cout << "|King, but you might need to check the TRUNK first...                                                      |\n";
    cout << "|                                                           |\n";
    cout << "|Which location will you choose? (WHOPPER or TRUNK)         |\n";
    cout << "|-----------------------------------------------------------|\n";
    // Smartphone picked up (currently dead)
    dumbDevice = true;
    // Housekeys picked up
    houseKey = true;
    // User input in decision making for searching the trunk or heading to
    // Burger King
    string check;
    cin >> check;
    // For Loop to make user's input all lowercase
    cout << "\n";
    for(int b = 0; b < check.length(); b++){
        check[b] = tolower(check[b]);
    }
    // If Statement to send you directly to Burger King
    if(check == "whopper"){
        // You find out that your phone's battery is dead.
        dumbDevice = false;
        // Head over to Burger King storyline.
        burgerJoint();
    }
    // Else If Statement to let you check the trunk for items.
    else if (check == "trunk"){
        // Check the trunk for items.
        trunkCheck();
        // Head over to Burger King storyline.
        burgerJoint();
    }
    else{
        // Error Return
        deadCar();
    }
}
// Node for searching through the trunk.
void trunkCheck(){
// Node for entering Burger King
    // Intro to searching through the trunk.
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Gather your belongings                                     |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|You begin your final check of grabbing your possessions    |\n";
    cout << "|before abandoning your vehicle on the side of the road.    |\n";
    cout << "|You begin to dig around looking for your wallet, because   |\n";
    cout << "|you JUST KNOW that there is $4 in there. After a frantic   |\n";
    cout << "|search, you can't find your wallet. Although, you did find |\n";
    cout << "|about $1.75 in change; not quite enough for a full meal.   |\n";
    cout << "|'Oh! I think there is some more change in my gym bag.'     |\n";
    cout << "|Do you want to SEARCH your gym bag?                          |\n";
    cout << "|Enter YES or NO:                                           |\n";
    cout << "|-----------------------------------------------------------|\n";
    // User Input String
    string input;
    cin >> input;
    // For Loop to make user's input all lowercase
    for(int i=0; i<input.length(); i++){
            input[i]=tolower(input[i]);
    }
    // If Statement to allow you to choose a screw driver or a hammer.
    if (input == "yes" || input == "search"){
        // String to be used when pausing the story.
        string cont;
        cout << "\n\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|Gym Bag                                                    |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|Digging around in your bag you find $0.12... Two nickles   |\n";
        cout << "|and two pennies. There is also a SCREWDRIVER and a HAMMER. |\n";
        cout << "|Do you want to grab either tool, or LEAVE the items behind?|\n";
        cout << "|-----------------------------------------------------------|\n";
        // User Input String
        string trunkCheck;
        cin >> trunkCheck;
        // For Loop to make user's input all lowercase
        for(int b = 0; b < trunkCheck.length(); b++){
            trunkCheck[b]=tolower(trunkCheck[b]);
        }
        // If Statement to collect the screw driver & continue the story.
        if (trunkCheck == "screwdriver"){
            screwDriver = true;
            cout << "|-----------------------------------------------------------|\n";
            cout << "|You decide on grabbing the screwdriver. Shoving it in your |\n";
            cout << "|pocket aggressively. Make good decisions... or whatever.   |\n";
            cout << "|(Enter any key to continue)                                |\n";
            cout << "|-----------------------------------------------------------|\n";
        }
        // Else If Statement to collect the hammer & continue the story.
        else if (trunkCheck == "hammer"){
            hammer = true;
            cout << "|-----------------------------------------------------------|\n";
            cout << "|You decide on grabbing the hammer. Shoving it in your      |\n";
            cout << "|waistband aggressively. Make good decisions... or whatever.|\n";
            cout << "|(Enter any key to continue)                                |\n";
            cout << "|-----------------------------------------------------------|\n";
        }
        // Else If Statement to collect nothing & continue the story.
        else if (trunkCheck == "leave"){
            cout << "|-----------------------------------------------------------|\n";
            cout << "|For Real?! Okay then...                                    |\n";
            cout << "|-----------------------------------------------------------|\n";
            cout << "|You decide on leaving everything behind. Hopefully it won't|\n";
            cout << "|need them or something similar. It's your decision though. |\n";
            cout << "|(Enter any key to continue)                                |\n";
            cout << "|-----------------------------------------------------------|\n";
        }
        // User input pause in storyline.
        cin >> cont;
        if (cont == cont){
        }
        else{
        }
    }
    // Else If Statement to collect nothing & continue the story.
    else if (input == "no"){
        cout << "|-----------------------------------------------------------|\n";
        cout << "|For Real?! Okay then...                                    |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|You decide on leaving everything behind. Hopefully it won't|\n";
        cout << "|need them or something similar. It's your decision though. |\n";
        cout << "|(Enter any key to continue)                                |\n";
        cout << "|-----------------------------------------------------------|\n";
    }
    // Else Statement for Error & continue the story without collecting anything.
    else{
        cout << "|-----------------------------------------------------------|\n";
        cout << "|For Real?! Okay then...                                    |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|You decide on leaving everything behind. Hopefully it won't|\n";
        cout << "|need them or something similar. It's your decision though. |\n";
        cout << "|(Enter any key to continue)                                |\n";
        cout << "|-----------------------------------------------------------|\n";
    }
}
void burgerJoint(){
    // Intro to entering Burger King and stating whether or not you have
    // collected the screw driver used to fix the broken door handle.
    cout << "\n\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Who's the REAL King?                                       |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Walking up the door, you see a group of teenagers standing |\n";
    cout << "|outside of the restaurant. They don't say anything, but    |\n";
    cout << "|they keep staring at you. When you make it up to the front |\n";
    cout << "|you notice that the door handle is broken, and you could   |\n";
    cout << "|easily fix it ";
    if (screwDriver == true){
        cout << "with your screwdriver. First - you must eat. |\n";
    }
    else{
        cout << "if you had a screwdriver. Oh well, go on in. |\n";
    }
    cout << "|The smells coming from the inside are rancid, and there is |\n";
    cout << "|a homeless person urinating in the corner. 'Kinda expected |\n";
    cout << "|this to be the way things would go.' you utter under your  |\n";
    cout << "|breath.                                                    |\n";
    cout << "|One of the employee yells from the front that he is going  |\n";
    cout << "|out to fix the front door handle. As he walks away, you    |\n";
    cout << "|hear the cash register beep, open up, and reveal a drawer  |\n";
    cout << "|full of cash.                                              |\n";
    cout << "|Now you have two opportunities, one is ROBBING the store,  |\n";
    cout << "|and the other is OFFERING to fix the front door.           |\n";
    cout << "|-----------------------------------------------------------|\n";
    // User Input String
    string input;
    cin >> input;
    // For Loop to make user's input all lowercase
    for(int i = 0; i < input.length(); i++){
        input[i]=tolower(input[i]);
    }
    // If Statement to attempt to Rob the Burger King
    if(input == "robbing"){
        cout << "|-----------------------------------------------------------|\n";
        cout << "|A Robbery Adventure it is...                               |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|That seems like a terrible idea, but you try anyway. As you|\n";
        cout << "|rush up to the clerk aggressively, he flips you around and |\n";
        cout << "|chokes you to the floor, while whispering in your ear: 'Any|\n";
        cout << "|last words, fool?' You pass out and wake up to the police  |\n";
        cout << "|arresting you.                                             |\n";
        cout << "|(Enter any key to continue)                                |\n";
        cout << "|-----------------------------------------------------------|\n";
        // User Input String for pause
        string pause;
        cin >> pause;
        // End the game with a loss.
        if (pause == pause){
            endGameBad();
        }
        else{
            endGameBad();
        }
    }
    // Else If Statement to help the clerk and receive a reward for your
    // efforts and kindness towards others.
    else if(input == "offering" && screwDriver == true){
        cout << "|-----------------------------------------------------------|\n";
        cout << "|A Good Deed in a Cruel World...                            |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|You offer to repair the broken handle with the screwdriver |\n";
        cout << "|from your gym bag. The clerk says, 'sure - do you want some|\n";
        cout << "|food to eat for your trouble?' Without acting like you are |\n";
        cout << "|starving, you answer 'Yeah, I could eat', and complete the |\n";
        cout << "|task. The clerk thanks you, & you begin devouring the food.|\n";
        cout << "|(Enter any key to continue)                                |\n";
        cout << "|-----------------------------------------------------------|\n";
        // User Input String for pause
        string pause;
        cin >> pause;
        // End the game with a win.
        if (pause == pause){
            endGame();
        }
        else{
            endGame();
        }
    }
    // Else If Statement when you don't pick up the screw driver from the
    // beginning of the story.
    else if(input == "offering" && screwDriver == false){
        cout << "|-----------------------------------------------------------|\n";
        cout << "|You can't fix the door without a screwdriver...            |\n";
        cout << "|Looks like you are going to have to rob the joint!!!       |\n";
        cout << "|-----------------------------------------------------------|\n\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|A Robbery Adventure it is...                               |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|That seems like a terrible idea, but you try anyway. As you|\n";
        cout << "|rush up to the clerk aggressively, he flips you around and |\n";
        cout << "|chokes you to the floor, while whispering in your ear: 'Any|\n";
        cout << "|last words, fool?' You pass out and wake up to the police  |\n";
        cout << "|arresting you.                                             |\n";
        cout << "|(Enter any key to continue)                                |\n";
        cout << "|-----------------------------------------------------------|\n";
        // User Input String for pause
        string pause;
        cin >> pause;
        // End the game with a win.
        if (pause == pause){
            endGameBad();
        }
        else{
            endGameBad();
        }
    }
}
// Node for good Game Over
void endGame(){
    // Game Over title when you do good in the story.
    cout << "|-----------------------------------------------------------|\n";
    cout << "|           --------------GAME OVER-------------            |\n";
    cout << "|              WINNER, WINNER, CHICKEN DINNER               |\n";
    cout << "|           --------------GAME OVER-------------            |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Good to see that you have a kind heart and treated others  |\n";
    cout << "|nicely, even though you are obviously having a terrible    |\n";
    cout << "|day. Don't worry, it will always get better!!!             |\n";
    cout << "|(Enter any key to continue)                                |\n";
    cout << "|-----------------------------------------------------------|\n\n\n";
    // reset all bool type objects.
    dumbDevice = false;
    hammer = false;
    houseKey = false;
    screwDriver = false;
    startUp = false;
    // User Input String for pause
    string pause;
    cin >> pause;
    // End the game with a win.
    if (pause == pause){
    }
    else{
    }
}
// Node for bad Game Over
void endGameBad(){
    // Game Over title when you do bad in the story.
    cout << "|-----------------------------------------------------------|\n";
    cout << "|           --------------GAME OVER-------------            |\n";
    cout << "|           PLAY STUPID GAMES, WIN STUPID PRIZES            |\n";
    cout << "|           --------------GAME OVER-------------            |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Probably shouldn't be doing stupid stuff like you did, huh?|\n";
    cout << "|(Enter any key to continue)                                |\n";
    cout << "|-----------------------------------------------------------|\n\n\n";
    // reset all bool type objects.
    dumbDevice = false;
    hammer = false;
    houseKey = false;
    screwDriver = false;
    startUp = false;
    // User Input String for pause
    string pause;
    cin >> pause;
    // End the game with a win.
    if (pause == pause){
    }
    else{
    }
}
// Main
int main(){
    // Intro to the Adventure
    cout << "----------------------------------------------------|\n";
    cout << "|---------------   ADVENTURE TIME   ----------------|\n";
    cout << "----------------------------------------------------|\n";
    cout << "----------------------------------------------------|\n";
    cout << "|   To play this game, type in the BOLD letters in  |\n";
    cout << "|this Adventure when prompted to...let's try to make|\n";
    cout << "|                  good decisions. :)               |\n";
    cout << "----------------------------------------------------|\n\n\n";
    // Character play used for user input.
    char play;
    // Question 1
    if (startUp == true) {
        cout << "|---------------------------------------------------|\n";
        cout << "|Are you ready to begin your adventure?!(y/n)?      |\n";
        cout << "|---------------------------------------------------|\n";
    }
    // Repeat Game Question
    else {
        cout << "|---------------------------------------------------|\n";
        cout << "|Would you like to play again(y/n)?                 |\n";
        cout << "|---------------------------------------------------|\n";
        cout << "";
    }
    cin >> play;
    if (play == 'y' || play == 'Y') {
        // start in garden
        deadCar();
        startUp = false;
        // loop back around to play again
        main();
    }
    else {
        cout << "|---------------------------------------------------|\n";
        cout << "|Goodbye! - Thanks for playing                      |\n";
        cout << "|---------------------------------------------------|\n";
        cout << "" << endl;
    }
    return 0;
}
