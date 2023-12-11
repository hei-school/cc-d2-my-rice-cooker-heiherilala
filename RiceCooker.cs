using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        RiceCooker riceCooker = new RiceCooker();

        while (true)
        {
            Console.WriteLine("Choisir votre action:");
            Console.WriteLine("1>->-> Riz");
            Console.WriteLine("2>->-> Eau chaude");
            Console.WriteLine("3>->-> Soupe");
            Console.WriteLine("4>->-> Quitter");

            string choice = GetUserInput("Entrez votre choix:");

            switch (choice)
            {
                case "1":
                    riceCooker.PrepareRecipe("Riz");
                    break;
                case "2":
                    riceCooker.PrepareRecipe("Eau chaude");
                    break;
                case "3":
                    riceCooker.PrepareRecipe("Soupe");
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
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
        Console.WriteLine($"Préparation de {recipe}");
        Console.WriteLine("1>->-> Ouvrir le rice-cooker et ajouter des ingrédients");
        Console.WriteLine("2>->-> Annuler");

        string choice = GetUserInput("Entrez votre choix:");

        switch (choice)
        {
            case "1":
                AddIngredients();
                break;
            case "2":
                Console.WriteLine("Opération annulée. Retour au menu principal.");
                break;
            default:
                Console.WriteLine("Choix invalide. Veuillez réessayer.");
                break;
        }
    }

    private void AddIngredients()
    {
        do
        {
            Console.WriteLine("Ajout d'ingrédient:");
            string ingredientName = GetUserInput(">->-> Ingrédient (ex: eau):");

            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                Console.WriteLine("Le nom de l'ingrédient ne peut pas être vide. Veuillez réessayer.");
                continue;
            }

            int quantity;
            if (!TryGetPositiveNumber("Quantité en gramme:", out quantity))
            {
                continue;
            }

            ingredients.Add(new Ingredient { Name = ingredientName, Quantity = quantity });

            Console.WriteLine("1>->-> Ajouter un autre ingrédient");
            Console.WriteLine("2>->-> Fermer le rice-cooker et démarrer la préparation");
            Console.WriteLine("3>->-> Annuler");

            string choice = GetUserInput("Entrez votre choix:");

            switch (choice)
            {
                case "1":
                    break;
                case "2":
                    DisplayResult();
                    return;
                case "3":
                    Console.WriteLine("Opération annulée. Retour à l'ajout d'ingrédient.");
                    ingredients.Clear();
                    return;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }

        } while (true);
    }

    private void DisplayResult()
    {
        Console.WriteLine("Résultat de la préparation:");
        Console.WriteLine("Le plat est prêt");
        Console.WriteLine("Liste d'ingrédients:");

        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity}g");
        }

        Console.WriteLine("Retour au menu principal. Opérations annulées.");
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

            Console.WriteLine("Veuillez entrer un nombre positif. Veuillez réessayer.");

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
