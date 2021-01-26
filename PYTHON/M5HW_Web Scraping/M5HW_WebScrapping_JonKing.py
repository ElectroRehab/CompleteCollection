# M5HW (Web Scraping)
# Introduction:
# The assignment requires good understanding of NLP Tool Kit and TextBlob 
# library and the different functions they contain for analyzing and 
# manipulating text, it also involves using other libraries such as 
# Beautiful Soup and requests libraries and tests student’s knowledge on 
# web scraping.
 
# Instructions:
# For this assignment you will complete exercise 12.01 on page 511 of 
# your textbook. 
#
# 1. Create a Python code file named M5HW_WebScrapping_FirstLast.py 
#    (replace "FirstLast" with your own name)
# 2. Add a title comment block to the top of the new Python file using 
#    the following form
#
# # A brief description of the project
# # Date
# # CSC221 M5HW – Web Scraping 
# # Your Name
#
# 3. Complete exercise 12.1 (Web Scraping with Requests and Beautiful Soup) on 
#    page 511(40 points)
#
# 4. Write the html page into a text file (python.txt). (10 points)
#
# 5. Complete exercise 12.2 (Tokenizing Text and Noun Phrases) (20 points)
#
# 6. Display number of sentences, words(without stop words) and noun 
#    phrases the html page contains (20 points)
#
# Submit your finished code solution file(s) through the assignment link below
# Grading criteria:
# 1) Shown next to each required point in instructions above
# 2) Pseudocode and block comment (10 points)
#
# A brief description of the project (SHOWN ABOVE ^^^)
# 30MAR20
# CSC221 M5HW – Web Scraping 
# Jon King


# Import BeautifulSoup Library
from bs4 import BeautifulSoup
# Import Requests to get use website information for webscraping
import requests
# Import Natural Language Processing (NLP) text processing library.
from textblob import TextBlob
# the stopwords function from the nltk.corpus module
from nltk.corpus import stopwords
# the itemgetter function from the Python Standard Library’s operator module
from operator import itemgetter
# the WordCloud function from the wordcloud module 
from wordcloud import WordCloud
# the Image function from the PIL module 
from PIL import Image
# import OS to delete created pictures & files from 
# user's computer that are opened with the program.
import os
# Import imageio to create a picture out of html website
import imageio

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
            # Call exerOneTwoOne() module
            exerOneTwoOne()
        # Else/If variable menuStart is equal to 2.    
        elif menuStart == 2:
            # Call exerOneTwoTwo() module
            exerOneTwoTwo()
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
# exerOneTwoOne() Module.
def exerOneTwoOne():
    try:
        # Display intro from the menu option 1
        print('-----------------------------------------------')
        print("|Please Wait While I Complete Exercise 12.1...|")
        print('-----------------------------------------------')
        # Create object 'getPy' to recieve esignated webpage
        getPy = requests.get("https://www.python.org")
        # Create Beautiful Soup Object to read html5lib coding for the 
        # designated website in the object getPy
        beaSoup = BeautifulSoup(getPy.content, "html5lib")
        # Turn BeautifulSoup object into a writable string
        stringSoup = str(beaSoup.encode())
        # Extract the webpage words without the browser structural
        pythonBlob = TextBlob(beaSoup.get_text(strip = True)) 
    except ValueError:
        print('-----------------------------------')
        print('|       WEBSITE NOT FOUND!!!      |')
        print('|Please check to make sure you are|')
        print('|    connected to the internet.   |')
        print('-----------------------------------')
        main()
    else:
        # Varible stopWords used to eliminate the stopwords in the english 
        # language
        stopWords = stopwords.words('english')
        # Variable answer used to delete all stop words from the file
        # 'RomeoAndJuliet.txt'
        answer = [word for word in pythonBlob.words if word not in stopWords]
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
            stopGoPoint = int(input('Enter any key(s) to continue'))
        else:
            if stopGoPoint == stopGoPoint:
                # Display intro from the menu option 1
                print('----------------------------------')
                print('|            DISPLAY THE...      |')
                print('|1 -     Eliminated Stop Words   |')
                print('|2 -  Webpage Text W/O Stop Words|')
                print('|3 -   View webpage as WordCloud |')
                print('|4 -   Turn webpage in txt file  |')
                print('|5 -     Return to the Menu      |')
                print('----------------------------------')
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
                        print(stopWords)
                        exerOneTwoOne()
                    # Else/If variable menuAnswer is equal to 2.    
                    elif menuAnswer == 2:
                        # Display the results.
                        print(answer)
                        exerOneTwoOne()
                    # Else/If variable menuAnswer is equal to 3.
                    elif menuAnswer == 3:
                        maskImage()
                    # Else/If variable menuAnswer is equal to 3.
                    elif menuAnswer == 4:
                        # Tell user to close newly opened file to continue
                        print('----------------------')
                        print('|PLEASE CLOSE NOTEPAD|')
                        print('|BEFORE CONTINUING...|')
                        print('----------------------')
                        # Create a txt file and write the string of the 
                        # BeautifulSoup object
                        with open("python.txt", "w") as f:
                            for string in stringSoup:
                                f.write(string)
                        # Open notepad.exe as the default program to read 
                        # the newly created txt file.
                        os.system("notepad.exe python.txt")
                        # delete newly created file from the user's system.
                        os.remove("python.txt")
                        # Return to exerOneTwoOne()
                        exerOneTwoOne()
                    # Else/If variable menuAnswer is equal to 4.
                    elif menuAnswer == 5:
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
                        # Restart main module
                        main()
# maskImage() Module.
def maskImage():   
    try:
        # Create object 'getPy' to recieve esignated webpage
        getPy = requests.get("https://www.python.org")
        # Create Beautiful Soup Object to read html5lib coding for the 
        # designated website in the object getPy
        beaSoup = BeautifulSoup(getPy.content, "html5lib")
        # Extract the webpage words without the browser structural
        pythonBlob = TextBlob(beaSoup.get_text(strip = True))
    except ValueError:
        print('-----------------------------------')
        print('|       WEBSITE NOT FOUND!!!      |')
        print('|Please check to make sure you are|')
        print('|    connected to the internet.   |')
        print('-----------------------------------')
        main()
    else:
        # Display intro from the menu option 1
        print('---------------------------------------------------')
        print("|Please Wait While I Create a WordCloud For You...|")
        print('---------------------------------------------------')
        # Varible stopWords used to eliminate the stopwords in the english 
        # language
        stopWords = stopwords.words('english')
        #
        items = pythonBlob.word_counts.items()
        # Variable answer used to delete all stop words from the website
        items = [item for item in items if item[0] not in stopWords]
        # Sort the tuples in items in descending order by frequency
        sortedItems = sorted(items, key=itemgetter(1), reverse=True)
        # Sort out the top 20 words count in ascending order.
        sortedAnswer = sortedItems[1:]
        # Create a list named ListOne to be used in the wordCloud
        listOne = []
        # Append all the items.
        listOne.append(sortedAnswer)
        # Create a variable named starImage to use the file mask_star for the
        # wordcloud design.
        starImage = imageio.imread('mask_star.png')
        # Create the size, number of words, word color, 
        # mask, and background color of the WordCloud
        wordcloud = WordCloud(width=2000, height=1800, max_words=100, \
                              colormap='prism', mask=starImage, \
                              background_color='black')
        # Generate the Start Shaped WordCloud using the list of words created
        wordcloud = wordcloud.generate(str(listOne))
        # Save the wordcloud as a file
        wordcloud = wordcloud.to_file('WebStarImage_KingJon.png')
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
                # Display the results in a new window.
                img = Image.open('WebStarImage_KingJon.png')
                img.show()
                # Delete newly created file
                os.remove("WebStarImage_KingJon.png")
        # Restart exerOneTwoOne() module
        exerOneTwoOne()
# exerOneTwoTwo() Module.
def exerOneTwoTwo():
    try:
        # Display intro from the menu option 1
        print('-----------------------------------------------')
        print("|Please Wait While I Complete Exercise 12.2...|")
        print('-----------------------------------------------')
        # Create object 'getPy' to recieve esignated webpage
        getPy = requests.get("https://www.python.org")
        # Create Beautiful Soup Object to read html5lib coding for the 
        # designated website in the object getPy
        beaSoup = BeautifulSoup(getPy.content, "html5lib")
        # Extract the webpage words without the browser structural
        pythonBlob = TextBlob(beaSoup.get_text(strip = True))     
    except ValueError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
        main()
    else:
        # Varible stopWords used to eliminate the stopwords in the english 
        # language
        stopWords = stopwords.words('english')
        # Variable answer used to delete all stop words from the website
        answer = [word for word in pythonBlob.words if word not in stopWords]
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
                print('|               DISPLAY THE...         |')
                print('----------------------------------------')
                print('|1 -   Tokenizing Text and Noun Phrases|')
                print('|2 -   Number of Sentences, Words      |')
                print('|      Without Stop Words and Noun     |')
                print('|      Phrases                         |')
                print('|3 -   Return to the Menu              |')
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
                        tokenChars(getPy, beaSoup, pythonBlob, answer)
                    # Else/If variable menuAnswer is equal to 2.    
                    elif menuAnswer == 2:
                        countChars(getPy, beaSoup, pythonBlob)
                    # Else/If variable menuAnswer is equal to 3.
                    elif menuAnswer == 3:
                        main()
                    # Else/If variable menuAnswer is equal to 4.
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
                        # Restart main module
                        main()                
# countChars() module
def countChars(getPy, beaSoup, pythonBlob):
    # Count holding variable
    i = 0
    # Display intro from the menu option 1
    print('------------------------------')
    print('|          DISPLAY THE...    |')
    print('------------------------------')
    print('|1 -   Number of Sentences   |')
    print('|2 -   Number of Words       |')
    print('|3 -   Number of Noun Phrases|')
    print('|4 -   Return to the Menu    |')
    print('------------------------------')
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
            print('|-----------------------------------------'\
                  '--------|')
            for sentence in pythonBlob.sentences:
                i = (i + 1)
            print("|There are a total of",i,"sentences in the "\
                  "html page|")
            print('|-----------------------------------------'\
                  '--------|\n\n')
            # Return to 12.2 Counting Questions
            countChars(getPy, beaSoup, pythonBlob)
        # Else/If variable menuAnswer is equal to 2.    
        elif menuAnswer == 2:
            # Display the results.
            print('|---------------------------------------'\
                  '--------|')
            for words in pythonBlob.words:
                i = (i + 1)
            print("|There are a total of",i,"words in the "\
                  "html page|")
            print('|---------------------------------------'\
                  '--------|\n\n')
            # Return to 12.2 Counting Questions
            countChars(getPy, beaSoup, pythonBlob)
        # Else/If variable menuAnswer is equal to 3.
        elif menuAnswer == 3:
            # Display the results.
            print('|--------------------------------------'\
                  '----------------|')
            for nouns in pythonBlob.noun_phrases:
                i = (i + 1)
            print("|There are a total of",i,"noun phrases in "\
                  "the html page|")
            print('|--------------------------------------'\
                  '----------------|\n\n')
            # Return to 12.2 Counting Questions
            countChars(getPy, beaSoup, pythonBlob)
        # Else/If variable menuAnswer is equal to 4.
        elif menuAnswer == 4:
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
            # Restart main module
            main()
# tokenChars() module
def tokenChars(getPy, beaSoup, pythonBlob, answer):
    # Display intro from the menu option 1
    print('------------------------------')
    print('|          DISPLAY THE...    |')
    print('------------------------------')
    print('|1 -   Tokenized Sentences   |')
    print('|2 -   Tokenized Words       |')
    print('|3 -   Tokenized Noun Phrases|')
    print('|4 -   Return to the Menu    |')
    print('------------------------------')
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
            for sentences in pythonBlob.sentences:
                print(sentences)
            # Return to 12.2 Tokenized Questions
            tokenChars(getPy, beaSoup, pythonBlob, answer)
        # Else/If variable menuAnswer is equal to 2.    
        elif menuAnswer == 2:
            # Display the results.
            for words in pythonBlob.words:
                print(words)
            # Return to 12.2 Tokenized Questions
            tokenChars(getPy, beaSoup, pythonBlob, answer)
        # Else/If variable menuAnswer is equal to 3.
        elif menuAnswer == 3:
            # Display the results.
            for nouns in pythonBlob.noun_phrases:
                print(nouns)
            # Return to 12.2 Tokenized Questions
            tokenChars(getPy, beaSoup, pythonBlob, answer)
        # Else/If variable menuAnswer is equal to 4.
        elif menuAnswer == 4:
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
            # Restart main module
            main()
# Module display().
def display():
    # Display GUI for menu options.
    print('-----------------------------')
    print('|             MENU          |')
    print('-----------------------------')
    print('|  1)	Start Exercise 12.1 |')
    print('|  2)	Start Exercise 12.2 |')
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