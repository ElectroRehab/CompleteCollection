# M6Pro (Classification with K-Nearest)
# Introduction:
# The assignment introduces students to the concept of Machine learning and 
# how it’s applied to classify information and make predictions.
#
# Instructions:
# For this assignment you will complete 15.2 and 15.3 case studies 
# ( Classification with k-nearest Neighbors Part 1 & 2. )
#
# 1. Create a Python code file named M6Pro_kNearest_FirstLast.py 
#    (replace "FirstLast" with your own name)
#
# 2. Add a title comment block to the top of the new Python file using 
#    the following form:
#
#   # A brief description of the project
#   # Date
#   # CSC221 M6Pro – kNearest
#   # Your Name
#
# 3. Part 1 (70 points)
# Complete case study part 1 (15.2 Classification with k-Nearest Neighbors 
# and the Digits Dataset) on page 599.
#
# Make sure that the statements are added to a program and not just executed 
# in interactive mode. Add print statements to display the following:
#   A) Data array of image in index position 13 ( referenced in textbook)
#   B) The first 24 images in digits.images and the first 24 values in 
#      digits.target ( referenced in textbook also)
#   C) Cases in which predicted and expected values do not match 
#
# 4. Part 2 (20 points)
# Go to case study part 2 (15.3 Classification with k-Nearest Neighbors 
# and the Digits Dataset) on page 612.
#
# Complete the following sections:
#   A) 15.3.1 Metrics for Model Accuracy (display confusion Matrix)
#   B) Classification Report (page 613) Display report
#   C) Visualizing the confusion Matrix (plot and display confusion matrix)
#
# Grading criteria:
#   A) Shown next to each required point in instructions above
#   B) Pseudocode and block comment (10 points )
#
# A brief description of the project (SHOWN ABOVE ^^^)
# 10APR20
# CSC221 M6Pro – kNearest
# Jon King

# IMPORT SECTION
# from sklearn.metrics import train_test_split, confusion_matrix, 
# classification_report, load_digits, & KNeighborsClassifier
from sklearn.datasets import load_digits
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report
from sklearn.neighbors import KNeighborsClassifier
from sklearn.metrics import confusion_matrix
# import matplotlib.pyplot to display plot for cofusion matrix
import matplotlib.pyplot as plt
# import pandas to create database in the creation of a graph.
import pandas as pd
# import seaborn to create graph.
import seaborn as sns

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
            # Call caseStudyFiveTwo() module
            caseStudyFiveTwo()
        # Else/If variable menuStart is equal to 2.    
        elif menuStart == 2:
            # Call caseStudyFiveThree() module
            caseStudyFiveThree()
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
# Module caseStudyFiveTwo().
def caseStudyFiveTwo():
    # Display GUI for menu options.
    print('----------------------------------------------------')
    print('|                    DISPLAY THE...                |')
    print('----------------------------------------------------')
    print('|  1)	Data Array of Image in Index Position - 13 |')
    print('|  2)	First 24 Images in digits.images           |')
    print('|  3)   First 24 Values in digits.target           |')
    print('|  4)	Cases in which predicted and expected      |')
    print('|    	values do not match                        |')
    print('|  5)	Exit                                       |')
    print('----------------------------------------------------')
    try:
        # Create object digits to be used as 
        # load_digits() from sklearn.datasets
        digits = load_digits()
        # Object ansOneTarget used to determine index position 13
        ansOneTarget = digits.target[13]
        # Object ansOne used display Data array of image in index position 13
        ansOne = digits.images[ansOneTarget]
        # Object ansTwo used to display the first 24 images in digits.images
        ansTwo = digits.images[:24]
        # Object ansThree used to display the first 24 values in digits.target
        ansThree = digits.target[:24]
        # Create object knn as the estimator implements the 
        # k-nearest neighbors algorithm
        knn = KNeighborsClassifier()
        # Splitting the data for training and testing
        X_train, X_test, y_train, y_test = train_test_split\
        (digits.data, digits.target, random_state=11)
        # Load sample training sets
        knn.fit(X=X_train, y=y_train)
        # Return the array containing the predicted class of each test image.
        predicted = knn.predict(X=X_test)
        # Return the array containing the expected class of each test image.
        expected = y_test
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
            print(ansOne)
            caseStudyFiveTwo()
        # Else/If variable menuAnswer is equal to 2.    
        elif menuAnswer == 2:
            # Display the results.
            print(ansTwo)
            caseStudyFiveTwo()
        # Else/If variable menuAnswer is equal to 3.
        elif menuAnswer == 3:
            # Display the results.
            print(ansThree)
            caseStudyFiveTwo()            
        # Else/If variable menuAnswer is equal to 4.
        elif menuAnswer == 4:
            # Display the results.
            print('    |------------------------------|')
            print('    |Here are the Predicted Choices|')
            print('    |------------------------------|')
            print(predicted[:20])
            print('\n    |-----------------------------|')
            print('    |Here are the Expected Choices|')
            print('    |-----------------------------|')
            print(expected[:20])
            # Locate all incorrect predictions for the entire test set
            wrong = [(p, e) for (p, e) in zip(predicted, expected) if p != e]
            print('\n            |-------------------------|')
            print('            |The Incorrect Predictions|')
            print('            |-------------------------|')
            print(wrong)
            caseStudyFiveTwo()
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
# Module caseStudyFiveThree().
def caseStudyFiveThree():
    # Display GUI for menu options.
    print('-----------------------------------------')
    print('|              DISPLAY THE...           |')
    print('-----------------------------------------')
    print('|  1)	Confusion Matrix               |')
    print('|  2)	Classification Report          |')
    print('|  3)   Visualize the Confusion Matrix |')
    print('|  4)	Exit                           |')
    print('-----------------------------------------')
    try:
        # Create object digits to be used as 
        # load_digits() from sklearn.datasets
        digits = load_digits()
        # Create object knn as the estimator implements the 
        # k-nearest neighbors algorithm
        knn = KNeighborsClassifier()
        # Splitting the data for training and testing
        X_train, X_test, y_train, y_test = train_test_split\
        (digits.data, digits.target, random_state=11)
        # Load sample training sets
        knn.fit(X=X_train, y=y_train)
        # Return the array containing the predicted class of each test image.
        predicted = knn.predict(X=X_test)
        # Return the array containing the expected class of each test image.
        expected = y_test
        # Show correct and incorrect predicted values
        confusion = confusion_matrix(y_true=expected, y_pred=predicted)
        # Convert the confusion matrix into a Dataframe
        confusion_df = pd.DataFrame(confusion, index=range(10), \
                                    columns=range(10))
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
            print('------------------------------')
            print('|      Confusion Matrix      |')
            print('------------------------------')
            print(confusion)
            caseStudyFiveThree()
        # Else/If variable menuAnswer is equal to 2.    
        elif menuAnswer == 2:
            # Display the results.
            print('-------------------------------')
            print('|    Classification Report    |')
            print('-------------------------------')
            names = [str(digit) for digit in digits.target_names]
            print(classification_report(expected, predicted, \
                                        target_names=names))
            caseStudyFiveThree()
        # Else/If variable menuAnswer is equal to 3.
        elif menuAnswer == 3:
            # Display the results.
            print('|------------------------------|')
            print('|        End Program to        |')
            print('|Visualize the Confusion Matrix|')
            print('|------------------------------|')
            # Graph the confusion matrix 
            plt.figure(figsize=(7, 6))
            sns.heatmap(confusion_df, annot=True, 
                       cmap=plt.cm.nipy_spectral_r)
            caseStudyFiveThree()           
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
    print('--------------------------------')
    print('|              MENU            |')
    print('--------------------------------')
    print('|  1)	Start Case Study 15.2 |')
    print('|  2)	Start Case Study 15.3 |')
    print('|  3)	Exit                  |')
    print('--------------------------------')
# Module ending()
def ending():
    # Display Thank you message & exit program.
    print('--------------------------------')
    print('|Thanks for using this program!|')
    print('--------------------------------')
# PROGRAM START
main()