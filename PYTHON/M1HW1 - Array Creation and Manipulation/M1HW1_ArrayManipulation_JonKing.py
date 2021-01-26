# 3) The program should be menu driven:
#       A)The menu to be displayed is shown below:
#           I) (20 points, loop must be functional)
#            II)#MENU
#               _________________________________
#               1)	Create a 3-by-3 Array
#               2)	Display cube Values for elements in array
#               3)	Add 7 to every element and display result
#               4)	Multiply elements by 6 and display result
#               5)	Exit

# 4) The program is to do the following:
#       A) Ask user to enter a number for one of the choices displayed in menu
#            I) If 1 is entered(Create Array ): 20 points
#                1) Create a 3-by-3 Numpy array containing 
#                   Even Integers from 2 through 18. 
#                2) Once user complete entry display the array
#                   created (array is to be displayed in two 
#                   rows but without the square brackets []. 
#                   Hint - use function or loop to display 
#                   array content)
#           II) If 2 is entered (Cube Values): 15 points
#                1) Verify that an array has been created, 
#                   else notify user that the array is empty
#                   and redisplay menu.
#                2) If array has been created, calculate the 
#                   square value (**3) for each element. 
#                   Hint broadcasting. 
#                   1) Display result of operation. Remember 
#                      to display array in 3 rows without the brackets.
#
#*** Note: For the operations below, DO NOT alter the array created. 
#*** Hint, lookup shallow and deep copy
#
#           IV) If 3 is entered (Adding): 15 points
#                1) Verify that an array has been created, 
#                   else notify user that the array is 
#                   empty and redisplay menu.
#                2) if array has been created, Add 7 
#                   to every element . Hint broadcasting. 
#                3)	Display result of operation. Remember 
#                   to display array in 3 rows without the brackets.
#           V) If 4 is entered (Multiply): 15 points
#                1) Verify that an array has been created, 
#                   else notify user that the array is 
#                   empty and redisplay menu.
#                2) If array has been created, multiply 
#                   every element by 5 . Hint broadcasting.
#                3) Display result of operation. Remember 
#                   to display array in 3 rows without the brackets.
#           VI) If 5 is entered (Exit): 5 points
#                1) Terminate program
#
# A brief description of the project (See Above)
# 22JAN20
# CSC221 M1HW1 – Array Manipulations
# Jon King
#
#
#
import numpy as np
def main(setupArray, successArray):
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
        main(setupArray, successArray)
    # Else/If Statement variable menuStart is equal to 1  
    elif menuStart == 1:
        # Call create() module
        create(setupArray, successArray)
    # Else/If variable menuStart is equal to 2.    
    elif menuStart == 2:
        # Call cubeValues() module
        cubeValues(setupArray, successArray)
    # Else/If variable menuStart is equal to 3.
    elif menuStart == 3:
        # Call add() module
        add(setupArray, successArray)
    # Else/If variable menuStart is equal to 4.
    elif menuStart == 4:
        # Call multi() module
        multi(setupArray, successArray)
    else:
        # Call ending()
        ending()
# Module create() with the variables 'setupArray' & 'successArray'.
def create(setupArray, successArray):
    # Create Module Intro
    print("-----------------------------------")
    print("|    Create a New 3-by-3 Array    |")
    print("-----------------------------------")
    print("|             Numbers             |")
    print("|              02-18              |")
    print("-----------------------------------")
    choose = (input("Press 'Enter' to continue..."))
    if choose == choose:
        # Array as first set in the variable 'firstSet'.
        firstSet = [2, 4, 6]
        # Array as second set in the variable 'secondSet'.
        secondSet = [8, 10, 12]
        # Array as first set in the variable 'thirdSet'
        thirdSet = [14, 16, 18]
        # Insert user input variables into the array 'setupArray'.
        setupArray = np.array([(firstSet),(secondSet),(thirdSet)])
        # Display array completed successfully
        print('')
        print('---------------------------------------------')
        print('|Congratulations, your array has been setup!|')
        print("|  Let's move on to some other choices!!!   |")
        print('---------------------------------------------')
        successArray = successArray + 1000
        # Display array in 3-by-3 format.
        for row in setupArray:
            for column in row:
                print(column, end=' ')
            print()
    else:
        # Display array has NOT been successfully setup
        print('--------------------------------------------')
        print('|Your array has NOT been successfully setup|')
        print('|           Please Try Again.              |')
        print('--------------------------------------------')
        successArray = successArray + 0
        main(setupArray, successArray)
    # Return to main module
    main(setupArray, successArray)
# Module cubeValues() with the variables 'setupArray' & 'successArray'.
def cubeValues(setupArray, successArray):
    # Verify if the array has been created.
    if successArray == 0:
        # Display array has NOT been successfully setup
        print('--------------------------------------------')
        print('|Your array has NOT been successfully setup|')
        print('|           Please Try Again.              |')
        print('--------------------------------------------')
    # cubeValues Module Intro
    else:
        cubeValueArray = setupArray.copy()
        print('------------------------------------------')
        print("|Display Cube Value for Elements in Array|")
        print('------------------------------------------')
        # Display array in 3-by-3 format.
        for row in setupArray:
            for column in row:
                print(column, end=' ')
            print()
        # Variable 'cont1' user input to continue.
        cont1 = input("Press 'Enter' to continue...")
        if cont1 == cont1:
            print('')
            # Cube all elements of the array
            cubeValueArray**= 3
            # Display array in 3-by-3 format.
            for row in cubeValueArray:
                for column in row:
                    print(column, end=' ')
                print()
            print('')
        else:
            # Display array has NOT been successfully updated.
            print('----------------------------------------------')
            print('|Your array has NOT been successfully updated|')
            print('|             Please Try Again.              |')
            print('----------------------------------------------')
    # Return to main() module.
    main(setupArray, successArray)
# Module add() with the variables 'setupArray' & 'successArray'.
def add(setupArray, successArray):
    # Verify if the array has been created.
    if successArray == 0:
        # Display array has NOT been successfully setup
        print('--------------------------------------------')
        print('|Your array has NOT been successfully setup|')
        print('|           Please Try Again.              |')
        print('--------------------------------------------')
    else:
        # Create variable to manipulate original array in module.
        addValueArray = setupArray.copy()
        # add Module Intro
        print('---------------------------------')
        print("|Add 7 to Every Element in Array|")
        print('---------------------------------')
        # Display array in 3-by-3 format.
        for row in setupArray:
            for column in row:
                print(column, end=' ')
            print()
        # Variable 'cont1' user input to continue.
        cont1 = input("Press 'Enter' to continue...")
        if cont1 == cont1:
            print('')
            # Add 7 to all elements of the array
            addValueArray+= 7
            # Display array in 3-by-3 format.
            for row in addValueArray:
                for column in row:
                    print(column, end=' ')
                print()
            print('')
        else:
            # Else statement to show array has NOT been successfully updated.
            print('----------------------------------------------')
            print('|Your array has NOT been successfully updated|')
            print('|             Please Try Again.              |')
            print('----------------------------------------------')
    # Return to main() module.
    main(setupArray, successArray)
# Module multi() with the variables 'setupArray' & 'successArray'.
def multi(setupArray, successArray):
    # Verify if the array has been created.
    if successArray == 0:
        # Display array has NOT been successfully setup
        print('--------------------------------------------')
        print('|Your array has NOT been successfully setup|')
        print('|           Please Try Again.              |')
        print('--------------------------------------------')
    else:
        # Create variable to manipulate original array in module.
        multiValueArray = setupArray.copy()
        # multi Module Intro
        print('--------------------------------------')
        print("|Multiply 6 to Every Element in Array|")
        print('--------------------------------------')
        # Display array in 3-by-3 format.
        for row in setupArray:
            for column in row:
                print(column, end=' ')
            print()
        # Variable 'cont1' user input to enter a country to display it's TLD.
        cont1 = input("Press 'Enter' to continue...")
        if cont1 == cont1:
            print('')
            # Multiply 6 to all elements of the array
            multiValueArray*= 6
            # Display array in 3-by-3 format.
            for row in multiValueArray:
                for column in row:
                    print(column, end=' ')
                print()
            print('')
        else:
            # Else statement to show array has NOT been successfully updated.
            print('----------------------------------------------')
            print('|Your array has NOT been successfully updated|')
            print('|             Please Try Again.              |')
            print('----------------------------------------------')
    # Return to main() module.
    main(setupArray, successArray)
# Module display() with the variables 'setupArray' & 'successArray'.
def display():
    # Display GUI for menu options.
    print('-----------------------------------------------------')
    print('|                          MENU                     |')
    print('-----------------------------------------------------')
    print('|  1)	Create a New 3-by-3 Array                   |')
    print('|  2)	Display Cube Value for Elements in Array    |')
    print('|  3)	Add 7 to Every Element in Array             |')
    print('|  4)	Multiply 6 to Every Element in Array        |')
    print('|  5)	Exit                                        |')
    print('------------------------------------------------------')
# Module ending()
def ending():
    # Display Thank you message & exit program.
    print('--------------------------------')
    print('|Thanks for using this program!|')
    print('--------------------------------')
# PROGRAM START
# Initiate Variables
setupArray = 0
successArray = 0
# Intro
print('---------------------------------------')
print("|Let's start off by creating an array!|")
print('---------------------------------------')
# Call main() module
main(setupArray, successArray)