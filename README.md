# Rice Cooker CLI Application

## Prerequisites
Before running this application, ensure that you have the following installed on your machine:
- Kotlin (You can download it from [kotlinlang.org](https://kotlinlang.org/))

## Description
The Rice Cooker CLI Application is a simple command-line program written in Kotlin that simulates a rice cooker. It allows users to choose recipes, add ingredients, and automatically calculates temperature and duration for cooking.

## Installation
1. Clone the repository:


2. Build the project using Kotlin:

    ```bash
    kotlinc -include-runtime -d rice-cooker.jar src/*.kt
    ```
    

## Execution

Run the application using the following command:

kotlin rice-cooker.jar

## Coding Standards (CS)

This project follows the Kotlin Coding Conventions. Some key points include:

    Use of camelCase for variable and function names.
    Indentation with four spaces.
    Braces on a new line for functions and control structures.

## Linter Used

The project utilizes ktlint as a linter for Kotlin code. Make sure to run ktlint before committing changes:

    ktlint src/**/*.kt