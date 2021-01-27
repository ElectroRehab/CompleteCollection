const byte intRightPin = 2;
const byte intLeftPin = 3;

volatile int rightCount = 0;
volatile int leftCount = 0;
volatile long rightTime = 0;
volatile long leftTime = 0;
volatile int rightState = false;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(19200);
  pinMode(intRightPin, INPUT);
  attachInterrupt(digitalPinToInterrupt(intRightPin), rightSensor, CHANGE);
}

void loop() {
  // put your main code here, to run repeatedly:
  char message[64];
  sprintf(message, "Count, time, on: %d %d %s", rightCount, rightTime, rightState);
  Serial.println(message);
  delay(1000);
}

void rightSensor(){
  rightCount++;
  rightTime = millis();
  rightState = digitalRead(intRightPin);
}
