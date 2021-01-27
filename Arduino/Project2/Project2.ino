// Variables in corrispondence to pin numbers.  
#define RED_LED 3
#define GREEN_LED 4
#define BLUE_LED 5
#define BLANK 8
#define SWITCH 6
// Setup Coding
void setup() {
  // Digital Pins - Input/Outputs
  pinMode(RED_LED, OUTPUT);
  pinMode(GREEN_LED, OUTPUT);
  pinMode(BLUE_LED, OUTPUT);
  pinMode(SWITCH, INPUT);
}
void flash(int bang){
  for(int i = 0; i < bang; i++){
    highLow(RED_LED, 50, 1);
    highLow(GREEN_LED, 50, 1);
    highLow(BLUE_LED, 50, 1);
  }
  // Turn off everything for 2 seconds 
  highLow(BLANK, 1000, 1);
}
//
void highLow(int pin, int num, int flash){
  // For loop to make pins do stuff from Void Loop Module.
  for(int i = 0; i < flash; i++){
    // What pin to energize in high setting.
    digitalWrite(pin, HIGH);
    // Time in high setting
    delay(num);
    // What pin to energize in low setting
    digitalWrite(pin, LOW);
    // Time in low setting
    delay(num);
  }
}
void loop() {
  
  // Blink Red LED 3 times with a 1/2 second delay.
  highLow(RED_LED, 500, 3);
  // Blink Green LED 2 times with a 1/4 second delay.
  highLow(GREEN_LED, 250, 2);
  // Blink Red LED 2 times with a 3/4 second delay.
  highLow(RED_LED, 750, 2);
  // Turn off everything for 2 seconds 
  highLow(BLANK, 1000, 1);
  // Strobe back and forth
  flash(10);
  
}
