# Bangladesh Electricity Bill Calculator

## Project Description

The **Bangladesh Electricity Bill Calculator** is a small C# application developed for the CSE 4874 — IT Project Management Lab.

The application calculates an estimated monthly electricity bill based on the number of electricity units consumed.

The project uses a simplified electricity pricing model:

| Monthly Usage   |            Rate |
| --------------- | --------------: |
| First 50 units  |  BDT 5 per unit |
| Next 50 units   |  BDT 7 per unit |
| Remaining units | BDT 10 per unit |

The application also validates electricity usage. Negative unit values are considered invalid and result in an `ArgumentException`.

### Example Calculations

| Units | Expected Bill |
| ----: | ------------: |
|     0 |         BDT 0 |
|    10 |        BDT 50 |
|    50 |       BDT 250 |
|    60 |       BDT 320 |
|   100 |       BDT 600 |
|   120 |       BDT 800 |

The main purpose of this project is to demonstrate **project automation, Continuous Integration (CI), automated testing, code formatting, documentation validation, and release packaging using GitHub Actions**.

---

## Programming Language and Framework

* **Programming Language:** C#
* **Framework:** .NET 10
* **Test Framework:** xUnit
* **Automation Platform:** GitHub Actions
* **Code Formatting Tool:** `dotnet format`
* **Operating System:** Cross-platform

---

## Project Structure

```text
ElectricityBillAutomation/
│
├── .github/
│   └── workflows/
│       ├── develop-ci.yml
│       ├── pull-request-check.yml
│       ├── formatting-check.yml
│       ├── documentation-check.yml
│       └── release-package.yml
│
├── ElectricityBillCalculator/
│   ├── Class1.cs
│   └── ElectricityBillCalculator.csproj
│
├── ElectricityBillCalculator.Tests/
│   ├── UnitTest1.cs
│   └── ElectricityBillCalculator.Tests.csproj
│
├── ElectricityBillAutomation.sln
├── README.md
└── .gitignore
```

---

## Prerequisites

Before running the project, install:

1. Git
2. .NET SDK 10
3. Visual Studio Code, Visual Studio, or another code editor
4. A GitHub account

Check the installed versions:

```bash
git --version
dotnet --version
```

---



Clone the repository:

```bash
git clone https://github.com/EsmotaraEmm/ElectricityBillAutomation.git
```

Go to the project directory:

```bash
cd ElectricityBillAutomation
```

Restore the project dependencies:

```bash
dotnet restore
```

---

## Build the Project

To build the project, run:

```bash
dotnet build
```

For a Release build:

```bash
dotnet build --configuration Release
```

A successful build indicates that the project compiles without errors.

---

## Running the Automated Tests

The project uses **xUnit** for automated testing.

Run all tests with:

```bash
dotnet test
```

The tests verify actual electricity bill calculation behavior.

The project contains tests for:

* Zero electricity usage
* Ten units
* Sixty units
* One hundred twenty units
* Negative electricity usage

For example:

```csharp
Assert.Equal(320, result);
```

checks whether the calculated bill for 60 units is BDT 320.

The tests should complete successfully with no failed tests when the application code is correct.

---

## Code Formatting

This project uses the standard .NET formatting tool:

```bash
dotnet format
```

To check whether the project follows the required formatting rules without changing files:

```bash
dotnet format --verify-no-changes
```

The `Code Formatting Check` GitHub Actions workflow automatically runs this verification when code is pushed to the `develop` branch.

If formatting problems are detected, the workflow fails.

---

# GitHub Actions Automation

This project uses GitHub Actions to automate building, testing, code formatting, documentation validation, and release packaging.

All workflow files are stored in:

```text
.github/workflows/
```

## 1. Development CI

**Workflow:** `develop-ci.yml`

**Trigger:** Push to the `develop` branch.

The Development CI workflow:

1. Checks out the source code.
2. Sets up .NET 10.
3. Restores dependencies.
4. Builds the project.
5. Runs all automated tests.

Its purpose is to detect build or test problems during development.

---

## 2. Main Branch Quality Gate

**Workflow:** `pull-request-check.yml`

**Trigger:** Pull request targeting the `main` branch.

The workflow:

1. Sets up the .NET environment.
2. Restores dependencies.
3. Builds the project.
4. Runs the automated tests.
5. Reports failure if the build or tests fail.

The `main` branch represents the stable version of the project.

Changes should be developed on the `develop` branch and proposed to `main` using a pull request.

---

## 3. Code Formatting Check

**Workflow:** `formatting-check.yml`

**Trigger:** Push to the `develop` branch.

The workflow uses:

```bash
dotnet format --verify-no-changes
```

It checks whether the source code follows the required .NET formatting rules.

The workflow:

* Succeeds when the code is correctly formatted.
* Fails when formatting or code-style problems are detected.

An intentional formatting violation was tested to demonstrate a failed workflow execution. After correcting the violation, the workflow was successfully executed again.

---

## 4. Documentation Check

**Workflow:** `documentation-check.yml`

**Trigger:** Push to the `main` branch.

The Documentation Check workflow verifies that:

* `README.md` exists.
* `README.md` is not empty.
* The README contains the required project information.
* Required documentation sections are present.

The required documentation includes:

* Project title
* Project description
* Programming language/framework
* Installation or build instructions
* Testing instructions
* GitHub Actions workflow description

The workflow reports failure if a required documentation condition is not satisfied.

---

## 5. Release Package

**Workflow:** `release-package.yml`

**Trigger:** A version tag is pushed to GitHub.

The release workflow:

1. Checks out the source code.
2. Sets up .NET 10.
3. Restores dependencies.
4. Builds the project in Release configuration.
5. Runs the automated tests.
6. Creates a release package.
7. Uploads the package as a GitHub Actions artifact.

### Creating a Version Tag

To create a version tag:

```bash
git tag v1.0.0
```

Push the tag to GitHub:

```bash
git push origin v1.0.0
```

After the tag is pushed, the release workflow starts automatically.

The generated release package is available in the GitHub Actions workflow artifacts.

---

# Development Workflow

The project follows a branch-specific development process.

```text
Feature / Development Changes
            ↓
       develop branch
            ↓
     Development CI
            ↓
     Build + Automated Tests
            ↓
    Pull Request to main
            ↓
 Main Branch Quality Gate
            ↓
        main branch
```

The `develop` branch is used for ongoing development.

The `main` branch represents stable project code.

---

# GitHub Actions Summary

| Task   | Workflow                  | Trigger                | Purpose                 |
| ------ | ------------------------- | ---------------------- | ----------------------- |
| Task 1 | `develop-ci.yml`          | Push to `develop`      | Build and test          |
| Task 2 | `pull-request-check.yml`  | Pull request to `main` | Quality gate            |
| Task 3 | `formatting-check.yml`    | Push to `develop`      | Check code formatting   |
| Task 4 | `documentation-check.yml` | Push to `main`         | Validate README         |
| Task 5 | `release-package.yml`     | Version tag            | Build, test and package |

---

# Task Demonstration

The project demonstrates the required GitHub Actions behavior.

### Task 1 — Automated Build and Test

* Successful build and test workflow demonstrated.
* An intentional application error was introduced to demonstrate a failed test workflow.
* The error was corrected and the workflow succeeded again.

### Task 2 — Main Branch Quality Gate

* Pull request targeting the `main` branch is checked automatically.
* The project must build and all automated tests must pass before merging.

### Task 3 — Code Formatting Check

* Successful formatting workflow demonstrated.
* An intentional formatting violation caused the workflow to fail.
* The formatting violation was corrected.
* The workflow succeeded after correction.

### Task 4 — Documentation Check

* README documentation is automatically checked on pushes to `main`.
* Missing or incomplete documentation causes the workflow to fail.

### Task 5 — Automated Release Package

* A version tag triggers the release workflow.
* The project is built and tested.
* A distributable package is generated.
* The package is uploaded as a GitHub Actions artifact.

---

# Repository

GitHub Repository:

https://github.com/EsmotaraEmm/ElectricityBillAutomation

The repository contains the complete project source code, automated tests, README documentation, and GitHub Actions workflows required for Lab 4.

---

# Conclusion

This project demonstrates how GitHub Actions can automate important software development activities.

The implemented automation helps detect build errors, test failures, formatting problems, documentation problems, and release preparation issues automatically.

The project therefore demonstrates the practical use of **Continuous Integration and branch-specific project automation using C#, .NET, Git, GitHub, and GitHub Actions**.
