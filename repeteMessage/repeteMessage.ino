
void setup() {
  // put your setup code here, to run once:
  Serial.begin(2000000);
  pinMode(12, INPUT_PULLUP);
}

void loop() {
  // put your main code here, to run repeatedly:
  unsigned long t0 = 0;
  unsigned long t1 = 0;
  int reset = 0;
  while(true)
  {      
      int p1 = digitalRead(12);
      if(p1 == 1)
      {
        reset = 0;
      }
      //Serial.println(p1);
      if(p1 == 0 && reset == 0)
      {
          reset = 1;
          t0 = micros();
          Serial.print(1);
          while(true)
          {
            int val = analogRead(14);
            //Serial.println(val);
            //Keyboard.write(13);
            if (val < 150)
            {
                t1 = micros();
                t1 = t1 - t0;
                Serial.print(t1);
                break;
            }
          }
      }
  }
}
