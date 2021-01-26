// Jon King
// M1T1 - Rectangle Class Exercise
// 22SEP20
// Description Below:
//  1) Bronze Tier (80/100):
//      Enter program 13-1 ("Rectangle") from the Gaddis slides.
//      Submit the program and a screenshot of the output.
//
//  2) Silver Tier (90/100):
//      As Bronze, and add input validation to ensure the
//      rectangle is a valid size. (No sides can be zero, or negative.)
//
//  3) Gold Tier (100/100):
//      As Silver, and create a second file which replaces the Rectangle
//      class with a class Box. We'll define a "Box" as a three dimensional
//      rectangle -- it has length and width, and it also has height.
//      Instead of area, it has volume.
//
//  4) Include both files, and a screenshot of the program output.

#include <iostream>
using namespace std;

// Rectangle class declaration
class Rectangle{
    private:
        double width;
        double length;
    public:
        void setWidth(double);
        void setLength(double);
        double getWidth() const;
        double getLength() const;
        double getArea() const;
};

//**************************************************
// setWidth assigns a value to the width member.   *
//**************************************************

void Rectangle::setWidth(double w){
    width = w;
}

//**************************************************
// setLength assigns a value to the length member. *
//**************************************************

void Rectangle::setLength(double len){
    length = len;
}

//**************************************************
// getWidth returns the value to the width member. *
//**************************************************

double Rectangle::getWidth() const{
    return width;
}

//****************************************************
// getLength returns the value to the length member. *
//****************************************************

double Rectangle::getLength() const{
    return length;
}

//*****************************************************
// getArea returns the product of width times length. *
//*****************************************************

double Rectangle::getArea() const{
    return width * length;
}

//**************************************************
// Function Main                                   *
//**************************************************

int main()
{
    // Define an instance of the Rectangle class
    Rectangle box;
    // Local variable for Width
    double rectWidth;
    // Local variable for Length
    double rectLength;

    // Get the rectangle's width and length from the user.
    cout << "This program will calculate the area of a\n";
    cout << "rectangle. What is the width? ";
    cin >> rectWidth;
    cout << "What is the length? ";
    cin >> rectLength;

    // Store the width and length of the rectangle
    // in the box object.
    box.setWidth(rectWidth);
    box.setLength(rectLength);

    // Display the rectangle's data.
    cout << "Here is the rectangle's data:\n";
    cout << "Width: " << box.getWidth() << endl;
    cout << "Length: " << box.getLength() << endl;
    cout << "Area: " << box.getArea() << endl;
    return 0;
}
