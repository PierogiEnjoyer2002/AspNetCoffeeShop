# ☕ CoffeeShop – Online Coffee Store

## Overview
CoffeeShop is a modern online coffee store built using **ASP.NET Core**. The platform allows users to browse and purchase various coffee products while providing administrators with tools to manage inventory and orders.

## Features
- **User-Friendly Shopping Experience**
  - Browse coffee varieties with filtering options
  - Add products to cart and place orders
  
- **Secure User Authentication**
  - User registration and login functionality
  
- **Administrator Dashboard**
  - Manage coffee products, categories, and orders
  

## How It Works
1. **Users browse the store** to discover available coffee products.
2. **They add items to the cart** and proceed to checkout.
3. **Administrators manage orders** and inventory through the dashboard.

## Technologies Used
- **Backend:** ASP.NET Core, Entity Framework Core
- **Frontend:** Razor Pages, BootStrap
- **Database:** SQL Server

## Installation & Setup
### Clone the Repository
```sh
   git clone github.com/PierogiEnjoyer2002/AspNetCoffeeShop
   cd AspNetCoffeeShop
```
### Install Dependencies
```sh
   dotnet restore
```
### Configure Database
Edit `appsettings.json` to set up the database connection.

### Apply Migrations & Initialize Database
```sh
   dotnet ef database update
```
### Run the Application
```sh
   dotnet run
```

## Configuration
Settings can be customized in `appsettings.json`, including:
- Database connection
- API keys for payment gateways
- Application-specific settings

## Screenshots
![Image](https://github.com/user-attachments/assets/a1659065-f180-4565-a2eb-c76433c54ee5)
![Image](https://github.com/user-attachments/assets/7fffb04e-64b3-4423-9e74-adc647e9eb9f)
![Image](https://github.com/user-attachments/assets/a584dd78-833f-4b36-99d3-b8e28034bcfa)

## Challenges and Solutions
- **Performance Optimization:** Improved database queries for faster loading times.

## Future Improvements
- Enhance the recommendation system for personalized coffee suggestions.
- Introduce a loyalty rewards program.
- Expand support for additional payment gateways.

## Authors
- **[Kamil Wojnarski](https://github.com/PierogiEnjoyer2002)** 

## License
This project is open-source and available for educational use.

## Contact
Have questions? Open an issue or reach out via email at [kamil.piotr.wojnarski@gmail.com](mailto:kamil.piotr.wojnarski@gmail.com).

