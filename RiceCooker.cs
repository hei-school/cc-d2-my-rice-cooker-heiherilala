using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var riceCooker = new RiceCooker();

        while (true)
        {
            Console.WriteLine("Choose your action:");
            Console.WriteLine("1>->-> Rice");
            Console.WriteLine("2>->-> Hot Water");
            Console.WriteLine("3>->-> Soup");
            Console.WriteLine("4>->-> Quit");

            string choice = GetUserInput("Enter your choice:");

            switch (choice)
            {
                case "1":
                    riceCooker.PrepareRecipe("Rice");
                    break;
                case "2":
                    riceCooker.PrepareRecipe("Hot Water");
                    break;
                case "3":
                    riceCooker.PrepareRecipe("Soup");
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static string GetUserInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }
}

class RiceCooker
{
    private List<Ingredient> ingredients = new List<Ingredient>();

    public void PrepareRecipe(string recipe)
    {
        Console.WriteLine($"Preparing {recipe}");
        Console.WriteLine("1>->-> Open the rice-cooker and add ingredients");
        Console.WriteLine("2>->-> Cancel");

        string choice = GetUserInput("Enter your choice:");

        switch (choice)
        {
            case "1":
                AddIngredients();
                break;
            case "2":
                Console.WriteLine("Operation canceled. Back to the main menu.");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private void AddIngredients()
    {
        do
        {
            Console.WriteLine("Add Ingredient:");
            string ingredientName = GetUserInput(">->-> Ingredient (e.g., water):");

            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                Console.WriteLine("Ingredient name cannot be empty. Please try again.");
                continue;
            }

            int quantity;
            if (!TryGetPositiveNumber("Quantity in grams:", out quantity))
            {
                continue;
            }

            ingredients.Add(new Ingredient { Name = ingredientName, Quantity = quantity });

            Console.WriteLine("1>->-> Add another ingredient");
            Console.WriteLine("2>->-> Close the rice-cooker and start cooking");
            Console.WriteLine("3>->-> Cancel");

            string choice = GetUserInput("Enter your choice:");

            switch (choice)
            {
                case "1":
                    break;
                case "2":
                    DisplayResult();
                    return;
                case "3":
                    Console.WriteLine("Operation canceled. Back to adding ingredients.");
                    ingredients.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (true);
    }

    private void DisplayResult()
    {
        Console.WriteLine("Cooking Result:");
        Console.WriteLine("The dish is ready");
        Console.WriteLine("List of Ingredients:");

        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity}g");
        }

        Console.WriteLine("Back to the main menu. Operations canceled.");
        ingredients.Clear();
    }

    private bool TryGetPositiveNumber(string prompt, out int result)
    {
        do
        {
            string input = GetUserInput(prompt);

            if (int.TryParse(input, out result) && result >= 0)
            {
                return true;
            }

            Console.WriteLine("Please enter a positive number. Please try again.");

        } while (true);
    }

    private string GetUserInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }
}

class Ingredient
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}
