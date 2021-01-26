# M4Pro (Who Authored the work of Shakespeare)
# Introduction:
# The assignment requires good understanding of NLP Tool Kit 
# and TextBlob library and the different functions they contain 
# for analyzing and manipulating text.
#
# Instructions:
#
# For this assignment you will complete exercise 12.16 on page 513 
# of your textbook. 
#
# 1. Create a Python code file named M4Pro_Similarity_FirstLast.py 
#    (replace "FirstLast" with your own name)
# 2. Add a title comment block to the top of the new Python file 
#    using the following form
#
# 3. Complete exercise 12.6 (Who Authored the Words of Shakespeare) 
#    on page 513...
#   A) Project: Who Authored the Works of Shakespeare
#       1) Using the spaCy similarity detection code introduced in this 
#          chapter, compare Shakespear's Macbeth to one major work from 
#          each of several other authors who might have written Shakespeare's 
#          works.
#
#       2) Locate works on Project Gutenberg from a few authors listed 
#          at, "...", then use spaCy to compare their works' similarity to 
#          Macbeth. Which of the authors' works are most similar to Macbeth.
#
# 4. Submit your finished code solution file(s) through the assignment 
#    link below
# Grading criteria:
#   A) Shown next to each required point in instructions above
#	B) Pseudocode and block comment (10 points )
#
# A brief description of the project (Shown Above)
# 19MAR20
# CSC221 M4Pro – Similarity 
# Jon King

# Import spaCy similarity detection code
import spacy
# Import Path class from Python Standard Library pathlib
from pathlib import Path
# load the en_core_web_md from the spaCy similarity detection code
nlp = spacy.load('en_core_web_md')
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
            # Call macShep() module
            macShep()
        # Else/If variable menuStart is equal to 2.    
        elif menuStart == 2:
            # Call macMaids() module
            macMadTrag()
        # Else/If variable menuStart is equal to 3.
        elif menuStart == 3:
            # Call macElSon() module
            macElizSam()
        # Else/If variable menuStart is equal to 3.
        elif menuStart == 4:
            # Call ending() module
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

# macShep() Module.
def macShep():
    try:
        print('------------------------------------')
        print('|             Compare              |')
        print('|  MacBeth by William Shakespeare  |')
        print('|              with...             |')
        print('|    The Affectionate Shepherd     |')
        print('|      by Richard Barnfield        |')
        print('------------------------------------')
        # Display what is about to happen in the program.
        print('---------------------------------------------------')
        print("|Please Wait While I Determine the Similarities...|")
        print('---------------------------------------------------')
        # variable macbethShake Doc object Macbeth by William Shakespeare
        macbethShake = nlp(Path('Macbeth.txt').read_text())
        # variable affectRichBarn Doc object The Affectionate Shepherd
        # by Richard Barnfield
        affectRichBarn = nlp(Path('TheAffectionate.txt').read_text())
        
    except ValueError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
        main()
    else:
        # Variable answer used to determine the similarities between the 
        # two novels.
        answer = macbethShake.similarity(affectRichBarn)
        #
        try:
            # User input to make selection on were to start.
            stopGoPoint = input('Enter any key(s) to continue')
        except ValueError:
            print('-----------------------------------')
            print('|That is not a valid menu response|')
            print('|        Please Try Again.        |')
            print('-----------------------------------')
            print()
            # User input to make selection on were to start.
            stopGoPoint = input('Enter any key(s) to continue')
        else:
            if stopGoPoint == stopGoPoint:
                # Display the Similarities.
                print('---------------------------------------')
                print("|I Determined the Similarities were...|")
                print(f"|\t\t{answer:.2f}\t\t      |")
                print('---------------------------------------\n')
        # Restart main module
        main()

# macMadTrag() Module.
def macMadTrag():
    try:
        print('-------------------------------------')
        print('|              Compare              |')
        print('|   MacBeth by William Shakespeare  |')
        print('|               with...             |')
        print('|         The Maids Tragedy         |')
        print('|by Francis Beaumont & John Fletcher|')
        print('-------------------------------------')
        # Display what is about to happen in the program.
        print('---------------------------------------------------')
        print("|Please Wait While I Determine the Similarities...|")
        print('---------------------------------------------------')
        # variable macbethShake Doc object Macbeth by William Shakespeare
        macbethShake = nlp(Path('Macbeth.txt').read_text())
        # variable madTrag Doc object The Maids Tragedy
        # by Francis Beaumont & John Fletcher
        madTrag = nlp(Path('Maids.txt').read_text())
    except ValueError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
        main()
    else:
        # Variable answer used to determine the similarities between the 
        # two novels.
        answer = macbethShake.similarity(madTrag)
        #
        try:
            # User input to make selection on were to start.
            stopGoPoint = input('Enter any key(s) to continue')
        except ValueError:
            print('-----------------------------------')
            print('|That is not a valid menu response|')
            print('|        Please Try Again.        |')
            print('-----------------------------------')
            print()
            # User input to make selection on were to start.
            stopGoPoint = input('Enter any key(s) to continue')
        else:
            if stopGoPoint == stopGoPoint:
                # Display the Similarities.
                print('---------------------------------------')
                print("|I Determined the Similarities were...|")
                print(f"|\t\t{answer:.2f}\t\t      |")
                print('---------------------------------------\n')
        # Restart main module
        main()
# macElSon() Module.
def macElizSam():
    try:
        print('----------------------------------------')
        print('|               Compare                |')
        print('|    MacBeth by William Shakespeare    |')
        print('|                with...               |')
        print('|Elizabethan Sonnet Cycles: Delia-Diana|')
        print('| by Henry Constable and Samuel Daniel |')
        print('----------------------------------------')
        # Display what is about to happen in the program.
        print('---------------------------------------------------')
        print("|Please Wait While I Determine the Similarities...|")
        print('---------------------------------------------------')
        # variable macbethShake Doc object Macbeth by William Shakespeare
        macbethShake = nlp(Path('Macbeth.txt').read_text())
        # variable elizSam Doc object Elizabethan Sonnet Cycles: 
        # Delia-Diana by Francis Beaumont & John Fletcher
        elizSam = nlp(Path('Elizabethan.txt').read_text())
    except ValueError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
        main()
    else:
        # Variable answer used to determine the similarities between the 
        # two novels.
        answer = macbethShake.similarity(elizSam)
        #
        try:
            # User input to make selection on were to start.
            stopGoPoint = input('Enter any key(s) to continue')
        except ValueError:
            print('-----------------------------------')
            print('|That is not a valid menu response|')
            print('|        Please Try Again.        |')
            print('-----------------------------------')
            print()
            # User input to make selection on were to start.
            stopGoPoint = input('Enter any key(s) to continue')
        else:
            if stopGoPoint == stopGoPoint:
                # Display the Similarities.
                print('---------------------------------------')
                print("|I Determined the Similarities were...|")
                print(f"|\t\t{answer:.2f}\t\t      |")
                print('---------------------------------------\n')
        # Restart main module
        main()     
# Module display().
def display():
    # Display GUI for menu options.
    print('-------------------------------------------------')
    print('|                     Compare                   |')
    print('|          MacBeth by William Shakespeare       |')
    print('|                     with...                   |')
    print('-------------------------------------------------')
    print('|  1)	The Affectionate Shepherd               |')
    print('|    	by Richard Barnfield                    |')
    print('|  2)	The Maids Tragedy                       |')
    print('|    	by Francis Beaumont and John Fletcher   |')
    print('|  3)	Elizabethan Sonnet Cycles: Delia-Diana  |')
    print('|    	by Henry Constable and Samuel Daniel    |')
    print('|  4)	Exit                                    |')
    print('-------------------------------------------------')
# Module ending()
def ending():
    # Display Thank you message & exit program.
    print('--------------------------------')
    print('|Thanks for using this program!|')
    print('--------------------------------')
# PROGRAM START
main()