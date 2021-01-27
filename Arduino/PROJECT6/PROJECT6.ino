int RED_LED = 4;
int Echo = A4;
int Trig = A5;
int Buzzer = 3;

void setup() {
  Serial.begin(9600);
  // put your setup code here, to run once:
  pinMode(Echo, INPUT);
  pinMode(Trig, OUTPUT);
  pinMode(Buzzer, OUTPUT);
  pinMode(RED_LED, OUTPUT);
}

// UltraSonic distance measurement Sub function
int Distance_test(){
  digitalWrite(Trig, LOW);
  delayMicroseconds(2);
  digitalWrite(Trig, HIGH);
  delayMicroseconds(20);
  digitalWrite(Trig, LOW);
  float Fdistance = pulseIn(Echo, HIGH);
  Fdistance / 58;
  return (int)Fdistance;
}
int noise(int count){
  
  for(int i = 0; i < count; i++){
    digitalWrite(Buzzer, HIGH);
    digitalWrite(RED_LED, HIGH);
  }
  digitalWrite(Buzzer, LOW);
  digitalWrite(RED_LED, LOW);
}
void loop() {
  // put your main code here, to run repeatedly:
  int distanceCM;
  distanceCM = Distance_test();
  Serial.println(distanceCM);
  if (distanceCM < 250){
    digitalWrite(Buzzer, HIGH);
    digitalWrite(RED_LED, HIGH);
  }
  else if (distanceCM < 500){
    noise(4000);
  }
  else if (distanceCM < 1000){
    noise(6000);
  }
  else if (distanceCM < 1500){
    noise(8000);
  }
  else if (distanceCM < 2000){
    noise(10000);
  }
  else{
    digitalWrite(Buzzer, LOW);
    digitalWrite(RED_LED, LOW);
  }
  delay(50);

}
