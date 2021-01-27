#include <Arduino.h>
#include <Wire.h>
#include <SPI.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>
#include <BMx280I2C.h>

#define I2C_ADDRESS 0x76
// OLED display width, in pixels
#define SCREEN_WIDTH 128 
// OLED display height, in pixels
#define SCREEN_HEIGHT 64 
// Declaration for SSD1306 display connected using software SPI (default case):
#define OLED_RESET 4
//create a BMx280I2C object using the I2C interface with I2C Address 0x76
BMx280I2C bmx280(I2C_ADDRESS);
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

void setup(){
  Serial.begin(9600);
  // SSD1306_SWITCHCAPVCC = generate display voltage from 3.3V internally
  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {
    Serial.println(F("SSD1306 allocation failed"));
    for(;;); // Don't proceed, loop forever
  }
  // Draw 'stylized' characters
  testdrawstyles();
	//wait for serial connection to open (only necessary on some boards)
	while (!Serial);
	Wire.begin();
	//begin() checks the Interface, reads the sensor ID (to differentiate between BMP280 and BME280)
	//and reads compensation parameters.
	if (!bmx280.begin()){
	  Serial.println("begin() failed. check your BMx280 Interface and I2C Address.");
    while (1);
  }  
	if (bmx280.isBME280())
		Serial.println("sensor is a BME280");
	else
		Serial.println("sensor is a BMP280");

	//reset sensor to default parameters.
	bmx280.resetToDefaults();
	//by default sensing is disabled and must be enabled by setting a non-zero
	//oversampling setting.
	//set an oversampling setting for pressure and temperature measurements. 
	bmx280.writeOversamplingPressure(BMx280MI::OSRS_P_x16);
	bmx280.writeOversamplingTemperature(BMx280MI::OSRS_T_x16);
	//if sensor is a BME280, set an oversampling setting for humidity measurements.
	if (bmx280.isBME280())
		bmx280.writeOversamplingHumidity(BMx280MI::OSRS_H_x16);
}

void loop() {
  // put your main code here, to run repeatedly:
	//start a measurement
	if (!bmx280.measure()){
    Serial.println("could not start measurement, is a measurement already running?");
		return;
	}
	//wait for the measurement to finish
	do{
    delay(100);
  } 
  while (!bmx280.hasValue());
	Serial.print("Pressure: "); Serial.println(bmx280.getPressure());
	Serial.print("Pressure (64 bit): "); Serial.println(bmx280.getPressure64());
	Serial.print("Temperature: "); Serial.println(bmx280.getTemperature());
	//important: measurement data is read from the sensor in function hasValue() only. 
	//make sure to call get*() functions only after hasValue() has returned true. 
	if (bmx280.isBME280())
	{
		Serial.print("Humidity: "); 
		Serial.println(bmx280.getHumidity());
	}
  testdrawstyles();
}
void testdrawstyles(void) {
  display.clearDisplay();
  // Float Variable used to display of celcius
  float c = bmx280.getTemperature();
  // Float Variable used to display degrees farenheight. 
  float f = ((c * 9 / 5) + 32);
  display.setTextSize(1.5);             // Normal 1:1 pixel scale
  display.setTextColor(SSD1306_BLACK, SSD1306_WHITE);        // Draw RED text
  display.setCursor(0,0);             // Start at top-left corner
  display.print("Pressure:    \n     \t"); display.print(bmx280.getPressure()); display.println("\t   ");
  display.print("Pressure (64 bit): \n     \t"); display.print(bmx280.getPressure64()); display.println("\t   ");
  display.print("Temperature(C):\n     \t"); display.print(c); display.println("\t     ");
  display.print("Temperature(F):\n     \t"); display.print(f); display.println("\t     ");
  if (bmx280.isBME280())
  {
    display.print("Humidity: "); 
    display.println(bmx280.getHumidity());
  }
  // Show current info every one second
  display.display();
  delay(1000);
}
