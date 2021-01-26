// Jon King
// M3LAB1 -  Adventure Call (first iteration)
// 10SEP20
// Description Below:
//  For M3LAB1, we'll begin using object-oriented programming methods to
//  tackle our Text Adventure project in a more manageable way.
//
//  First, we'll create the Room class, and instantiate several Room
//  objects using it.
//
//  To complete the assignment, you should write a program, using the
//  video as a template, that:
//      1) Creates 3 to 5 Room objects
//
//      2) Lists the name and description of each room
//
//  You should use a combination of the methods presented (both
//  constructors, and plain cout vs. using the describe() function) to
//  get a feel for how the class operates.
//
//  Next, we'll be adding exits to these rooms, in order to link them
//  together into a larger structure.
//
#include <iostream>
using namespace std;

class Room{
public:
    // class fields (variables)
    int id;
    string name;
    string description;
    // Class Methods (functions)
    Room(){
    };

    Room(int id, string name, string description){
        this->id = id;
        this->name = name;
        this->description = description;
    };

    void describe(){
        cout << name << endl;
        cout << description << endl;
    }

    void describeFull(){
        cout << id << "\t" << name << "\t" << description << endl;
    }

};

int main()
{
    cout << "Sample Room Info" << endl;
    // Living Room Information
    Room livingRoom;
    livingRoom.name = "Living Room";
    livingRoom.id = 1;
    livingRoom.description = "A simple living room with carpet and a couch.";

    cout << livingRoom.name << endl;
    cout << livingRoom.id << endl;
    cout << livingRoom.description << endl;

    cout << "next room" << endl;
    // Kitchen Information
    Room kitchen = Room(2, "Kitchen ", "A small, dimly lit kitchen.");
    cout << kitchen.name << endl;
    cout << kitchen.id << endl;
    cout << kitchen.description << endl;

    cout << "With description function" << endl;
    livingRoom.describe();
    kitchen.describe();

    cout << "next room" << endl;
    // Basement Information
    Room basement = Room(3, "Basement", "A dirty, dingy moldy basement.");
    cout << basement.name << endl;
    cout << basement.id << endl;
    cout << basement.description << endl;

    cout << "With description function" << endl << endl;
    livingRoom.describe();
    kitchen.describe();
    basement.describe();

    cout << "next room" << endl;
    // Bathroom Information
    Room bathRoom = Room(4, "Bathroom", "A pristine cleaned bathroom.");
    cout << bathRoom.name << endl;
    cout << bathRoom.id << endl;
    cout << bathRoom.description << endl;

    cout << "\nWith description function" << endl;
    livingRoom.describe();
    kitchen.describe();
    basement.describe();
    bathRoom.describe();

    cout << "next room" << endl;
    // Dining Room Information
    Room diningRoom = Room(5, "Dining Room", "A large table with one chair.");
    cout << diningRoom.name << endl;
    cout << diningRoom.id << endl;
    cout << diningRoom.description << endl;

    cout << "With description function" << endl;
    livingRoom.describe();
    kitchen.describe();
    basement.describe();
    bathRoom.describe();
    diningRoom.describe();

    // Display information in a formatted manner.
    cout << "\nWith description function & formatting" << endl;
    cout << "ID\tROOM\t\tDESCRIPTION" << endl;
    livingRoom.describeFull();
    kitchen.describeFull();
    basement.describeFull();
    bathRoom.describeFull();
    diningRoom.describeFull();

    return 0;
}
