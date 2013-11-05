#include <TimerOne.h>
#include <SoftwareSerial.h>

#define rxPin 0
#define txPin 1

SoftwareSerial usb =  SoftwareSerial(rxPin, txPin);

String software = "mfloppy3";
String inStr = "";

float currentFrequency[] = {0, 0, 0};

int floppyCount = 2; //0-Indexed !!!!
boolean enabled = true;

//Time helpers
long previousMicrosFrequency[] = { 0, 0, 0 };
long currentMicros = 0;

//Hardware related helpers
int currentStep[] = { 0, 0, 0 }; //tracking steps of read-arm (max 80 in one direction)
boolean currentDirection[] = { false, false, false }; //tracking location of the read-arm false:forward true:backwards (false no shortcut circuit; true -> shortcut
boolean backToZero[] = { false, false, false };

char chr;

void setup()
{ 
  pinMode(2,OUTPUT);
  pinMode(3,OUTPUT);
  pinMode(4,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(6,OUTPUT);
  pinMode(7,OUTPUT);
  pinMode(13,OUTPUT);
  digitalWrite(13, LOW);
  //Timer1.initialize(40);
  //Timer1.attachInterrupt(calcFrequencies);
  usb.begin(9600);
  previousMicrosFrequency[0] = micros();
  previousMicrosFrequency[1] = micros();
  previousMicrosFrequency[2] = micros();
}

void calcFrequencies()
{
  //Frequency calculation
  currentMicros = micros();
  
  //Floppy 1
  if(currentFrequency[0] != 0)
  {
    if(currentMicros - previousMicrosFrequency[0] > ((1000 / currentFrequency[0]) * 1000))
    {
      digitalWrite(2,HIGH);   
      digitalWrite(2,LOW);
      previousMicrosFrequency[0] = currentMicros;
      if(currentDirection[0] == false)
      {
        ++currentStep[0];
        checkStepper(0);
      }
      else
      {
        --currentStep[0];
        checkStepper(0);
      }
    }
  }
  
  //Floppy 2
  if(currentFrequency[1] != 0)
  {
    if(currentMicros - previousMicrosFrequency[1] > ((1000 / currentFrequency[1]) * 1000))
    {
      digitalWrite(4,HIGH);   
      digitalWrite(4,LOW);
      previousMicrosFrequency[1] = currentMicros;
      if(currentDirection[1] == false)
      {
        ++currentStep[1];
        checkStepper(1);
      }
      else
      {
        --currentStep[1];
        checkStepper(1);
      }
    }
  }
  
   //Floppy3
  if(currentFrequency[2] != 0)
  {
    if(currentMicros - previousMicrosFrequency[2] > ((1000 / currentFrequency[2]) * 1000))
    {
      digitalWrite(6,HIGH);   
      digitalWrite(6,LOW);
      previousMicrosFrequency[2] = currentMicros;
      if(currentDirection[2] == false)
      {
        ++currentStep[2];
        checkStepper(2);
      }
      else
      {
        --currentStep[2];
        checkStepper(2);
      }
    }
  }
}

void loop()
{
  if(usb.available() > 0)
  {
      while(usb.available() > 0)
      {
        chr = (char)usb.read();
        calcFrequencies();
        if(chr != ';')
        { 
          inStr += chr;
        }
        else break;
      }
      
      if(inStr.startsWith("0"))
      {
        String freqStr = inStr.substring(2);
        
        char freqChrArray[freqStr.length() + 1]; 
        freqStr.toCharArray(freqChrArray, sizeof(freqChrArray)); 
        float freq = atof(freqChrArray); 
        
        setFrequency(0, freq);
        calcFrequencies();
      }
      else if(inStr.startsWith("1"))
      {
        String freqStr = inStr.substring(2);
        
        char freqChrArray[freqStr.length() + 1]; 
        freqStr.toCharArray(freqChrArray, sizeof(freqChrArray)); 
        float freq = atof(freqChrArray); 
        
        setFrequency(1, freq);
        calcFrequencies();
      }
      else if(inStr.startsWith("2"))
      {
        String freqStr = inStr.substring(2);
        
        char freqChrArray[freqStr.length() + 1]; 
        freqStr.toCharArray(freqChrArray, sizeof(freqChrArray)); 
        float freq = atof(freqChrArray); 
        
        setFrequency(2, freq);
        calcFrequencies();
      }
      else if(inStr == "software?")
      {
        usb.println("software:" + software);
      }
      else if(inStr == "test")
      {
        test();
      }
      else if(inStr.startsWith("backtozero"))
      {
        goBackToZero();
      }
      
      
      inStr = "";
  }
  
  calcFrequencies();
}

void setFrequency(int floppy, float frequency)
{
  currentFrequency[floppy] = frequency;
}

void checkStepper(int fdd) // Stepper-direction calculation
{
  if(currentStep[fdd] == 0 || currentStep[fdd] == 80)
  {
    currentDirection[fdd] = !currentDirection[fdd];
    if(currentDirection[fdd] == false)
    {
      if(fdd == 0)
      {
        digitalWrite(3,LOW);
      }
      else if(fdd == 1)
      {
        digitalWrite(5,LOW);
      }
      else if(fdd == 2)
      {
        digitalWrite(7,LOW);
      }
    }
    else
    {
      if(fdd == 0)
      {
        digitalWrite(3,HIGH);
      }
      else if(fdd == 1)
      {
        digitalWrite(5,HIGH);
      }
      else if(fdd == 2)
      {
        digitalWrite(7,HIGH);
      }
    }
  }
}

void goBackToZero()
{
  //FIRST FDD
  digitalWrite(3,HIGH);
  for(int i = 0; i < currentStep[0]; i++)
  {
    digitalWrite(2,HIGH);
    delay(3);
    digitalWrite(2,LOW);
  }
  backToZero[0] = true;
  
  //SECOND FDD
  digitalWrite(5,HIGH);
  for(int i = 0; i < currentStep[1]; i++)
  {
    digitalWrite(4,HIGH);
    delay(3);
    digitalWrite(4,LOW);
  }
  backToZero[1] = true;
  
  //THIRD FDD
  digitalWrite(7,HIGH);
  for(int i = 0; i < currentStep[2]; i++)
  {
    digitalWrite(6,HIGH);
    delay(3);
    digitalWrite(6,LOW);
  }
  backToZero[2] = true;
}

void test() // Full once forward and once backward test
{
  digitalWrite(3,LOW);
  digitalWrite(5,LOW);
  digitalWrite(7,LOW);
  for(int i = 0; i < 80; i++)
  {
    digitalWrite(2,HIGH);
    digitalWrite(4,HIGH);
    digitalWrite(6,HIGH);
    delay(3);
    digitalWrite(2,LOW);
    digitalWrite(4,LOW);
    digitalWrite(6,LOW);
  }
  digitalWrite(3,HIGH);
  digitalWrite(5,HIGH);
  digitalWrite(7,HIGH);
  for(int i = 0; i < 80; i++)
  {
    digitalWrite(2,HIGH);
    digitalWrite(4,HIGH);
    digitalWrite(6,HIGH);
    delay(3);
    digitalWrite(2,LOW);
    digitalWrite(4,LOW);
    digitalWrite(6,LOW);
  }
}
