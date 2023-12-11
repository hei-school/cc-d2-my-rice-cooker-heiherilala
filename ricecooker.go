package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

// Cooker represents the state of the rice cooker.
type Cooker struct {
	pluggedIn       bool
	recipeChosen    bool
	ingredients     map[string]int
	temperature     int
	cookingDuration int
}

// NewCooker initializes a new Cooker instance.
func NewCooker() *Cooker {
	return &Cooker{
		pluggedIn:       false,
		recipeChosen:    false,
		ingredients:     make(map[string]int),
		temperature:     0,
		cookingDuration: 0,
	}
}

// ValidateInput validates if the input can be converted to a non-negative integer.
func ValidateInput(input string) (int, error) {
	value, err := strconv.Atoi(input)
	if err != nil || value < 0 {
		return 0, fmt.Errorf("invalid input, please enter a non-negative number")
	}
	return value, nil
}

// GetUserInput prompts the user for input and validates it.
func GetUserInput(prompt string) (int, error) {
	scanner := bufio.NewScanner(os.Stdin)
	fmt.Print(prompt)
	scanner.Scan()
	return ValidateInput(scanner.Text())
}

// ShowMainMenu displays the main menu options.
func ShowMainMenu() {
	fmt.Println("Choose your action:")
	fmt.Println("1>->-> Cook rice")
	fmt.Println("2>->-> Boil water")
	fmt.Println("3>->-> Make soup")
}

// AddIngredient prompts the user to add an ingredient to the cooker.
func (c *Cooker) AddIngredient() {
	scanner := bufio.NewScanner(os.Stdin)
	for {
		fmt.Print(">->-> Ingredient (e.g., water): ")
		scanner.Scan()
		ingredient := scanner.Text()

		quantity, err := GetUserInput(">->-> Quantity in grams: ")
		if err != nil {
			fmt.Println(err)
			continue
		}

		c.ingredients[ingredient] = quantity

		fmt.Println("1>->-> Add another ingredient")
		fmt.Println("2>->-> Close the rice cooker and start cooking")
		fmt.Println("3>->-> Cancel")

		choice, err := GetUserInput("Choose an option: ")
		if err != nil {
			fmt.Println(err)
			continue
		}

		if choice == 2 {
			break
		} else if choice == 3 {
			c.CancelOperation()
			return
		}
	}
}

// StartCooking simulates the cooking process and displays the results.
func (c *Cooker) StartCooking() {
	fmt.Println("Cooking started:")
	fmt.Println("The dish is ready!")
	fmt.Println("Ingredients used:", c.ingredients)
	fmt.Println("Temperature:", c.temperature, "°C")
	fmt.Println("Duration:", c.cookingDuration, "minutes")
	c.CancelOperation()
}

// CancelOperation resets the cooker state to its initial values.
func (c *Cooker) CancelOperation() {
	c.recipeChosen = false
	c.ingredients = make(map[string]int)
	c.temperature = 0
	c.cookingDuration = 0
}

func main() {
	cooker := NewCooker()

	for {
		ShowMainMenu()

		choice, err := GetUserInput("Choose an option: ")
		if err != nil {
			fmt.Println(err)
			continue
		}

		switch choice {
		case 1, 2, 3:
			cooker.recipeChosen = true
			cooker.temperature = 100 // Assuming a default temperature of 100°C
			cooker.cookingDuration = 30 // Assuming a default cooking duration of 30 minutes
			cooker.AddIngredient()
			cooker.StartCooking()
		default:
			fmt.Println("Invalid choice. Please try again.")
		}
	}
}
