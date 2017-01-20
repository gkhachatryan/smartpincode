## Smart PinCode

This C# library will help you to generate random pincodes.

## How to use
Below is shown how to use PinCode class to generate pincodes.
```cs
int pinCodeLength = 25;
PinCode pinCode = new PinCode(pinCodeLength, PinCodeType.AlphaNumericWithSymbols);
string newPinCode = pinCode.Generate(); 

int pinlenght = 15;
PinCode pin = new PinCode(pinlenght, PinCodeType.Numeric);
string newpin = pin.Generate();
```

## Installation

[Here](https://drive.google.com/open?id=0B7sfm4Wtr1psem5wZDVDdmhhMWc) is standalone .dll file.

You can clone it with this link https://github.com/gkhachatryan/smartpincode.git

## Result

