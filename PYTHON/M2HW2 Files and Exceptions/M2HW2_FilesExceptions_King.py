# For this assignment you will complete exercise 9.12 on page 351 of your
# textbook. Archive.org, is one of the sites you can go to to download the 
# required the speech of your choice. 

# 1. Display the following menu 10 points
# MENU
#   1. Display Entire Speech
#   2. Display Total Word Count
#   3. Display Total Character Count
#   4. Display Average Word Length
#   5. Display Top Ten Longest Words
#   6. Exit Program

# 2. Enter your choice:
#   A) If a user enters a value other than 1 thru 6, display a message 
#      that tells them their entry was invalid and ask that they renter 
#      a correct value. 10 points
# 3. Details about each menu option:
#   1. Display Entire Speech (10 points )
#	   When 1 is entered, read the downloaded text file and display
#      speech on screen  
#   2. Display Total Word Count (10 points )
#	   When 2 is entered, read downloaded file and display total word count
#   3. Display Total Character Count (10 points )
#	   When 3 entered, read downloaded file and display total character count
#   4. Display Average Word Length (10 points )
#	   When 4 is entered, read downloaded file and display Average Word Length
#   5. Display Top Ten Longest Words (20 points )
#	   When 5 is entered, read downloaded file and display the top ten longest words
#   6. Exit Program (10 points )
#	   Display a good-bye message and terminate the program
# A brief description of the project (SHOWN ABOVE)
# 22FEB20
# CSC221 M2HW – FileExceptions
# Jon King
#
# main() Module.
def main():
    # Display Intro Menu GUI
    display()
    try:
        # User input to make selection on were to start.
        menuStart = int(input('Choose one of the options: '))
    except ValueError:
        print('-----------------------------------')
        print('|That is not a valid menu response|')
        print('|        Please Try Again.        |')
        print('-----------------------------------')
        print()
        # Set variable to 0
        menuStart = 0
        # Restart main module
        main()
    else:
        # Else/If Statement variable menuStart is equal to 1  
        if menuStart == 1:
            # Call wholeSpeech() module
            wholeSpeech()
        # Else/If variable menuStart is equal to 2.    
        elif menuStart == 2:
            # Call wordCount() module
            wordCount()
        # Else/If variable menuStart is equal to 3.
        elif menuStart == 3:
            # Call charCount() module
            charCount()
        # Else/If variable menuStart is equal to 4.
        elif menuStart == 4:
            # Call avgCount() module
            avgCount()
        # Else/If variable menuStart is equal to 5.
        elif menuStart == 5:
            # Call longestWords() module
            longestWords()
        elif menuStart == 6:
            ending()
        # Else response
        else:
            print('-----------------------------------')
            print('|That is not a valid menu response|')
            print('|        Please Try Again.        |')
            print('-----------------------------------')
            print()
            # Set variable to 0
            menuStart = 0
            # Restart main module
            main()  
# wholeSpeech() Module.
def wholeSpeech():
    # Try to open the file 'Obama_2015.txt'
    try:
        with open('Obama_2015.txt', 'r') as sotu:
            # Display intro from the menu option 1
            print('---------------------------------------------')
            print('|Below is the State of the Union performed in|')
            print('|           2015 by President Obama          |')
            print('---------------------------------------------')
            # For loop to read line by line
            for line in sotu:
                line = sotu.read()
                print(line)
    # Error Message
    except FileNotFoundError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
    # Success Result
    else:
        print('---------------------------------------------')
        print('|Above is the State of the Union performed in|')
        print('|           2015 by President Obama          |')
        print('---------------------------------------------')
        main()
# wordCount() Module.
def wordCount():
    # Try to open the file 'Obama_2015.txt'
    try:
        with open('Obama_2015.txt', 'r') as sotu:
            # Variable 'words' used to read the entire txt file
            words = sotu.read()
            # Count number of word strings without digits in the sentence.
            wordCount = len(words.split())
    # Error Message
    except FileNotFoundError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
    # Success Message
    else:
        # If/Else Statements to determine proper grammar for the results.
        if wordCount == 1:
            print('\n|-----------------------------------------------'
                  +'--------------|\n|There is '+str(wordCount)
                  +' word in your State of the Union Address.|\n'
                  +'|-------------'
                  +'-------------------------------------------|')
        else:
            print('\n|------------------------------------------'
                  +'--------------|\n|There are '+str(wordCount)
                  +' words in your State of the Union Address.|\n'
                  +'|-------------'
                  +'-------------------------------------------|')
        # Return to main() module.
        main()
# charCount Module()
def charCount():
    # Try to open the file 'Obama_2015.txt'
    try:
        with open('Obama_2015.txt', 'r') as sotu:
            # Variable 'words' used to read the entire txt file
            words = sotu.read()
            # Count number of word strings without digits in the sentence.
            char = len(words)
    # Error Message
    except FileNotFoundError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
    # Success Message
    else:
        # If/Else Statements to determine proper grammar for the results.
        if char == 1:
            print('\n|-------------------------------------------'
                  +'------------------|\n|There is '+str(char)
                  +' characters in your State of the Union Address.|\n'
                  +'|-------------'
                  +'------------------------------------------------|')
        else:
            print('\n|--------------------------------------------'
                  +'------------------|\n|There are '+str(char)
                  +' characters in your State of the Union Address.|\n'
                  +'|-------------'
                  +'-------------------------------------------------|')
        # Return to main() module.
        main()
# avgCount() module.
def avgCount():
    # Try to open the file 'Obama_2015.txt'
    try:
        with open('Obama_2015.txt', 'r') as sotu:
            # Variable 'words' used to read the entire txt file
            start = sotu.read()
            words = start.split()
    # Error Message
    except FileNotFoundError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
    # Success Message
    else:
        # Count number of word strings without digits in the sentence.
        average = sum(len(word) for word in words) / len(words)
        averageDisplay = f'{average:>1.2f}'
        # If/Else Statements to determine proper grammar for the results.
        if average == 1:
            print('\n|-------------------------------------------'
                  +'------------------|\n|There is '+str(averageDisplay)
                  +' characters in your State of the Union Address.|\n'
                  +'|-------------'
                  +'------------------------------------------------|')
        else:
            print('\n|--------------------------------------------'
                  +'----|\n|There are an average of '
                  +str(averageDisplay)
                  +' characters per word| \n'
                  +'|        in your State of the Union Address.     |\n'
                  +'|-------------'
                  +'-----------------------------------|