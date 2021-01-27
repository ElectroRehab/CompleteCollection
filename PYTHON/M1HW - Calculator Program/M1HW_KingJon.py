# M1HW
# Jon King
# 17AUG20
# Assignment Information
#
# This exercise tests your ability to turn English requirements into a working
# program. For this assignment, you will create a simple calculator. You are 
# welcome to use any language you're currently studying. 

# The program should use a simple text menu and text input. You only need to 
# work with integers.

# The program should display a text menu allowing the user to choose a 
# calculation type. After doing this, the user will be prompted to enter two 
# numbers. The program will display the result, then return to the main menu.

# Tier Grading
# We will use a Bronze/Silver/Gold tier system, where Bronze gives a maximum 
# of 80 points, SIlver, a maximum of 90, and Gold up to 100. I recommend you 
# always complete one tier before adding the functionality for later tiers.

# Bronze (80/100)
# The program should allow the user to either add or subtract two numbers.

# Silver (90/100)
# The program should also allow the user to divide or multiply two numbers.

# Gold (100/100)
# For this tier, the program should work in a way that matches the behavior 
# displayed in the sample output below. You may have to make some assumptions.

# Sample Output
# User output is displayed in bold.

# Welcome to the calculator program.
# 1. Add
# 2. Subtract
# 3. Divide 
# 4. Multiply
# 5. Exit
# Enter a number: 1

# Add 
# Enter a number: 2
# Enter a number: 2
# 2 + 2 = 4
# 1. Repeat
# 2. Main Menu
# Enter a number: 1

# Add
# Enter a number: 1
# Enter a number: 1
# 1 + 1 = 2 
# 1. Repeat
# 2. Main Menu
# Enter a number: 1
# Welcome to the calculator program.
# 1. Add
# 2. Subtract
# 3. Divide
# 4. Multiply
# 5. Exit
# Enter a number: 5
# Goodbye.

def main():
    # Display Intro Menu GUI
    display()
    # User input to make selection on were to start.
    menuStart = int(input('Choose one of the options: '))
    # IF, ELIF, & ELSE Statements to determine what module to call.
    # If variable menuStart is not equal to proper responses.
    if menuStart < 1 or menuStart > 5:
        print('-----------------------------------')
        print('|That is not a valid menu response|')
        print('|        Please Try Again.        |')
        print('-----------------------------------')
        print()
        # Set variable to 0
        menuStart = 0
        # Restart main module
        main()
    # Else/If Statement variable menuStart is equal to 1  
    elif menuStart == 1:
        # Call add() module
        add()
    # Else/If variable menuStart is equal to 2.    
    elif menuStart == 2:
        # Call subtract() module
        subtract()
    # Else/If variable menuStart is equal to 3.
    elif menuStart == 3:
        # Call divide() module
        divide()
    # Else/If variable menuStart is equal to 4.
    elif menuStart == 4:
        # Call multi() module
        multi()
    else:
        # Call ending()
        ending()
# Module add().
def add():
    # Addition Module Intro
    print("------------------------------")
    print("|    Addition Calculation    |")
    print("------------------------------")
    # User inputs
    num1 = int(input("Enter a number:"))
    num2 = int(input("Enter a number:"))
    # Calculations for user input
    answer = num1 + num2
    # Display results
    print("-----------------")
    print("|    RESULTS    |")
    print("-----------------")
    print(num1, "+", num2, "=", answer, "\n")
    # Return to main module
    main()
# Module subtract().
def subtract():
    # Subtraction Module Intro
    print("---------------------------------")
    print("|    Subtraction Calculation    |")
    print("---------------------------------")
    # User inputs
    num1 = int(input("Enter a number:"))
    num2 = int(input("Enter a number:"))
    # Calculations for user input
    answer = num1 - num2
    # Display results
    print("-----------------")
    print("|    RESULTS    |")
    print("-----------------")
    print(num1, "-", num2, "=", answer, "\n")
    # Return to main module
    main()
# Module divide().
def divide():
    # Division Module Intro
    print("------------------------------")
    print("|    Division Calculation    |")
    print("------------------------------")
    # User inputs
    num1 = int(input("Enter a number:"))
    num2 = int(input("Enter a number:"))
    # Calculations for user input
    answer = num1 / num2
    # Display results
    print("-----------------")
    print("|    RESULTS    |")
    print("-----------------")
    print(num1, "/", num2, "=", answer, "\n")
    # Return to main module
    main()
# Module multi().
def multi():
    # Division Module Intro
    print("------------------------------------")
    print("|    Multiplication Calculation    |")
    print("------------------------------------")
    # User inputs
    num1 = int(input("Enter a number:"))
    num2 = int(input("Enter a number:"))
    # Calculations for user input
    answer = num1 * num2
    # Display results
    print("-----------------")
    print("|    RESULTS    |")
    print("-----------------")
    print(num1, "x", num2, "=", answer, "\n")
    # Return to main module
    main()
# Module display().
def display():
    # Intro
    print('------------------------------------')
    print("|Welcome to the calculator program.|")
    print('------------------------------------')
    # Display GUI for menu options.
    print('----------------------')
    print('|        MENU        |')
    print('----------------------')
    print('|  1)	Add         |')
    print('|  2)	Subtract    |')
    print('|  3)	Divide      |')
    print('|  4)	Multiply    |')
    print('|  5)	Exit        |')
    print('----------------------')
# Module ending()
def ending():
    # Display Thank you message & exit program.
    print('--------------------------------')
    print('|Thanks for using this program!|')
    print('|          GOODBYE!!!          |')
    print('--------------------------------')
# PROGRAM START
# Call main() module
main()