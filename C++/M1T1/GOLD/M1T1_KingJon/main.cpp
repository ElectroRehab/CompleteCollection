// Jon King
// M1T1 - Box Class Exercise
// 22SEP20
// Description Below:
//  1) Bronze Tier (80/100):
//      Enter program 13-1 ("Box") from the Gaddis slides.
//      Submit the program and a screenshot of the output.
//
//  2) Silver Tier (90/100):
//      As Bronze, and add input validation to ensure the
//      rectangle is a valid size. (No sides can be zero, or negative.)
//
//  3) Gold Tier (100/100):
//      As Silver, and create a second file which replaces the Box
//      class with a class Box. We'll define a "Box" as a three dimensional
//      rectangle -- it has length and width, and it also has height.
//      Instead of area, it has volume.
//
//  4) Include both files, and a screenshot of the program output.

#include <iostream>
using namespace std;

// Box class declaration
class Box{
    private:
        double width;
        double length;
        double height;
    public:
        void setWidth(double);
        void setLength(double);
        void setHeight(double);

        double getWidth() const;
        double getLength() const;
        double getHeight() const;
        double getVolume() const;
};

//**************************************************
// setWidth assigns a value to the width member.   *
//**************************************************

void Box::setWidth(double w){
    width = w;
}

//**************************************************
// setLength assigns a value to the length member. *
//**************************************************

void Box::setLength(double len){
    length = len;
}

//**************************************************
// setHeight assigns a value to the length member. *
//**************************************************

void Box::setHeight(double h){
    height = h;
}

//**************************************************
// Input Validation Node.                          *
//**************************************************

void inputValid(){
    cout << "You must enter a number greater than 0...";
    cout << "Please try again:\n";

}

//**************************************************
// getWidth returns the value to the width member. *
//**************************************************

double Box::getWidth() const{
    return width;
}

//****************************************************
// getLength returns the value to the length member. *
//****************************************************

double Box::getLength() const{
    return length;
}

//****************************************************
// getHeight returns the value to the height member. *
//****************************************************

double Box::getHeight() const{
    return height;
}

//*****************************************************
// getVolume returns the product of width times length. *
//*****************************************************

double Box::getVolume() const{
    return width * length * height;
}

// Create Input Validation Node.
void inputValid();

//**************************************************
// Function Main                                   *
//**************************************************

int main()
{
    // Define an instance of the Box class
    Box box;
    // Local variable for Width
    double rectWidth;
    // Local variable for Length
    double rectLength;
    // Local variable for Length
    double rectHeight;

    // Get the rectangle's width and length from the user.
    cout << "This program will calculate the area of a\n";
    cout << "rectangle. What is the width? ";
    cin >> rectWidth;
    // While loop to ensure that the user enters a number greater than 0.
    while (rectWidth <= 0){
            inputValid();
            cin >> rectWidth;
    }
    cout << "What is the length? ";
    cin >> rectLength;
    // While loop to ensure that the user enters a number greater than 0.
    while (rectLength <= 0){
            inputValid();
            cin >> rectLength;
    }
    cout << "What is the height? ";
    cin >> rectHeight;
    // While loop to ensure that the user enters a number greater than 0.
    while (rectHeight <= 0){
            inputValid();
            cin >> rectHeight;
    }
    // Store the width and length of the rectangle
    // in the box object.
    box.setWidth(rectWidth);
    box.setLength(rectLength);
    box.setHeight(rectHeight);

    // Display the rectangle's data.
    cout << "Here is the rectangle's data:\n";
    cout << "Width: " << box.getWidth() << endl;
    cout << "Length: " << box.getLength() << endl;
    cout << "Height: " << box.getHeight() << endl;
    cout << "Volume: " << box.getVolume() << endl;
    return 0;
}
