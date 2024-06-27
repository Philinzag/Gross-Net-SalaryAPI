### README.md


# GrossNetSalaryAPI

This project is a .NET 8.0 Web API that calculates gross salary, basic salary, PAYE tax, and pension contributions based on a desired net salary and allowances.

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/GrossNetSalaryAPI.git
   cd GrossNetSalaryAPI
   ```

2. **Restore the dependencies:**

   ```bash
   dotnet restore
   ```

### Running the Application

1. **Run the application:**

   ```bash
   dotnet run --project GrossNetSalaryAPI
   ```

   By default, the application will be available at `http://localhost:5150`.

2. **Access Swagger UI (for API documentation and testing):**

   If running in development mode, Swagger UI will be available at `http://localhost:5150/swagger`.

### Using the API

You can use Postman or any other API client to interact with the API. Below is an example of how to send a POST request to calculate the gross salary.

- **Endpoint:** `POST /api/salary`
- **URL:** `http://localhost:5150/api/salary`
- **Body:** Raw JSON

### Example Post

```json
{
  "desiredNetSalary": 1000,
  "allowances": 200
}
```

### Example Response

```json
{
  "grossSalary": 1535,
  "basicSalary": 1335,
  "totalAllowances": 200,
  "payeTax": 66.45,
  "employeePensionContribution": 139.25,
  "employerPensionContribution": 239.25
}
```

### Project Structure

- **Controllers**
  - `SalaryController.cs`: Handles the API requests for salary calculations.
- **Models**
  - `SalaryDetails.cs`: Represents the details of the salary.
  - `SalaryRequest.cs`: Represents the request payload for salary calculations.
- **Services**
  - `SalaryCalculator.cs`: Contains the logic for calculating the gross salary, PAYE tax, and pension contributions.

### Running Unit Tests

Unit tests are included in the `GrossNetSalaryAPI.Tests` project. To run the tests:

1. **Navigate to the test project directory:**

   ```bash
   cd GrossNetSalaryAPI.Tests
   ```

2. **Run the tests:**

   ```bash
   dotnet test
   ```
