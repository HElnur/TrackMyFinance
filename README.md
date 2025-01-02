# MyTrackFinance

**MyTrackFinance** is a simple API project designed to help users manage and track their finances effectively. The API provides endpoints for handling users, transactions, categories, and reports, making it easy for developers to integrate personal finance functionalities into their applications.

## Features

- **User Management**: Create and manage user profiles.
- **Transaction Handling**: Add, view, update, and delete financial transactions.
- **Category Management**: Organize transactions into customizable categories.
- **Report Generation**: Generate reports to analyze income, expenses, and overall financial performance.
- **Type Handling**: Manage transaction types such as income or expense.
- **RESTful Endpoints**: Follows RESTful principles for easy integration.

## Technologies Used

- **Programming Language**: C#
- **Framework**: ASP.NET Core
- **Database**: SQLite (or any preferred relational database)
- **Environment**: .NET 6.0 or higher

## Prerequisites

1. **.NET SDK**: Install the latest version of .NET SDK from [here](https://dotnet.microsoft.com/download).
2. **Database**: Configure a SQLite database or any other supported database.
3. **Git**: Ensure Git is installed for cloning the repository.

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/HElnur/TrackMyFinance.git
cd TrackMyFinance
```

### Configure the Database

1. Open `appsettings.json`.
2. Update the connection string to point to your database.

Example:
```json
"ConnectionStrings": {
    "Default": "Data Source=MyTrackFinance.db"
}
```

### Run the Project

1. Restore dependencies:
```bash
dotnet restore
```
2. Apply migrations:
```bash
dotnet ef database update
```
3. Run the application:
```bash
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## API Endpoints

### User Endpoints
- **GET** `/api/users` - Retrieve all users.
- **POST** `/api/users` - Create a new user.
- **PUT** `/api/users/{id}` - Update user information.
- **DELETE** `/api/users/{id}` - Delete a user.

### Transaction Endpoints
- **GET** `/api/transactions` - Retrieve all transactions.
- **POST** `/api/transactions` - Add a new transaction.
- **PUT** `/api/transactions/{id}` - Update a transaction.
- **DELETE** `/api/transactions/{id}` - Delete a transaction.

### Category Endpoints
- **GET** `/api/categories` - Retrieve all categories.
- **POST** `/api/categories` - Add a new category.
- **PUT** `/api/categories/{id}` - Update a category.
- **DELETE** `/api/categories/{id}` - Delete a category.

### Report Endpoints
- **GET** `/api/reports` - Generate and view reports.

### Type Endpoints
- **GET** `/api/types` - Retrieve all transaction types.
- **POST** `/api/types` - Add a new transaction type.
- **PUT** `/api/types/{id}` - Update a transaction type.
- **DELETE** `/api/types/{id}` - Delete a transaction type.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

### Steps to Contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeatureName`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeatureName`).
5. Open a pull request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

## Contact

For questions or feedback, feel free to contact:
- **Name**: Elnur
- **Email**: elnurhsynz@gmail.com
- **GitHub**: [Your GitHub Profile](https://github.com/HElnur)

