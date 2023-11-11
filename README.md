# BirdPlatform App

BirdPlatform is a web application that serves as a platform connecting customers and service providers in the bird-related industry. Whether you're looking for birdwatching tours, birdhouse building services, or other avian-related activities, BirdPlatform is your one-stop solution. This project is built using ASP.NET Core 6 with Razor Pages and follows a 3-layer architecture.

## Features

- **Customer Portal**: 
  - Explore a variety of bird-related services.
  - View details of services, providers, and customer reviews.
  - Book services of your choice.

- **Provider Dashboard**:
  - Manage services offered.
  - Update service details and availability.
  - Receive and manage booking requests.

- **Administrator Dashboard**:
  - Manage user accounts and roles.
  - Review and moderate service listings and reviews.
  - Monitor the overall platform activity.

## Technologies Used

- **ASP.NET Core 6**: The framework for building the web application.
- **Razor Pages**: For creating dynamic web pages.
- **SQL Server**: As the database to store user data, service listings, and reviews.
- **Entity Framework Core**: For data access and management.
- **C#**: The primary programming language.
- **HTML/CSS/JavaScript**: For front-end development and interactivity.
- **3-Layer Architecture**: Organizing the application into presentation, business, and data layers for separation of concerns and maintainability.

## Getting Started

1. Clone the repository:
git clone https://github.com/yourusername/BirdPlatformApp.git
cd BirdPlatformApp

2. Install dependencies:
dotnet restore

3. Configure your SQL Server connection in `appsettings.json`.

4. Apply database migrations:
dotnet ef database update

5. Run the application:
dotnet run

6. Access the application in your web browser at `http://localhost:5000`.

## Screenshots

![Screenshot 1](screenshots/screenshot1.png)

![Screenshot 2](screenshots/screenshot2.png)

## Contributing

If you want to contribute to this project, feel free to open issues or pull requests.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgments

- Special thanks to our team for their hard work in building BirdPlatform App.
- Icon made by [Freepik](https://www.freepik.com) from [www.flaticon.com](https://www.flaticon.com).
