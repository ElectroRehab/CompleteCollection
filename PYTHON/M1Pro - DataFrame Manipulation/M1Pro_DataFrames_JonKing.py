# A brief description of the project:
# Introduction:
# In this assignment students are to create a program that allows 
# user to student names and scores, the program is to also allow
# defining the subject the grades are being entered for. The 
# entered information is to be stored in a DataFrame
#
# Instructions:
# For this assignment, you will do the following:
#   1.  Create a Python code file named
#       M1Pro_DataFrames_FirstLast.py 
#       (replace "FirstLast" with your own name)
#   2.  Add a title comment block to the top of
#       the new Python file using the following
#       form
# Part 1 = 70 points
#   3.  As explained in the introduction above,
#       the program is for saving student scores
#       for a specific number of tests.
#   4.  First, the program is to ask user how
#       many tests are the grades for. If 4 
#       entered for instance, the program is to
#       ask user to enter test names. This would
#       be used as indices for the grades that
#       will be entered. ( 20 points )
#   5.  Next, the program is to ask user the
#       number of students they would like to
#       enter grades for. Then the program is to
#       ask user to enter dictionary information
#       as following: ( 50 points)
#           •	Student Name
#           •	List of grades (4 grades minimum)
#   *   Note: it’s important that the program allows
#       entering name and grades for more than one
#       student.
#   **  Make sure that a dataFrame is created to
#        store all of the information collected.
#   6.  Display the DataFrame content and verify
#       that test names were assigned as labels
#       for each row (10 points)
#   7.  Calculate average for each Student and display 
#       results. Ex, what’s Tom’s average ? do this 
#       for all students in DataFrame (10 points)
#
# An example of the outcome is shown below
# 22JAN20
# CSC221 M1Pro – DataFrame
# Jon King
# 
#
#
# Import Pandas built in Python
import pandas as pd
# Create a blank dictionary with the variable 'createDiciton' to use later
createDiction = dict()
# Create a blank dictionary for the average grades per student.
averageDiction = dict()
# Variable 'subjectInt' used to determine how many subjects to input
subjectInt = int(input('How Many Subjects Would You Like To Input?:'))
# While loop to enure that user inputs a minimum of 4 subjects
while subjectInt < 4:
    print('|------------------------------------|')
    print('|Please enter a minimum of 4 Subjects|')
    print('|------------------------------------|')
    subjectInt = int(input('How Many Subjects Would You Like To Input?: '))
# Variable 'subjectNames' used to determine the actual names to be used.
subjectNames = [input("Enter Subject "+str(i+1)+"'s Title: ") for i in 
                range(subjectInt)]
# Variable 'studentInt' used to determine how many students to input
studentInt = int(input('How Many Students Would Like To Enter Grades For?: '))
# For Loop to input Student's Grades in order of subjects and students
for i in range(studentInt):
    # Variable 'studentNames' used to enter the Students Name's
    studentNames = input("Enter Student "+str(i+1)+ "'s Name: ")
    # Variable 'studentScores' with a For Loop to add to each student's 
    # grades one at a time.
    studentScores = [int(input("Enter "+str(studentNames)+
                               "'s grade for Subject "+str(i+1)+
                               ": ")) for i in range(subjectInt)]
    # Dictionary update to insert all user inputted information and sort it.
    createDiction.update({studentNames:studentScores})
# Variable 'grades' to combine all information into a DataFrame to view later.
grades = pd.DataFrame(createDiction, index=[subjectNames])
# For Loop to input Student's and Grade Averages.
for keys, values in createDiction.items():
    # Variable 'setup' used to calculate inputted information
    setup = sum(values)/subjectInt
    # 'averageDiction' update for keys used in 'createDiction' with calculations
    averageDiction.update({keys:setup})
    # Variable 'averages' used to create DataFrame for averages
    averages = pd.DataFrame(averageDiction, index=[""])
# Display the DataFrame from all combined user input information.
print('')
print('---------------------')
print('|CLASS RESULTS BELOW|')
print('---------------------')
print(grades)
print('')
print('-----------------------')
print('|AVERAGE RESULTS BELOW|')
print('-----------------------')
print(averages)