# 1) Create a DataFrame named 'temperatures' from a dictionary of three
#    temperature readings each for 'Maxine', 'James', and 'Amanda'.
# 2) Recreate the DataFrame temperatures in Part(a) with custom indices 
#    using the index keyword argument and a list containing 'Morning',
#    'Afternoon', and 'Evening'.
# 3) Select from temperatures the column of temperature readings for 'Maxine'.
# 4) Select from temperatures the row of 'Morning' temperature readings.
# 5) Select from temperatures the rows for 'Morning' and 'Evening' temperature 
#    readings.
# 6) Select from temperatures the columns of temperature readings for 'Amanda',
#    and 'Maxine'.
# 7) Select from temperatures the elements for 'Amanda' and 'Maxine' in the
#    'Morning' and 'Afternoon'.
# 8) Use the describe method to produce temperatures' descriptive statistics.
# 9) Tranpose temperatures
# 10) Sort temperatures so that its column names are in alphabetical order. 
#
# A brief description of the project (SHOWN ABOVE)
# 05FEB20
# CSC221 M1HW2 – DataFrame
# Jon King

# Import pandas and give it a name of 'pd' for easier access.
import pandas as pd
# main() module
def main():
    # Display Task Number 1
    print("1) Create a DataFrame named 'temperatures' from a dictionary\n"+
         "   of three temperature readings each for 'Maxine', 'James', and "+
         "'Amanda'.\n")
    # Create dictionary with the variable name of 'infoDict'
    infoDict = dict()
    # Add information into the dictionary named 'infoDict'
    infoDict.update(
            {"Maxine":[85,90,100],"James":[70,75,80],"Amanda":[55,65,77]})
    # Create a variable called 'temperatures' to be used as a DataFrame
    # from the dictionary 'infoDict'.
    temperatures = pd.DataFrame(infoDict)
    # Display the DataFrame 'temperatures
    print(temperatures)
    # Display Task Number 2
    print("\n2) Recreate the DataFrame temperatures in Part(a) with custom\n" +
         "   indices using the index keyword argument and a list containing\n"+
         "   'Morning', 'Afternoon', and 'Evening'.")
    # Give DataFrame custom indexes of 'Morning','Afternoon', & 'Evening'.
    temperatures = pd.DataFrame(infoDict, index=["Morning","Afternoon",
                                                 "Evening"])
    # Display new update to the DataFrame
    print(temperatures)
    # Display Task Number 3
    print("\n3) Select from temperatures the column of temperature readings\n"+
         "   for 'Maxine'.")
    # Display the temperature readings of DataFrame column for 'Maxine'
    print(temperatures['Maxine'])
    # Display Task Number 4 
    print("\n4) Select from temperatures the row of 'Morning' temperature\n"+
         "   readings.")
    # Display the temperature row of 'Morning' temperature readings.
    print(temperatures[:1])
    # Display Task Number 5
    print("\n5) Select from temperatures the rows for 'Morning' and "+
         "'Evening' temperature readings.")
    # Display temperatures the rows for 'Morning' and 'Evening' 
    # temperature readings.
    print(temperatures[:1])
    print(temperatures[2:3])
    # Display Task Number 6
    print("\n6) Select from temperatures the columns of temperature\n"+
         "   readings for 'Amanda', and 'Maxine'.")
    # Display temperature readings for 'Amanda'.
    print('--------------')
    print('|---Amanda---|')
    print('--------------')
    print(temperatures['Amanda'])
    # Display temperature readings for 'Maxine'.
    print('--------------')
    print('|---Maxine---|')
    print('--------------')
    print(temperatures['Maxine'])
    # Display Task Number 7.
    print("\n7) Select from temperatures the elements for 'Amanda' "+
         "and 'Maxine'\n   in the 'Morning' and 'Afternoon'.")
    # Display temperatures elements for 'Amanda'; 'Morning' and 'Afternoon'.
    print('------------------------------------')
    print("|Amanda's Morning & Afternoon Temps|")
    print('------------------------------------')
    print(temperatures.at['Morning', 'Amanda'],
          temperatures.at['Afternoon', 'Amanda'])
    # Display temperatures elements for 'Maxine'; 'Morning' and 'Afternoon'.
    print('------------------------------------')
    print("|Maxine's Morning & Afternoon Temps|")
    print('------------------------------------')
    print(temperatures.at['Morning', 'Maxine'],
          temperatures.at['Afternoon', 'Maxine'])
    # Display Task Number 8
    print("\n8) Use the describe method to produce temperatures'\n"+
         "   descriptive statistics.")
    # Display descriptive statistics of DataFrame
    print(temperatures.describe())
    # Display Task Number 9
    print("\n9) Tranpose temperatures")
    # Tranpose DataFrame 'temperatures'
    print(temperatures.T)
    # Display Task Number 10
    print("\n10) Sort temperatures so that its column names\n"+
         "    are in alphabetical order.")
    # Display Sorted temperatures so that its column names
    # are in alphabetical order.
    print(temperatures.sort_index(ascending=True))
# Program Start
# Call module main()
main()