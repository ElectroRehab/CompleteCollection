# M5Pro (Sentiment Analysis)
# Introduction:
# The assignment requires good understanding of NLP Tool Kit and 
# TextBlob library and the different functions they contain for analyzing 
# and manipulating text, it also involves using other libraries such as 
# Beautiful Soup and requests libraries and tests student’s knowledge on 
# web scraping. 
#
# Instructions:
# For this assignment you will complete exercise 12.03 & 12.4 on page 512 
# of your textbook. 
#
# 1. Create a Python code file named M5Pro_SentimentAnalysis_FirstLast.py 
#    (replace "FirstLast" with your own name)
# 2. Add a title comment block to the top of the new Python file using 
#    the following form:
#
# # A brief description of the project
# # Date
# # CSC221 M5Pro – Sentiment Analysis
# # Your Name
#
# 3. Complete exercise 12.3 (Sentiment of a News Article) 
#    on page 512 (70 points):
#   A) Using the techniques in Exercise 12.1, (M5HW_Web Scraping), download a
#      web page for a current news article and create a TextBlob. Display
#      the sentiment for the entire TextBlob and for each Sentence.
#
# 4. Complete exercise 12.4 (Sentiment with NaiveBayesAnalyzer) (20 points):
#   A) Repeat the NaiveBaynesAnalyzer for sentiment analysis.
#
# Grading criteria:
#   A) Shown next to each required point in instructions above
#   B) Pseudocode and block comment (10 points )
#
# A brief description of the project (SHOWN ABOVE ^^^)
# 31MAR20
# CSC221 M5Pro – Sentiment Analysis 
# Jon King


# Import BeautifulSoup Library
from bs4 import BeautifulSoup
# Import Requests to get use website information for webscraping
import requests
# Import Natural Language Processing (NLP) text processing library.
from textblob import TextBlob
# Import NaiveBayesAnalyzer (NLP) text processing library.
from textblob.sentiments import NaiveBayesAnalyzer

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
            # Call exerOneTwoThree() module
            exerOneTwoThree()
        # Else/If variable menuStart is equal to 2.    
        elif menuStart == 2:
            # Call exerOneTwoFour() module
            exerOneTwoFour()
        # Else/If variable menuStart is equal to 3.
        elif menuStart == 3:
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
# exerOneTwoThree() Module.
def exerOneTwoThree():
    try:
        # Display intro from the menu option 1
        print('-----------------------------------------------')
        print("|Please Wait While I Complete Exercise 12.3...|")
        print('-----------------------------------------------')
        # Create object 'getPy' to recieve esignated webpage
        getPy = requests.get("https://www.bbc.com/news/science-environment"\
                             "-52133534")
        # Create Beautiful Soup Object to read html5lib coding for the 
        # designated website in the object getPy
        beaSoup = BeautifulSoup(getPy.content, "html5lib")
        # Extract the webpage words without the browser structural
        newsBlob = TextBlob(beaSoup.get_text(strip = True)) 
        
    except ValueError:
        print('-----------------------------------')
        print('|       WEBSITE NOT FOUND!!!      |')
        print('|Please check to make sure you are|')
        print('|    connected to the internet.   |')
        print('-----------------------------------')
        main()
    else:
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
            stopGoPoint = int(input('Enter any key(s) to continue'))
        else:
            if stopGoPoint == stopGoPoint:
                # Display intro from the menu option 1
                print('----------------------------------------')
                print('|              DISPLAY THE...          |')
                print('----------------------------------------')
                print('|1 -  Sentiment for the Entire TextBlob|')
                print('|2 -  Sentiment for Each Sentence      |')
                print('|3 -  Return to the Menu               |')
                print('----------------------------------------')
                try:
                    # User input to make selection on were to start.
                    menuAnswer = int(input('Choose one of the options: '))
                except ValueError:
                    print('-----------------------------------')
                    print('|That is not a valid menu response|')
                    print('|        Please Try Again.        |')
                    print('-----------------------------------')
                    print()
                    # Set variable to 0
                    menuAnswer = 0
                    # Restart main module
                    main()
                else:
                    # Else/If Statement variable menuAnswer is equal to 1  
                    if menuAnswer == 1:
                        # Display the results.
                        print('-------------------------------------------')
                        print('|The Sentiment For The Entire News Article|')
                        print('|    From The Entire TextBlob Is Below    |')
                        print('-------------------------------------------\n')
                        print(newsBlob.sentiment)
                        # Display the results.
                        print('\n-------------------------------------------')
                        print('|The Sentiment For The Entire News Article|')
                        print('|    From The Entire TextBlob Is Above    |')
                        print('-------------------------------------------')
                        exerOneTwoThree()
                    # Else/If variable menuAnswer is equal to 2.    
                    elif menuAnswer == 2:
                        # Display the results.
                        print('---------------------------------')
                        print('|The Sentiment For Each Sentence|')
                        print('|From The News Article is Below |')
                        print('---------------------------------\n')
                        for sentence in newsBlob.sentences:
                            print(sentence.sentiment)
                        print('\n---------------------------------')
                        print('|The Sentiment For Each Sentence|')
                        print('|From The News Article is Above |')
                        print('---------------------------------')
                        exerOneTwoThree()
                    # Else/If variable menuAnswer is equal to 3.
                    elif menuAnswer == 3:
                        # Restart main module
                        print('\n')
                        main()
                    # Else response
                    else:
                        print('-----------------------------------')
                        print('|That is not a valid menu response|')
                        print('|        Please Try Again.        |')
                        print('-----------------------------------')
                        print()
                        # Set variable to 0
                        menuAnswer = 0
                        # Restart exerOneTwoThree module
                        exerOneTwoThree()
# exerOneTwoFour() Module.
def exerOneTwoFour():
    try:
        # Display intro from the menu option 1
        print('-----------------------------------------------')
        print("|Please Wait While I Complete Exercise 12.4...|")
        print('-----------------------------------------------')
        # Create object 'getPy' to recieve esignated webpage
        getPy = requests.get("https://www.bbc.com/news/science-environment"\
                             "-52133534")
        # Create Beautiful Soup Object to read html5lib coding for the 
        # designated website in the object getPy
        beaSoup = BeautifulSoup(getPy.content, "html5lib")
        # Extract the webpage words without the browser structural
        newsBlob = TextBlob(beaSoup.get_text(strip = True), \
                            analyzer=NaiveBayesAnalyzer()) 
        
    except ValueError:
        print('-----------------------------------')
        print('|       WEBSITE NOT FOUND!!!      |')
        print('|Please check to make sure you are|')
        print('|    connected to the internet.   |')
        print('-----------------------------------')
        main()
    else:
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
            stopGoPoint = int(input('Enter any key(s) to continue'))
        else:
            if stopGoPoint == stopGoPoint:
                # Display intro from the menu option 1
                print('----------------------------------------')
                print('|  Display Using NaiveBayesAnalyzer... |')
                print('----------------------------------------')
                print('|1 -  Sentiment for the Entire TextBlob|')
                print('|2 -  Sentiment for Each Sentence      |')
                print('|3 -  Return to the Menu               |')
                print('----------------------------------------')
                try:
                    # User input to make selection on were to start.
                    menuAnswer = int(input('Choose one of the options: '))
                except ValueError:
                    print('-----------------------------------')
                    print('|That is not a valid menu response|')
                    print('|        Please Try Again.        |')
                    print('-----------------------------------')
                    print()
                    # Set variable to 0
                    menuAnswer = 0
                    # Restart main module
                    main()
                else:
                    # Else/If Statement variable menuAnswer is equal to 1  
                    if menuAnswer == 1:
                        # Display the results.
                        print('-------------------------------------------')
                        print('|The Sentiment For The Entire News Article|')
                        print('|    From The Entire TextBlob Is Below    |')
                        print('-------------------------------------------\n')
                        print(newsBlob.sentiment)
                        # Display the results.
                        print('\n-------------------------------------------')
                        print('|The Sentiment For The Entire News Article|')
                        print('|    From The Entire TextBlob Is Above    |')
                        print('-------------------------------------------')
                        exerOneTwoFour()
                    # Else/If variable menuAnswer is equal to 2.    
                    elif menuAnswer == 2:
                        # Display the results.
                        print('---------------------------------')
                        print('|The Sentiment For Each Sentence|')
                        print('|From The News Article is Below |')
                        print('---------------------------------\n')
                        for sentence in newsBlob.sentences:
                            print(sentence.sentiment)
                        print('\n---------------------------------')
                        print('|The Sentiment For Each Sentence|')
                        print('|From The News Article is Above |')
                        print('---------------------------------')
                        exerOneTwoFour()
                    # Else/If variable menuAnswer is equal to 3.
                    elif menuAnswer == 3:
                        # Restart main module
                        print('\n')
                        main()
                    # Else response
                    else:
                        print('-----------------------------------')
                        print('|That is not a valid menu response|')
                        print('|        Please Try Again.        |')
                        print('-----------------------------------')
                        print()
                        # Set variable to 0
                        menuAnswer = 0
                        # Restart exerOneTwoFour module
                        exerOneTwoFour()
# Module display().
def display():
    # Display GUI for menu options.
    print('-----------------------------')
    print('|             MENU          |')
    print('-----------------------------')
    print('|  1)	Start Exercise 12.3 |')
    print('|  2)	Start Exercise 12.4 |')
    print('|  3)	Exit                |')
    print('-----------------------------')
# Module ending()
def ending():
    # Display Thank you message & exit program.
    print('--------------------------------')
    print('|Thanks for using this program!|')
    print('--------------------------------')
# PROGRAM START
main()