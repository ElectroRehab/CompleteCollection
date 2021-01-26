# Create an inheritance that a bank mioght use to represent customer bank
# accounts. All customers at this bank can deposit money into their accounts.
# More specific types of acccounts also exist. Savings Accounts, for instance, 
# earn interest on the money they hold. Checking accounts, on the other hand, 
# don't earn insterest and charge a fee per transaction.

# 1) Start with class Account from the chapter and...
# 2) Create two subclasses:
#   A) SavingsAccount
#   B) CheckingAccount
# 3) SavingsAccount should also include:
#   A) Data Attribute indicating the Interest Rate
#   B) calculate_interest method should return:
#       a) Decimal result of multiplying the interest rate & account balance.
#   C) Inherit methods:
#       a) deposit without redefining
#       b) withdraw without redefining
# 4) CheckingAccount should include:
#   A) A Decimal data attribute that represents:
#       a) The fee charged per transaction
#   B) Class CheckingAccount should override methods:
#       a) deposit and withdraw
#           1) So that thye subtract the fee from the account balance 
#              whenever either transaction is perfromed successfully.
#   C) CheckingAccount's Versions of these methods should invoke
#      the base-class Account versions to update the account balance.
#   D) CheckingAccount's withdraw method should charge a fee only if: 
#       a) money is withdrawn.
#           1) As long os the withdrawal amount does not 
#              exceed the account balance. 
# 5) Create objects of each class and test their methods.
#   A) Add interest to the SavingsAccount object by invoking it's
#      calculate_interest method, then passing the returned interest 
#      amount to the object's deposit method.
# A brief description of the project - (Displayed Above)
# 07MAR20
# CSC221 M3HW - Class_Inheritance
# Jon King