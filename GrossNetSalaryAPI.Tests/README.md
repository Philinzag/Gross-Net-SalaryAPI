## Running Tests

To ensure the correct functionality of the GrossNetSalaryAPI, unit tests are provided. Follow the steps below to run the tests:

1. **Navigate to the Test Project Directory:**
   ```bash
   cd GrossNetSalaryAPI.Tests
   ```

2. **Add the Necessary Packages:**
   Ensure you have xUnit packages added to the test project:
   ```bash
   dotnet add package xunit #only run this when using VScode
   dotnet add package xunit.runner.visualstudio
   ```

3. **Add Project Reference:**
   Ensure the test project references the main project:
   ```bash
   dotnet add reference ../GrossNetSalaryAPI/GrossNetSalaryAPI.csproj
   ```

4. **Run the Tests:**
   Use the .NET CLI to execute the tests:
   ```bash
   dotnet test
   ```

The tests will be executed, and you will see the test results in the console output.
