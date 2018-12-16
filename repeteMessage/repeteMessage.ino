void setup() {
  // put your setup code here, to run once:
  Serial.begin(2000000);
}

void loop() {
  // put your main code here, to run repeatedly:
  while(true)
  {
    if (Serial.available() > 0)
    {
        int b = Serial.read();
        Serial.println(b);
    }
  }
}
