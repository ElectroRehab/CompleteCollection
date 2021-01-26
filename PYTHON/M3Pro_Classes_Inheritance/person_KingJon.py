# M3Project (Classes and Inheritance)
# Introduction:
# The assignment requires good understanding of several core concepts, 
# File I/O , Exception Handling, Modules and Object Orientation
# Instructions:
# For this project, you will do the following:
# Download the person.py module 
# Note: Before you start, consider dividing the program to Modules (10 points)
# 1. Create a subclass of the Person class, name it Employee. 
#    The Employee class will have the additional following 
#    attributes and methods: (10 points)
#   A) attribute: email (last name + "."+ "first name"+ @company.com)
#   B) attribute : position
#   C) attribute: salary
#   D) attribute:full_part_time
#   E) methods (create required accessors and mutators)
#
# 2. Create program that does following:
#   1. Displays a menu with following options (10 points)
#       A) Enter Employee info
#       B) Read Employee Info
#       C) Exit
# 3) If user enters 1, program is to ask user how many employees’ 
#    information do they want to enter. (10 points)
# 4) After user enters number of Employees information they want to enter, 
#    user should be prompted to enter employee information (one at a time)
# 5) Once information is entered, it is to be stored in a list 
# 6) After ALL Employee information is entered, information is to be 
#    written to a file ( in a tabular format, example shown below) (10 points)
# First Name	Last Name	Email(company email)	Position	Full/Part time	Salary
#    Tom	      Smith	   smith.tom@company.com	Manager	         Full	     2000
#
# 7) If user enters 2 (Reading Employee info), verify that employee.txt file 
#    exists, if not , notify the user. Hint: Exception handling (10 points)
# 8) If file exists, read information (each line to be stored as a class 
#    record in a list) then display the information in a tabular format to 
#    the user (10 points)
# 9. If user enters 3, the program should terminate. (10 points)
#
# Note: if user’s choice is invalid, NOT a valid menu option , notify the 
#       user that the choice is invalid. Display the menu again and prompt 
#       them to make a valid choice (10 points)
# Submit your finished code solution file(s) through the assignment link below
# Grading criteria:
# Shown next to each required point in instructions above
# Pseudocode and block comment (10 points )

# A brief description of the project - (Displayed Above)
# 07MAR20
# CSC221 M3Project (Classes and Inheritance)
# Jon King
class Person:
    """Person Class"""
    def __init__(self, firstName,lastName, email):
        """Initialize an Invoice object."""
        self.__firstName = firstName
        self.__lastName = lastName
        self.__email = email
# Setters
    def set_firstName(self, firstName):
        """Set First Name from User."""
        self.__firstName = firstName
    def set_lastName(self, lastName):
        """Set Last Name from User."""
        self.__lastName = lastName
    def set_email(self, email):
        """Set Email from User."""
        self.__email = email
# Getters    
    def get_firstName(self):
        """Retrieve First Name from User."""
        return self.__firstName        
    def get_lastName(self):
        """Retrieve last name from User."""
        return self.__lastName    
    def get_email(self):
        """Retrieve email info from User."""
        return self.__email    
    def __str__(self):
        """Return Person info"""
        return (f'{self.__firstName}{self.__lastName}{self.__email}')
class Employee(Person):
    """Employee Subclass"""
    def __init__(self, firstName, lastName, email, position, salary, \
                 full_part_time):
        super().__init__(firstName, lastName, email)
        self.__position = position
        self.__salary = salary
        self.__full_part_time = full_part_time
   # Setters    
    def set_position(self, position):
        """Set position from User."""
        self.__position = position
    def set_salary(self, salary):
        """Set salary from User."""
        self.__salary = salary
    def set_full_part_time(self, full_part_time):
        """Set Full or Part Time from User."""
        self.__full_part_time = full_part_time
# Getters        
    def get_position(self):
        """Retrieve position info from User."""
        return self.__position

    def get_salary(self):
        """Retrieve salary info from User."""
        return self.__salary

    def get_full_part_time(self):
        """Retrieve Full/Part Time info from User."""
        return self.__full_part_time
    
    def __str__(self):
        """Return Employee info"""
        return (f'{self.__position}{self.__salary}{self.__full_part_time}')
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
    else:
        # Else/If Statement variable menuStart is equal to 1  
        if menuStart == 1:
            # Call firstChoice() module
            firstChoice(Person, Employee)
        # Else/If variable menuStart is equal to 2.    
        elif menuStart == 2:
            # Call secondChoice() module
            secondChoice(Person, Employee)
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
# firstChoice() Module.
def firstChoice(Person, Employee):
        # Create list to store in employee info
        employees = []
        # Variable used to determine how many employees to add to the list
        howMany = int(input('How many employees do you want to enter? '))
        # For loop for inputting employee information
        for emp in range(1, howMany+1):
            # Intro
            print("\nEnter info for employee",emp)
            # Variable used to determine employees first name
            firstName = input("Enter first name: ")
            # Variable used to determine employees last name
            lastName = input("Enter last name: ")
            # Variable used to determine employees email address
            email = (f'{firstName.lower()}.{lastName.lower()}@company.com')
            # Variable used to determine employees position
            position = input("What is "+firstName+"'s position? ")
            # Variable used to determine employees salary
            salary = float(input("What is "+firstName+"'s salary? "))
            # Variable used to determine employees work status
            full_part_time = input("Is "+firstName+"'s full or part time? \n"\
                                   "(Full/Part): ")
            # Variable used to format employees salary into string
            str_salary = f'{salary:.2f}'
            # Variable used to add all user inputted information through 
            # all the classes Person & Employee
            empInfo = Employee(firstName, lastName, email, position, \
                               str_salary , full_part_time)
            # Append all user inputted info into the created list.
            employees.append(empInfo)
        # Title bar intro for displaying information
        title = "\nFirst Name\t"+"Last Name\t"+"Email(Company Name)\t\t"\
                +"Position\t"+"Full/Part Time\t"+"Salary\n"
        line = "--------------------------------------------------------"\
               "----------------------------------------------------"
        # Open and write to a file named 'employee.txt'. 
        with open('employee.txt','w') as outFile:
                
            # Write header intro 
            outFile.write(title+line+"\n")
            # For loop to begin writing to file.
            for emp in employees:
                 # Variable used to write to file 'outFile' in a specific 
                 # manner to look presentable.
                formatEmployees = emp.get_firstName().ljust(16)+\
                emp.get_lastName().ljust(16)+emp.get_email().ljust(32)+\
                emp.get_position().ljust(16)+\
                emp.get_full_part_time().ljust(16)+"$"+\
                emp.get_salary().ljust(20)+"\n"
                # Write all info entered by user to the file.
                outFile.write(formatEmployees)
        # Return to the menu to determine next step.
        main()
# secondChoice() Module.
def secondChoice(Person, Employee):
    # Try to open the file 'employee.txt'
    try:
        with open('employee.txt', 'r') as inFile:
            # Display intro from the menu option 2
            print('----------------------------------')
            print('|Below is the file emp_report.txt|')
            print('----------------------------------')
            # For loop to read line by line
            for line in inFile:
                line = inFile.read()
                print(line)
    # Error Message
    except FileNotFoundError:
        print('------------------------------------')
        print('|         FILE NOT FOUND!!!        |')
        print('|Please locate the file and restart|')
        print('|  the program before continuing.  |')
        print('------------------------------------')
        main()
    # Success return
    else:
        main()
# Module display().
def display():
    # Display GUI for menu options.
    print('--------------------------------')
    print('|               MENU           |')
    print('--------------------------------')
    print('|  1)	Enter Employee info   |')
    print('|  2)	Read Employee Info    |')
    print('|  3)	Exit                  |')
    print('--------------------------------')   

# Module ending()
def ending():
    # Display Thank you message & exit program.
    print('--------------------------------')
    print('|Thanks for using this program!|')
    print('--------------------------------')
# Program Start
main()