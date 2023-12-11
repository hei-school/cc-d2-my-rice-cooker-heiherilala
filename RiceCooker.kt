import kotlin.system.exitProcess

class RiceCooker {
    private var pluggedIn = false

    fun start() {
        println("Welcome to the Rice Cooker App!")
        do {
            showMainMenu()
            val choice = readIntInput("Choose your action:")
            when (choice) {
                1 -> prepareRecipe("Rice")
                2 -> prepareRecipe("Hot Water")
                3 -> prepareRecipe("Soup")
                4 -> exitProcess(0)
                else -> println("Invalid choice. Please try again.")
            }
        } while (true)
    }

    private fun showMainMenu() {
        println("Main Menu:")
        println("1. Rice")
        println("2. Hot Water")
        println("3. Soup")
        println("4. Quit")
    }

    private fun prepareRecipe(recipe: String) {
        println("Preparing $recipe")
        if (!pluggedIn) {
            println("Plug in the rice cooker first.")
            plugIn()
        }

        val ingredients = mutableListOf<Ingredient>()

        do {
            showIngredientMenu()
            val ingredientName = readLine("Enter ingredient name: ") ?: ""
            val quantity = readIntInput("Enter quantity in grams: ")

            ingredients.add(Ingredient(ingredientName, quantity))

            val continueChoice = readIntInput("1. Add another ingredient\n2. Start cooking\n3. Cancel")
            when (continueChoice) {
                1 -> continue
                2 -> {
                    cookRecipe(recipe, ingredients)
                    break
                }
                3 -> return
                else -> println("Invalid choice. Please try again.")
            }
        } while (true)
    }

    private fun showIngredientMenu() {
        println("Add Ingredients:")
    }

    private fun cookRecipe(recipe: String, ingredients: List<Ingredient>) {
        println("Cooking $recipe...")
        val temperature = calculateTemperature(recipe)
        val duration = calculateDuration(recipe)

        println("Your $recipe is ready!")
        println("Ingredients: ${ingredients.joinToString { "${it.name}: ${it.quantity}g" }}")
        println("Temperature: $temperature °C")
        println("Duration: $duration minutes")

        // Reset state
        pluggedIn = false
    }

    private fun calculateTemperature(recipe: String): Int {
        // Implement temperature calculation logic here (can be automatic or user-defined)
        return 100 // Default temperature for demonstration
    }

    private fun calculateDuration(recipe: String): Int {
        // Implement duration calculation logic here (can be automatic or user-defined)
        return 30 // Default duration for demonstration
    }

    private fun plugIn() {
        println("Plug in the rice cooker.")
        // Perform any necessary actions when plugging in the rice cooker
        pluggedIn = true
    }

    private fun readIntInput(prompt: String): Int {
        while (true) {
            try {
                print("$prompt ")
                return readLine()?.toIntOrNull()
                    ?: throw NumberFormatException("Invalid input. Please enter a valid number.")
            } catch (e: NumberFormatException) {
                println("Invalid input. Please enter a valid number.")
            }
        }
    }
}

data class Ingredient(val name: String, val quantity: Int)

fun main() {
    val riceCooker = RiceCooker()
    riceCooker.start()
}
