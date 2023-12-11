<?php

class RiceCooker
{
    private $ingredients = [];
    private $temperature;
    private $duration;

    public function __construct()
    {
        $this->resetCooker();
    }

    public function start()
    {
        $this->displayMainMenu();
    }

    private function resetCooker()
    {
        $this->ingredients = [];
        $this->temperature = null;
        $this->duration = null;
    }

    private function displayMainMenu()
    {
        echo "Main Menu:\n";
        echo "1>->-> Cook Rice\n";
        echo "2>->-> Boil Water\n";
        echo "3>->-> Make Soup\n";
        echo "0>->-> Exit\n";

        $choice = $this->getNumericInput("Choose your action");

        switch ($choice) {
            case 1:
            case 2:
            case 3:
                $this->prepareRecipe($choice);
                break;
            case 0:
                echo "Exiting...\n";
                exit;
            default:
                echo "Invalid choice. Please try again.\n";
                $this->displayMainMenu();
        }
    }

    private function prepareRecipe($recipeType)
    {
        $this->resetCooker();

        echo "Preparing recipe...\n";

        $this->addIngredients();
        $this->displayRecipeResult($recipeType);

        $this->resetCooker();
        $this->displayMainMenu();
    }

    private function addIngredients()
    {
        echo "Adding ingredients:\n";

        do {
            $ingredient = $this->getStringInput(">->-> Ingredient (e.g., water): ");
            $quantity = $this->getNumericInput(">->-> Quantity in grams: ");

            $this->ingredients[] = [
                'ingredient' => $ingredient,
                'quantity' => $quantity,
            ];

            $choice = $this->getNumericInput("1>->-> Add another ingredient\n2>->-> Finish adding ingredients\n3>->-> Cancel");

            if ($choice == 2) {
                break;
            } elseif ($choice == 3) {
                echo "Cancelling...\n";
                $this->resetCooker();
                $this->displayMainMenu();
            }
        } while (true);
    }

    private function displayRecipeResult($recipeType)
    {
        echo "Recipe Result:\n";
        echo "The dish is ready!\n";
        echo "Ingredients used:\n";
        foreach ($this->ingredients as $ingredient) {
            echo "{$ingredient['quantity']} grams of {$ingredient['ingredient']}\n";
        }
        echo "Temperature: Automatic\n";
        echo "Duration: Automatic\n";
    }

    private function getNumericInput($prompt)
    {
        do {
            $input = $this->getStringInput($prompt);
            try {
                $numericValue = filter_var($input, FILTER_VALIDATE_FLOAT);
                if ($numericValue !== false && $numericValue >= 0) {
                    return $numericValue;
                } else {
                    throw new Exception("Invalid input. Please enter a non-negative number.");
                }
            } catch (Exception $e) {
                echo "Error: " . $e->getMessage() . "\n";
            }
        } while (true);
    }

    private function getStringInput($prompt)
    {
        do {
            echo "$prompt: ";
            $input = trim(fgets(STDIN));

            if ($input === false) {
                echo "Invalid input. Please try again.\n";
            } else {
                return $input;
            }
        } while (true);
    }
}

$riceCooker = new RiceCooker();
$riceCooker->start();

?>
