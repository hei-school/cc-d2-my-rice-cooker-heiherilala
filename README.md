# Rice Cooker Simulation

## Prerequisites

- [Go](https://golang.org/) installed on your machine.

## Description

This project is a command-line application written in Go that simulates a rice cooker. Users can choose recipes, add ingredients, and initiate the cooking process. The application follows object-oriented programming principles, utilizes a clean code structure, and employs error handling with try-catch patterns.

## Installation

1. Clone the repository:

2. Change into the project directory:
    cd rice-cooker

## Execution

Run the following command to execute the rice cooker simulation:
    go run ricecooker.go

Follow the on-screen instructions to choose a recipe, add ingredients, and start the cooking process.

## Coding Standard

The code adheres to standard Go coding conventions, including proper naming conventions, structuring, and idioms. It follows the recommendations provided in the official Effective Go document.

## Linter


The project uses golangci-lint as a linter to ensure code quality and adherence to coding standards. Install it using the following command:

    go install github.com/golangci/golangci-lint/cmd/golangci-lint

Run the linter with:

    golangci-lint run