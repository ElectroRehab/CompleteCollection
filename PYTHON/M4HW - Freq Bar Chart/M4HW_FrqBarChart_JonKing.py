# M4HW (Word Frequency Bar Chart)
# Introduction:
# The assignment requires good understanding of NLP Tool Kit and TextBlob 
# library and the different functions they contain for analyzing and 
# manipulating text
# 
# Instructions:
# For this assignment you will complete exercise 12.06 on 
# page 512 of your textbook. 
#
# 1.Create a Python code file named M4HW_FrqBarChart_FirstLast.py 
# (replace "FirstLast" with your own name)
# 2. Add a title comment block to the top of the new Python file using 
#    the following form
#
#   A) # A brief description of the project
#   B) # Date
#   C) # CSC221 M4HW – FrqBarChart
#   D) # Your Name
#
# 3. Part 1 (70 points)
#   A) Download “Shakespeare’s Hamlet” from the Project Gutenberg site as 
#      explained on page 480
#   B) Eliminate stop words.
#   C) Create a top-20 word frequency bar chart.
#
# 4. Part 2 (20 points)
#   A) Create a word cloud for the top-20 words you prepared in step 3. 
#      You will have to install wordcloud library , the text book provides 
#      instructions on how to do this. Check page 501
#   B) There different image that you use for this task , the image are 
#      available in the folder titled “Intro to Python Slides” under 
#      “Optional Resources” tab. Once you’ve downloaded the folder, go to 
#      the “examples” folder then  “ch12” folder, the image are available 
#      there.
#
# 5. Grading criteria:
#   A)Shown next to each required point in instructions above
#   B) Pseudocode and block comment (10 points)
# 
# A brief description of the project - (Displayed Above)
# 19MAR20
# CSC221 M4HW – FrqBarChart
# Jon King

# import OS to delete created picture files from 
# user's computer that are opened with the program.
import os
# Import imageio to create a picture out of the top 20 words
import imageio
# Import pandas to create a dataframe of the top 20 words
import pandas as pd
# Import matplotlib.pyplot to display a Matplotlib bar chart
import matplotlib.pyplot as plt
# Import Path class from Python Standard Library pathlib
from pathlib import Path
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
            # Call destroyStopWords() module
            destroyStopWords()
        # Else/If variable menuStart is equal to 2.    
        elif menuStart == 2:
            # Call top20Freq() module
            top20Freq()
        # Else/If variable menuStart is equal to 3.
        elif menuStart == 3:
            # Call maskImage() module
            maskImage()
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
# destroyStopWords() Module.
def destroyStopWords():
    try:
        # Create the variable RomJulBlob to read the file RomeoAndJuliet.txt
        # as a TextBlob item
        RomJulBlob = TextBlob(Path('CVK_da_31_TRANSITION (1).PDF').read_text())
        print(RomJulBlob) 
    except ValueError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
        main()
    else:
        # Display intro from the menu option 1
        print('-----------------------------------------------------')
        print("|Please Wait While I Eliminate All The Stop Words...|")
        print('-----------------------------------------------------')
        # Varible stopWords used to eliminate the stopwords in the english 
        # language
        stopWords = stopwords.words('english')
        # Variable answer used to delete all stop words from the file
        # 'RomeoAndJuliet.txt'
        answer = [word for word in RomJulBlob.words if word not in stopWords]
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
                print('------------------------------------')
                print('|            DISPLAY THE...        |')
                print('|1 -     Eliminated Stop Words     |')
                print('|2 - Text File Words W/O Stop Words|')
                print('|3 -     Return to the Menu        |')
                print('------------------------------------')
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
                    # Else/If variable menuAnswer is equal to 2.    
                    elif menuAnswer == 2:
                        # Display the results.
                        print(answer)
                    # Else/If variable menuAnswer is equal to 3.
                    elif menuAnswer == 3:
                        # Restart main module
                        print('\n')
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
        # Restart main module
        main()
# top20Freq() Module.
def top20Freq():
    try:
        # Create the variable RomJulBlob to read the file RomeoAndJuliet.txt
        # as a TextBlob item
        RomJulBlob = TextBlob(Path('RomeoAndJuliet.txt').read_text())
    except ValueError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
        main()
    else:
        # Display intro from the menu option 1.
        print('----------------------------------------------------------')
        print("|Please Wait While I Create Top-20 Frequency Bar Chart...|")
        print('----------------------------------------------------------')
        # Varible stopWords used to eliminate the stopwords in the english 
        # language
        stopWords = stopwords.words('english')
        # Use the function 
        items = RomJulBlob.word_counts.items()
        # Variable answer used to delete all stop words from the file
        # 'RomeoAndJuliet.txt'
        items = [item for item in items if item[0] not in stopWords]
        # Sort the tuples in items in descending order by frequency
        sortedItems = sorted(items, key=itemgetter(1), reverse=True)
        # Sort out the top 20 words count in ascending order.
        top20Answer = sortedItems[1:21]
        # Create a dataframe from the sorted items
        df = pd.DataFrame(top20Answer, columns=['Words', 'Total Count'])
        # Display the results.
        df.plot.bar(x='Words', y='Total Count', legend=False)
        plt.gcf().tight_layout()
        # Save the bar chart as a file
        plt.savefig('RomJulBarChart_KingJon.png')
        # Pause Section
        try:
            # User input to make to continue.
            stopGoPoint = input('Enter any key(s) to continue')
        # Exception ValueError Display
        except ValueError:
            print('-----------------------------------')
            print('|That is not a valid menu response|')
            print('|        Please Try Again.        |')
            print('-----------------------------------')
            print()
            # User input to make to continue.
            stopGoPoint = int(input('Enter any key(s) to continue'))
        else:
            if stopGoPoint == stopGoPoint:
                # Display the results.
                img = Image.open('RomJulBarChart_KingJon.png')
                img.show()
                # Delete newly created file
                os.remove("RomJulBarChart_KingJon.png")
        # Restart main module
        main()
# statCarat() Module with the variable 'df' passed inside.
def maskImage():   
    try:
        # Create the variable RomJulBlob to read the file RomeoAndJuliet.txt
        # as a TextBlob item
        RomJulBlob = TextBlob(Path('RomeoAndJuliet.txt').read_text())
    except ValueError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
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
        items = RomJulBlob.word_counts.items()
        # Variable answer used to delete all stop words from the file
        # 'RomeoAndJuliet.txt'
        items = [item for item in items if item[0] not in stopWords]
        # Sort the tuples in items in descending order by frequency
        sortedItems = sorted(items, key=itemgetter(1), reverse=True)
        # Sort out the top 20 words count in ascending order.
        top20Answer = sortedItems[1:21]
        # Create a list named ListOne to be used in the wordCloud
        listOne = []
        # Append all the items within top 20 words count.
        listOne.append(top20Answer)
        # Create a variable named ovalImage to use the file mask_oval for the
        # wordcloud design.
        ovalImage = imageio.imread('mask_oval.png')
        # Create the size, number of words, word color, 
        # mask, and background color of the WordCloud
        wordcloud = WordCloud(width=2287, height=1323, max_words=20, \
                              colormap='prism', mask=ovalImage, \
                              background_color='cyan')
        # Generate the Oval Shaped WordCloud using the list of words created
        # from the top 20 words of the
        wordcloud = wordcloud.generate(str(listOne))
        # Save the wordcloud as a file
        wordcloud = wordcloud.to_file('RomJulOval_KingJon.png')
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
                img = Image.open('RomJulOval_KingJon.png')
                img.show()
                # Delete newly created file
                os.remove("RomJulOval_KingJon.png")
        # Restart main module
        main()
# Module display().
def display():
    # Display GUI for menu options.
    print('--------------------------------------------------')
    print('|                       MENU                     |')
    print('--------------------------------------------------')
    print('|  1)	Eliminate Stop Words                     |')
    print('|  2)	Create a Top-20 Word Frequency Bar Chart |')
    print('|  3)	Create a Top-20 Word Cloud               |')
    print('|  4)	Exit                                     |')
    print('--------------------------------------------------')
# Module ending()
def ending():
    # Display Thank you message & exit program.
    print('--------------------------------')
    print('|Thanks for using this program!|')
    print('--------------------------------')
# PROGRAM START
main()

