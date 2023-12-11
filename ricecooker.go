package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

// Cooker represents the state of the rice cooker.
type Cooker struct {
	PluggedIn       bool
	RecipeChosen    bool
	Ingredients     map[string]int
	Temperature     int
	CookingDuration int
}

// NewCooker initializes a new Cooker instance.
func NewCooker() *Cooker {
	return &Cooker{
		PluggedIn:    false,
		RecipeChosen: false,
		Ingredients:  make(map[string]int),
		Temperature:  0,
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

		c.Ingredients[ingredient] = quantity

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
	fmt.Println("Ingredients used:", c.Ingredients)
	fmt.Println("Temperature:", c.Temperature, "°C")
	fmt.Println("Duration:", c.CookingDuration, "minutes")
	c.CancelOperation()
}

// CancelOperation resets the cooker state to its initial values.
func (c *Cooker) CancelOperation() {
	c.RecipeChosen = false
	c.Ingredients = make(map[string]int)
	c.Temperature = 0
	c.CookingDuration = 0
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
			cooker.RecipeChosen = true
			cooker.Temperature = 100 // Assuming a default temperature of 100°C
			cooker.CookingDuration = 30 // Assuming a default cooking duration of 30 minutes
			cooker.AddIngredient()
			cooker.StartCooking()
		default:
			fmt.Println("Invalid choice. Please try again.")
		}
	}
}
