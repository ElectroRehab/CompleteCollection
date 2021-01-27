#define RED_LED 3
#define GREEN_LED 4
#define SWITCH  11
#define RED_DELAY 1000
#define GREEN_DELAY 500
#define YELLOW_DELAY  250

long endTime;
int activeLED;
bool ledState;

void setup() {
  // put your setup code here, to run once:
  pinMode(RED_LED, OUTPUT);
  pinMode(GREEN_LED, OUTPUT);
  pinMode(SWITCH, INPUT);

  activeLED = RED_LED; // Set to any LED
  ledState = false;
  endTime = millis() - 1;
}

// NON-BLOCKING LED call
bool blinkLed(int pin, int delayMs){
  if (pin != activeLED){
    digitalWrite(activeLED, LOW);
    activeLED = pin;
    ledState = true;
    digitalWrite(activeLED, ledState);
    endTime = millis() + delayMs;
  }
  else{
    if (millis() > endTime){
      ledState = !ledState;
      digitalWrite(activeLED, ledState);
      endTime = millis() + delayMs;
    }
  }
}
void loop() {
  // put your main code here, to run repeatedly:
  if (digitalRead(SWITCH)){
    blinkLed(GREEN_LED, GREEN_DELAY);
  }
  else{
    blinkLed(RED_LED, RED_DELAY);
  }
}
