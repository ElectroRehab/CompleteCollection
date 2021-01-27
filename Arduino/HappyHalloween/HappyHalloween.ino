/*
 LiquidCrystal Display - Happy Halloween
  The circuit:
 * LCD RS pin to digital pin 12
 * LCD Enable pin to digital pin 11
 * LCD D4 pin to digital pin 5
 * LCD D5 pin to digital pin 4
 * LCD D6 pin to digital pin 3
 * LCD D7 pin to digital pin 2
 * LCD VDD pin to 5V
 * LCD A pin to 3.3V
 * LCD K, RW, VO, VSS pins to ground
*/
// include the library code:
#include <LiquidCrystal.h>

// initialize the library by associating any needed LCD interface pin
// with the arduino pin number it is connected to
const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

// make some custom characters:
byte ghost[8] = { 
  0b00000, 
  0b01110, 
  0b01110, 
  0b10101, 
  0b11111, 
  0b11111, 
  0b11111, 
  0b10101 
};
byte ghosts[8] = { 
  0b00000, 
  0b01110, 
  0b01110, 
  0b11111, 
  0b10101, 
  0b11111, 
  0b11111, 
  0b10101 
};
byte pinkin[8] = {
  0b00011,
  0b00110,
  0b01111,
  0b10101,
  0b11111,
  0b10101,
  0b11011,
  0b01110 
};
byte punkin[8] = {
  0b11000,
  0b01100,
  0b11110,
  0b10101,
  0b11111,
  0b10101,
  0b11011,
  0b01110 
};
byte pumpkin[8] = {
  0b00100,
  0b00100,
  0b01110,
  0b10101,
  0b11111,
  0b10101,
  0b11011,
  0b01110 
};

void setup() {
  // initialize LCD and set up the number of columns and rows:
  lcd.begin(16, 2);
  // create a new character
  lcd.createChar(5, punkin);
  // create a new character
  lcd.createChar(6, pumpkin);
  // create a new character
  lcd.createChar(7, pinkin);
  // create a new character
  lcd.createChar(8, ghost);
  // create a new character
  lcd.createChar(9, ghosts);
}
void loop() {
  // read the potentiometer on A0:
  int sensorReading = analogRead(A0);
  // map the result to 200 - 1000:
  int delayTime = map(sensorReading, 0, 500, 100, 25);
  // set the cursor to the top left
  lcd.setCursor(0, 0);
  // Print a message to the lcd.
  lcd.print("HAPPY");
  lcd.print(" HALLOWEEN!");
  delay(delayTime);
  for (int i = 5; i < 8; i++){
    for(int j = 0; j < 16; j++){
      lcd.setCursor(j, 1);
      lcd.write(i);
      delay(delayTime);
      j++;
    }
  }
  for (int i = 8; i < 10; i++){
    for(int j = 1; j < 16; j++){
      lcd.setCursor(j, 1);
      lcd.write(i);
      delay(delayTime);
      j++;
    }
    // set the cursor to the top left
    lcd.setCursor(0, 0);
    // Print a message to the lcd.
    lcd.print("                ");
  }
}
