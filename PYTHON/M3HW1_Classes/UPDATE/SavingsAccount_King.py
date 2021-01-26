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
#           1) So that they subtract the fee from the account balance 
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

# account.py
"""Account class definition."""
from decimal import Decimal


class Account:
    """Account class for maintaining a bank account balance."""
    
    def __init__(self, name, balance):
        """Initialize an Account object."""

        # if balance is less than 0.00, raise an exception
        if balance < Decimal('0.00'):
            raise ValueError('Initial balance must be >= to 0.00.')

        self.name = name
        self.balance = balance

    def deposit(self, amount):
        """Deposit money to the account."""

        # if amount is less than 0.00, raise an exception
        if amount < Decimal('0.00'):
            raise ValueError('amount must be positive.')

        self.balance += amount
        
    def withdraw(self, amount):
        """Deposit money to the account."""

        # if amount is less than 0.00, raise an exception
        if amount < Decimal('0.00'):
            raise ValueError('amount must be positive.')

        self.balance -= amount

class SavingsAccount(Account):
    def calculate_interest(self, interest):
        interestRate = Decimal('0.05')
        # if amount is less than 0.00, raise an exception
        if interest < Decimal('0.00'):
            raise ValueError('amount must be positive.')
        print('\n\t\tInterest Earned:\n',f'\t\t   $' +
              f'{interestRate * self.balance:.2f}\n')
        self.balance += interestRate * self.balance
        
class CheckingAccount(Account):
    def checkingWithdraw(self, amount):
        fee = Decimal('3.00')
        # if amount is less than 0.00, raise an exception
        if amount < Decimal('0.00'):
            raise ValueError('amount must be positive.')
        self.balance -= amount
        while (self.balance < fee):
            print("That's too much!")
            self.balance += amount
            print(self.balance)
            test = input('Withdraw Amount:')
            custCheck.checkingWithdraw(Decimal(test))
        else:
            self.balance -= fee
        
    def checkingDeposit(self, amount):
        # if amount is less than 0.00, raise an exception
        if amount < Decimal('0.00'):
            raise ValueError('amount must be positive.')
        self.balance += amount
    

custSave = SavingsAccount('Tom Jones', Decimal('50000.00'))
print('----------------------')
print("|SAVINGS ACCOUNT INFO|")
print('----------------------\n')
print('Account Type:\t Name: \t\t Starting Balance: \t')
print('Savings Acct\t',custSave.name,'\t$',custSave.balance)

print('\nDeposit $250.75 into Savings Account')
custSave.deposit(Decimal('250.75'))
print('Account Type:\t Name: \t\t Current Balance: ')
print('Savings Acct\t',custSave.name,'\t$',custSave.balance)

print('\nWithdraw $5555.22 out of Savings Account')
custSave.withdraw(Decimal('5555.22'))
print('Account Type:\t Name: \t\t Current Balance: ')
print('Savings Acct\t',custSave.name,'\t$',custSave.balance)
custSave.calculate_interest((custSave.balance))
print('Account Type:\t Name: \t\t Current Balance: ')
print('Savings Acct\t',custSave.name,'\t$',f'{custSave.balance:.2f}')
print()
print('----------------------')
print("|CHECKING ACCOUNT INFO|")
print('----------------------\n')
custCheck = CheckingAccount('Bill Poole', Decimal('25000.00'))
print('Account Type:\t Name: \t\t Starting Balance: \t')
print('Savings Acct\t',custCheck.name,'\t$',custCheck.balance)
print('\nDeposit $2000.55 into Savings Account')
custCheck.checkingDeposit(Decimal('2000.55'))
print('Account Type:\t Name: \t\t Starting Balance: \t')
print('Savings Acct\t',custCheck.name,'\t$',custCheck.balance)
print('\nWithdraw $5000.22 out of Savings Account')
custCheck.checkingWithdraw(Decimal('5000.22'))
print('Account Type:\t Name: \t\t Starting Balance: \t')
print('Savings Acct\t',custCheck.name,'\t$',custCheck.balance)


#cust.deposit(Decimal('10000.00'))
#cust.withdraw(Decimal('200.00'))
#print(cust.balance)
#
#print(cust.name)
#print(f'{cust.balance}')
##nameInput = input('Enter Name:')
##balanceInput = input('Balance:')
##depositAmount = input('Depo:')
##withdrawAmount = input('With:')
#cust = Account('Jim', 50000)
#test1 = cust.balance
#test2 = cust.name
#test5 = cust.name
#print(test1)
#print(test2)
#cust2 = calculate_interest()
#test4 = cust2.calculate_interest
#test5 = cust2.name
#print(test4)
#print(test5)

##########################################################################
# (C) Copyright 2019 by Deitel & Associates, Inc. and                    #
# Pearson Education, Inc. All Rights Reserved.                           #
#                                                                        #
# DISCLAIMER: The authors and publisher of this book have used their     #
# best efforts in preparing the book. These efforts include the          #
# development, research, and testing of the theories and programs        #
# to determine their effectiveness. The authors and publisher make       #
# no warranty of any kind, expressed or implied, with regard to these    #
# programs or to the documentation contained in these books. The authors #
# and publisher shall not be liable in any event for incidental or       #
# consequential damages in connection with, or arising out of, the       #
# furnishing, performance, or use of these programs.                     #
##########################################################################



