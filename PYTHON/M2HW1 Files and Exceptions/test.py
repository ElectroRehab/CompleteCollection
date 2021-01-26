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
import pandas as pd
# 2) Load the dataset into pandas DataFrame with the following statement,
#    which uses the first column of each record as the row index:
#   A) df = pd.read_csv(diamonds.csv, index_col=0)
df = pd.read_csv("diamonds.csv", index_col=0)
# 3) Display the 1st 7 rows of the DataFrame
print(df.head(7))
# 4) Display the last 7 rows of the DataFrame
print(df.tail(7))
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
print(df.describe())
# 6) Use Series method describe to calculate the descriptive statistics for
#    t\he categorical data (text) columns:
#   A) Cut
#   B) Color
#   C) Clarity
methSeries = pd.Series(['cut', 'color','clarity'])
print(methSeries.describe())
# 7) What are the unique category values (use the Series method unique)?
uniqueCut = df['cut'].unique()
uniqueColor = df['color'].unique()
uniqueClarity = df['clarity'].unique()
print(uniqueCut, "\n",uniqueColor,"\n", uniqueClarity)

# 8) Pandas has many built in graphing capabilities. Excecute the %matploylib
#    magic to enable Matplotlib support in iPython. Then, to view histograms 
#    of each numerical data column, call your DataFrame's hist method.
histogram = df.hist()
