# 1) Download diamonds.csv from one of the dataset repositories.
# 2) Load the dataset into pandas DataFrame with the following statement,
#    which uses the first column of each record as the row index:
#   A) df = pd.read_csv(diamonds.csv, index_col=0)
# 3) Display the 1st 7 rows of the DataFrame
# 4) Display the last 7 rows of the DataFrame
# 5) Use the DataFrame method describe (which only looks at the numeric 
#    columns) to calculate the descriptive statistics for the numerical
#    columns:
#   A) Carat
#   B) Depth
#   C) Table
#   D) Price 
#   E) x 
#   F) y 
#   G) z
# 6) Use Series method describe to calculate the descriptive statistics for
#    the categorical data (text) columns:
#   A) Cut
#   B) Color
#   C) Clarity
# 7) What are the unique category values (use the Series method unique)?
# 8) Pandas has many built in graphing capabilities. Excecute the %matploylib
#    magic to enable Matplotlib support in iPython. Then, to view histograms 
#    of each numerical data column, call your DataFrame's hist method.
# A brief description of the project - (Displayed Above)
# 21FEB20
# CSC221 M2HW1 – FileExceptions
# Jon King

import pandas as pd
# main() Module with the variable 'df' passed inside.
def main(df):
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
        main(df)
    else:
        # Else/If Statement variable menuStart is equal to 1  
        if menuStart == 1:
            # Call firstSeven() module
            firstSeven(df)
        # Else/If variable menuStart is equal to 2.    
        elif menuStart == 2:
            # Call lastSeven() module
            lastSeven(df)
        # Else/If variable menuStart is equal to 3.
        elif menuStart == 3:
            # Call statCarat() module
            statCarat(df)
        # Else/If variable menuStart is equal to 4.
        elif menuStart == 4:
            # Call statThreeCs() module
            statThreeCs(df)
        # Else/If variable menuStart is equal to 5.
        elif menuStart == 5:
            # Call uniqueThreeCs() module
            uniqueThreeCs(df)
        # Else/If variable menuStart is equal to 6.
        elif menuStart == 6:
            # Call displayGraph() module
            displayGraph(df) 
        elif menuStart == 7:
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
            main(df)  
# firstSeven() Module with the variable 'df' passed inside.
def firstSeven(df):
    # Display intro from the menu option 1
    print('-------------------------------------------------')
    print('|Here are the first seven lines of the CSV File.|')
    print('-------------------------------------------------')
    # Display the 1st 7 rows of the DataFrame
    print(df.head(7))
    main(df)
# lastSeven() Module with the variable 'df' passed inside.
def lastSeven(df):
    # Display intro from the menu option 2
    print('------------------------------------------------')
    print('|Here are the last seven lines of the CSV File.|')
    print('------------------------------------------------')
    # 4) Display the last 7 rows of the DataFrame
    print(df.tail(7))
    main(df)
# statCarat() Module with the variable 'df' passed inside.
def statCarat(df):   
    # Display intro from the menu option 3
    print('---------------------------------------------------------------')
    print('|Here are the descriptive statistics for "Carat" the CSV File.|')
    print('---------------------------------------------------------------')
    # Reads file and displays the descriptive statistics for the numerical col
#    calcCarat = pd.Series(['carat'])
#    print(calcCarat.describe())
    print(df.carat.describe())
    main(df)
def statThreeCs(df):
    # Display intro from the menu option 4
    print('---------------------------------------------------------------')
    print('|   Here are the descriptive Statistics for   |\n'
          +'|“Cut”, “Color” and “Clarity” in the CSV File.|')
    print('---------------------------------------------------------------')
    # Reads file and displays the descriptive statistics for the category cols
    calcThreeCs = pd.Series(['cut', 'color','clarity'])
    print(calcThreeCs.describe())
    #return to the main() module
    main(df)
# uniqueThreeCs() Module with the variable 'df' passed inside.
def uniqueThreeCs(df):
    # Display intro from the menu option 5
    print('---------------------------------------------')
    print('|   Here are the Unique Category Values for   |\n'
          +'|“Cut”, “Color” and “Clarity” in the CSV File.|')
    print('---------------------------------------------')
    # Reads file and displays the unique category values
    uniqueCut = df['cut'].unique()
    uniqueColor = df['color'].unique()
    uniqueClarity = df['clarity'].unique()
    print(uniqueCut, "\n",uniqueColor,"\n", uniqueClarity)
    # Returns to the main() module
    main(df)
# displayGraph() Module with the variable 'df' passed inside.
def displayGraph(df):
    # Display intro from the menu option 6
    print('----------------------------------------------')
    print('|        Please exit the program to         |\n'
          +'|Display Histogram of each Numerical Column.|')
    print('-----------------------------------------------')
    # Pause in program to allow user to end the program now, or continue back
    # to the menu options to select another option.
    test = input("Press any key to continue\n  Or '7' to exit now...")
    # If/Elif/Else statements to determine if the user wants to end the program
    # now or return to the menu. Including the creation of the histogram that
    # will start as soon as the program is directed to the ending() module to
    # finish out the program. 
    if test != '7':
        df.hist()
        main(df)
    elif test == '7':
        df.hist()
        ending()
    else:
        main(df)
# Module display().
def display():
    # Display GUI for menu options.
    print('--------------------------------------------------------------'
         +'-------------')
    print('|                                   MENU                      '
         +'            |')
    print('--------------------------------------------------------------'
         +'-------------')
    print('|  1)	                Display First Seven Rows              '
         +'            |')
    print('|  2)	                Display Last Seven Rows               '
         +'            |')
    print('|  3)	        Calculate Descriptive Statistics for “Carat”  '
         +'            |')
    print('|  4)	Calculate Descriptive Statistics for “Cut”, “Color” '
         +'and “Clarity” |')
    print('|  5)	 Display Unique Category Values for “Cut”, “Color” '
         +'and “Clarity”  |')
    print('|  6)	         Display Histogram of each Numerical Column   '
         +'            |')
    print('|  7)	                       Exit Program                   '
         +'            |')
    print('---------------------------------------------------------------'
          +'------------')
# Module ending()
def ending():
    # Display Thank you message & exit program.
    print('--------------------------------')
    print('|Thanks for using this program!|')
    print('--------------------------------')
    print('--------------------------------')
    print('|   Here is your histogram!!!  |')
    print('--------------------------------')
# PROGRAM START
# Intro
print('------------------------')
print("|Let's Read a CSV File!|")
print('------------------------')
# Load dataset into a DataFrame
runThat = input('--------------------------------'
                +'\n|Enter any key to load the file|\n|"diamonds.csv"'
                +'into a DataFrame|\n--------------------------------')
if runThat == runThat:
    df = pd.read_csv("diamonds.csv", index_col=0)
    print('---------------------------------')
    print('|CONGRATS - THAT WAS SUCCESSFUL!|')
    print('---------------------------------')
else:
    # Load dataset into a DataFrame
    df = pd.read_csv("diamonds.csv", index_col=0)
    print('---------------------------------')
    print('|CONGRATS - THAT WAS SUCCESSFUL!|')
    print('---------------------------------')
# Call main() module
main(df)