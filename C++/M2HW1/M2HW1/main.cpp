#include <string>
#include <iostream>
#include <vector>
using namespace std;
// Function prototype list.
void badChoice();
void bkArt();
void bombArt();
void bumTackle();
void burgerJoint();
void deadCar();
void endGame();
void endGameBad();
void endGameToBeCont();
void extraInputs();
void greatDay();
void gymBag();
void helpBK();
void helpfulCitizen();
void howToPlay();
void leaveBehind();
void pauseGame();
void resetBools();
void robberyBlock();
void shareTheWealth();
void trunkCheck();


// Initiate In-Game Items
bool dumbDevice = false;
bool houseKey = false;
bool moneyDropBK = false;
bool screwDriver = false;
bool startUp = true;
// Used to limit the words displayed on the user's screen.
void pauseGame(){
    // pause in Story
    cout << "|(Enter any key to continue)                                |\n";
    string cont;
    cin >> cont;
    if (cont == cont){

    }
    else{

    }
}
void resetBools(){
    dumbDevice = false;
    houseKey = false;
    moneyDropBK = false;
    screwDriver = false;
    startUp = false;

}
void badChoice(){
    cout << "|-----------------------------------------------------------|\n";
    cout << "|That is not an option, please try again                    |\n";
    cout << "|-----------------------------------------------------------|\n";
}
void leaveBehind(){
    cout << "|-----------------------------------------------------------|\n";
    cout << "|For Real?! Okay then...                                    |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|You decide on leaving everything behind. Hopefully it won't|\n";
    cout << "|need them or something similar. It's your decision though. |\n";
    cout << "|-----------------------------------------------------------|\n";
}
void endGameToBeCont(){
    // Game Over title when you do good in the story.
    cout << "|-----------------------------------------------------------|\n";
    cout << "|           --------------GAME OVER-------------            |\n";
    cout << "|              WINNER, WINNER, CHICKEN DINNER               |\n";
    cout << "|           --------------GAME OVER-------------            |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Sort of... Not necessarily a 'win', but you have made it   |\n";
    cout << "|out alive. Not sure where this adventure will take the two |\n";
    cout << "|of you, but you know that this is just the beginning...    |\n";
    // reset all bool type objects.
    resetBools();
    // pause in Story
    pauseGame();
    cout << "|-----------------------------------------------------------|\n";

}
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
    resetBools();
    // pause in Story
    pauseGame();

}
void helpBK(){
    cout << "|-----------------------------------------------------------|\n";
    cout << "|A Good Deed in a Cruel World...                            |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|You offer to repair the broken handle with the screwdriver |\n";
    cout << "|from your gym bag. The clerk says, 'sure - do you want some|\n";
    cout << "|food to eat for your trouble?' Without acting like you are |\n";
    cout << "|starving, you answer 'Yeah, I could eat', and complete the |\n";
    cout << "|task. The clerk thanks you, & you begin devouring the food.|\n";
    // pause in Story
    pauseGame();
    cout << "|-----------------------------------------------------------|\n";
    endGame();
}
// Starting point... so to speak.
void greatDay(){
    string cont;
    cout << "|-----------------------------------------------------------|\n";
    cout << "|                       What a Day!                         |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|You find yourself snapping back into reality while driving.|\n";
    cout << "|'SH**!!!' you scream as you swerve back into your lane.    |\n";
    cout << "|                                                           |\n";
    cout << "|Although, you really don't know where you are going. It has|\n";
    cout << "|not been your day. Today you lost your job, your apartment,|\n";
    cout << "|and found out that your significant other has been cheating|\n";
    cout << "|on you. Not exactly a good day.                            |\n";
    cout << "|                                                           |\n";
    cout << "|You think to yourself, 'How could this get any worse?!'    |\n";
    cout << "|(Enter any key to see...)                                  |\n";
    cout << "|-----------------------------------------------------------|\n";
    cin >> cont;
    for(int i=0; i<cont.length(); i++){
            cont[i]=tolower(cont[i]);
    }
    if (cont == "n" || cont == "no"){
        cout << "\n\n|----------|\n";
        cout << "|Too bad...|\n";
        cout << "|----------|\n";
        bombArt();
        deadCar();
    }
    else {
        bombArt();
        deadCar();
    }
}
void deadCar(){
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
void trunkCheck(){
    // Intro to searching through the trunk.
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Gather your belongings                                     |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|You begin your final check of grabbing your possessions    |\n";
    cout << "|before abandoning your vehicle on the side of the road.    |\n";
    cout << "|You begin to dig around looking for your wallet, because   |\n";
    cout << "|you just know that there is $4 in there. After a frantic   |\n";
    cout << "|search, you can't find your wallet. Although, you did find |\n";
    cout << "|about $1.75 in change; not quite enough for a full meal.   |\n";
    cout << "|'Oh! I think there is some more change in my gym bag.'     |\n";
    cout << "|Do you want to SEARCH your gym bag?                        |\n";
    cout << "|Enter YES or NO:                                           |\n";
    cout << "|-----------------------------------------------------------|\n";
    // User Input String
    string input;
    cin >> input;
    // For Loop to make user's input all lowercase
    for(int i=0; i<input.length(); i++){
            input[i]=tolower(input[i]);
    }
    if (input == "yes" || input == "search"){
        gymBag();
    }
    else if (input == "no"){
        leaveBehind();
    }

    else{
        leaveBehind();
    }
}
void gymBag(){
    string cont;
    cout << "\n\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Gym Bag                                                    |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Digging around in your bag you find $0.12... Two nickles   |\n";
    cout << "|and two pennies. There is also a SCREWDRIVER. Do you want  |\n";
    cout << "|to grab the tool, or LEAVE the items behind?               |\n";
    cout << "|-----------------------------------------------------------|\n";
    string input;
    cin >> input;
    for(int b = 0; b < input.length(); b++){
        input[b]=tolower(input[b]);
    }

    if (input == "screwdriver"){
        screwDriver = true;
        cout << "|-----------------------------------------------------------|\n";
        cout << "|You decide on grabbing the screwdriver. Shoving it in your |\n";
        cout << "|pocket aggressively. Make good decisions... or whatever.   |\n";
    }
    else if (input == "leave"){
        leaveBehind();
    }
    else{
        badChoice();
        gymBag();
    }
    // pause in Story
    pauseGame();
    cout << "|-----------------------------------------------------------|\n";
}

void burgerJoint(){
    bkArt();
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
    if(input == "robbing"){
        robberyBlock();
    }
    else if(input == "offering" && screwDriver == true){
        helpBK();
    }
    else if(input == "offering" && screwDriver == false){
        cout << "|-----------------------------------------------------------|\n";
        cout << "|You can't fix the door without a screwdriver...            |\n";
        cout << "|Looks like you are going to have to rob the joint!!!       |\n";
        cout << "|-----------------------------------------------------------|\n";
        pauseGame();
        robberyBlock();
    }
}
void shareTheWealth(){
    string decideMoney;
    cin >> decideMoney;
    for(int i = 0; i < decideMoney.length(); i++){
        decideMoney[i]=tolower(decideMoney[i]);
    }
    if (decideMoney == "yes" || decideMoney == "money"){
        moneyDropBK = true;
        cout << "\n\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|Man's Best Friend???                                       |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|An overwhelming fear builds up inside of you, but you      |\n";
        cout << "|manage to reach into your pocket and throw a few $20 bills |\n";
        cout << "|on the floor towards the homeless man. 'This is all that I |\n";
        cout << "|can spare.' The homeless man howls into the ceiling, gets  |\n";
        cout << "|on his hands and knees, and scoots over to the money at a  |\n";
        cout << "|disturbingly incredible speed! Grabs the currency, smells  |\n";
        cout << "|all of them, and scuttles back into his urine corner.        |\n";
    }
    else{
        moneyDropBK = false;
        cout << "\n\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|It's All Mine!!!                                           |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|An overwhelming fear builds up inside of you, as the crazy |\n";
        cout << "|homeless man howls into the ceiling, gets on his hands and |\n";
        cout << "|knees, and scoots over to your area at a disturbingly      |\n";
        cout << "|incredible speed! Sniffs in the air, and scuttles back into|\n";
        cout << "|his urine corner.                                          |\n";
    }
    // pause in Story
    pauseGame();
}
void robberyBlock(){
    if (screwDriver == true || screwDriver == false){
        cout << "|-----------------------------------------------------------|\n";
        cout << "|A Robbery Adventure it is...                               |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|The employee didn't even notice the register opened, so you|\n";
        cout << "|feel comfortable enough to go behind the counter. As you   |\n";
        cout << "|reach into the till, the homeless man yells out a slur 'hey|\n";
        cout << "|mufu**a, gimme some of that sh**!!!' You begin shoving what|\n";
        cout << "|you can from the register into your pockets.               |\n";
        cout << "|Do you want to give the homeless man any of the MONEY?     |\n";
        cout << "|(Enter Yes or No)                                          |\n";
        cout << "|-----------------------------------------------------------|\n";
        shareTheWealth();
        cout << "\n|-----------------------------------------------------------|\n";
        cout << "|WHELP, TIME TO GO!!!                                       |\n";
        cout << "|-----------------------------------------------------------|\n";
        cout << "|The employee is walking back in now. Slowly you head       |\n";
        cout << "|towards the door. The employee notices that his till is    |\n";
        cout << "|completely empty and exclaims 'STOP, THIEF!!!' Your heart  |\n";
        cout << "|begins to race as you turn around. The employee is now     |\n";
        cout << "|sprinting in your direction...                             |\n";
        cout << "|Do you RUN or FIGHT?                                       |\n";
        cout << "|-----------------------------------------------------------|\n";
        string input;
        cin >> input;
        for(int j = 0; j < input.length(); j++){
            input[j]=tolower(input[j]);
        }
        if (input == "run"){
            cout << "|-----------------------------------------------------------|\n";
            cout << "|RUN, FOOL!!!                                               |\n";
            cout << "|-----------------------------------------------------------|\n";
            bumTackle();
        }
        else if(input == "fight"){
            cout << "|-----------------------------------------------------------|\n";
            cout << "|FIGHT, FIGHT, FIGHT, FIGHT!!!                                               |\n";
            cout << "|-----------------------------------------------------------|\n";
            bumTackle();
        }
    }
    else{
        bumTackle();
    }
}
void bumTackle(){

    cout << "|A deeper growl just essentially made your chest rumble came|\n";
    cout << "|from the direction of the homeless man. A lot deeper than  |\n";
    cout << "|the one you heard earlier. The employee stopped in his     |\n";
    cout << "|tracks as well.                                            |\n";
    cout << "|Like nothing you ever seen before, a blur flashes before   |\n";
    cout << "|your eyes, and the wind from it causes you to close your   |\n";
    if (moneyDropBK == true){
        cout << "|eyes. A loud scream comes from behind the counter, and the |\n";
        cout << "|homeless man is no longer in the corner... Might be best if|\n";
        cout << "|you just turn around and walk, no, RUN!!!                  |\n";
        cout << "|-----------------------------------------------------------|\n";
        pauseGame();
        helpfulCitizen();
    }
    else{
        string input;
        cout << "|eyes. What feels like a giant hook latches into your neck. |\n";
        cout << "|You try to kick your arms and legs, but neither work! The  |\n";
        cout << "|last thing you see and hear is the homeless man whispering |\n";
        cout << "|into your ear, 'All I wanted was a buck; was it worth it?  |\n";
        cout << "|-----------------------------------------------------------|\n";
        pauseGame();
        endGameBad();
    }

}
void helpfulCitizen(){
    cout << "|-----------------------------------------------------------|\n";
    cout << "|WHAT JUST HAPPENED IN THERE?!                              |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Was... Was that... Was that bum a ninja? WAS HE A MONSTER?!|\n";
    cout << "|No time to process that, you run to your car. As you cross |\n";
    cout << "|the street, a vehicle comes speeding up to you. A lady     |\n";
    cout << "|yells 'GET IN, THERE ARE CREATURES AFTER US!!!' After what |\n";
    cout << "|you just witnessed, there is no denying that this is an    |\n";
    cout << "|absolute fact. Even though you are terrified, you blinding |\n";
    cout << "|jump into the vehicle in hopes that you can make it out    |\n";
    cout << "|alive.                                                     |\n";
    pauseGame();
    cout << "|-----------------------------------------------------------|\n";
    endGameToBeCont();
}
void endGameBad(){
    cout << "|-----------------------------------------------------------|\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|           --------------GAME OVER-------------            |\n";
    cout << "|           PLAY STUPID GAMES, WIN STUPID PRIZES            |\n";
    cout << "|           --------------GAME OVER-------------            |\n";
    cout << "|-----------------------------------------------------------|\n";
    cout << "|Your final words were ";
    cout << "...\n|uuuuuuh. hmmmm. Well, your final words were cut short.     |\n";
    cout << "|Probably shouldn't be doing stupid stuff like you did, huh?|\n";
    cout << "|-----------------------------------------------------------|\n";
    resetBools();
    pauseGame();
    cout << "|-----------------------------------------------------------|\n";
}
void howToPlay(){
    cout << "----------------------------------------------------|\n";
    cout << "|---------------   ADVENTURE TIME   ----------------|\n";
    cout << "----------------------------------------------------|\n";
    cout << "----------------------------------------------------|\n";
    cout << "|   To play this game, type in the BOLD letters in  |\n";
    cout << "|this Adventure when prompted to...let's try to make|\n";
    cout << "|                  good decisions. :)               |\n";
    cout << "----------------------------------------------------|\n\n\n";
}
void bombArt(){
    cout << "     _.-^^---....,,--             _.-^^---....,,--  \n";
    cout << " _--                  --_     _--                  --_  \n";
    cout << "<                        >)  <                        >)  \n";
    cout << "|           BOOM          |  |          BOOM           |  \n";
    cout << " )._                   _./   )._                   _./  \n";
    cout << "    ```--. . , ; .--'''         ```--. . , ; .--'''  \n";
    cout << "          | |   |                     | |   |  \n";
    cout << "       .-=||  | |=-.               .-=||  | |=-.  \n";
    cout << "       `-=#$%&%$#=-'               `-=#$%&%$#=-'  \n";
    cout << "          | ;  :|                     | ;  :|  \n";
    cout << " _____.,-#%&$@%#~,._____     _____.,-#%&$@%#~,._____  \n";
    pauseGame();
}
void bkArt(){

    cout << "                 |^|                        \n";
    cout << "              ___| |________________________\n";
    cout << "             /===| |======================/|\n";
    cout << "            /====|_|=====================/ |\n";
    cout << "           /============================/  |\n";
    cout << "          /============================/   |\n";
    cout << "          |---------------------------|    |\n";
    cout << "          |        BURGER KING        |    |\n";
    cout << "          |          (_____)          |   / \n";
    cout << "          |  ^^  ^^  |  |  |  ^^  ^^  |  /  \n";
    cout << "          |  []  []  |  |  |  []  []  | /   \n";
    cout << "          |_________@|__|__|@_________|/    \n";
    cout << "                    --=====--         \n";
    cout << "                     |=====|          \n";
    cout << "                    (=======)         \n";
    pauseGame();
}
// Main
int main(){
    //
    howToPlay();
    char play;

    if (startUp == true) {
        cout << "----------------------------------------------------|\n";
        cout << "|Are you ready to begin your quest(y/n)?            |\n";
        cout << "----------------------------------------------------|\n\n\n";
    }
    else {
        cout << "----------------------------------------------------|\n";
        cout << "|Would you like to play again(y/n)?                 |\n";
        cout << "----------------------------------------------------|\n\n\n";
    }
    cin >> play;
    if (play == 'y' || play == 'Y') {
        // start in garden
        greatDay();
        startUp = false;
        // loop back around to play again
        main();
    }
    else {
        cout << "----------------------------------------------------|\n";
        cout << "|Goodbye! Thanks for Playing!!!                     |\n";
        cout << "----------------------------------------------------|\n\n\n";
    }

    return 0;
}
