#World Thunder Technologies

Elbette, işte README dosyanızın İngilizce çevirisi:

World Thunder Technologies
The World Thunder Technologies project aims to create an e-commerce site serving the technology sector.
This project is shaped by the continuous advancement of technological devices and the corresponding increase in demand.
It aims to provide users with a secure shopping environment and ensure they can easily access the products they are looking for.

#Features
Categories: Products can be listed through various categories such as Phones, Computers, TVs, Visuals, Audio, Computer Parts, Home, Kitchen, Office Supplies.
Shopping Cart: Users can add their favorite products to the cart and make purchases.
User Account: Users are required to register or log in during the purchase process.
Payment Processing: Card information and delivery address details are collected, stock status is checked, and products are shipped.
Order Tracking: Users can view their orders.
Product Reviews: Users can leave reviews on products, and view the number of reviews and average ratings.
Contact: Users can send messages to admins via the Contact page.
Admin Panel: Admins can add, update, or remove products, check stock and order statuses, and manage messages from the Contact page and product reviews.

#Setup
1-Email Configuration: The appsettings.json file must be configured with the correct email address and password for sending email confirmation messages.
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "EmailSender": {
    "Host": "smtp.office365.com",
    "Port": 587,
    "EnableSSL": true,
    "UserName": "",
    "Password": ""
  },
  "Data": { 
    "AdminUser": {
      "username": "admin",
      "password": "Wtt_001738",
      "email": "wttadminuser@gmail.com",
      "role": "admin"
    }
  }, 
  "AllowedHosts": "*"
}

2- Payment Integration: To enable shopping with İyzipay, create a developer account on İyzipay and then enter the ApiKey and SecretKey into the PaymentProcess method in the CartController.
{
    Options options = new Options();
    options.ApiKey = "";
    options.SecretKey = "";
    options.BaseUrl = "https://sandbox-api.iyzipay.com";
    // devam eden kod...
}

#Usage
For admin login, you can use the following AdminUser credentials:
Username: admin
Password: Wtt_001738
Email: wttadminuser@gmail.com
