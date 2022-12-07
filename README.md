## UPI Based Payment App using Xamarin.Forms + Prism.Unity

Payment app UI developped using Xamarin.Forms and Prism MVVM library

> **Note:** The original design comes from [intelegain.com > UPI Based Payment App](https://www.intelegain.com/uxsense/upi-based-payment-app/)

![alt text](https://github.com/ValdesChe/UPI_Based_Payment_App-Xamarin.Forms/blob/main/screen/screen_illustration.png) 

## Description

This is the project structure :

```
  UPIBasedPayementApp.Core/
    Views/
    Models/
    ViewModels/
    Services/
    Controls/
    App.xaml
    App.xaml.cs
  UPIBasedPayementApp.Android/
  UPIBasedPayementApp.IOS/
```

## Core

It's the shared code between the differents platform ( Windows Phone, Android, iOS, ...)
The Core folder contains two main files :

### Views

All the screens/pages/fragments for your app.

### Models

Contains the C# classes you'll manipulate in the Views and ViewModels

### ViewModels

Contains your ViewModels. A viewModel basically handles all interactions such as button clicks and data updates on the UI.
Contains a **BaseViewMode.cs** class.

### Services

The classes responsible of the API calls or direct interaction with the data sources

### Controls

Where you store the custom widgets you'll create

# Author

[< @ValdoR />](https://www.twitter.com/Valdes_Che/)
