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
    # Deposit module to ensure the deposits are acurrate
    def deposit(self, amount):
        """Deposit money to the account."""

        # if amount is less than 0.00, raise an exception
        if amount < Decimal('0.00'):
            raise ValueError('amount must be positive.')
        # Calculate deposit amount into 
        self.balance += amount
        
    def withdraw(self, amount):
        """Withdraw money from the account."""

        # if amount is less than 0.00, raise an exception
        if amount < Decimal('0.00'):
            raise ValueError('amount must be positive.')

        self.balance -= amount
# New SavingsAccount Class info
class SavingsAccount(Account):
    """SavingsAccount class for maintaining a savings account."""
    def calculate_interest(self, interest):
        interestRate = Decimal('0.05')
        # if amount is less than 0.00, raise an exception
        if interest < Decimal('0.00'):
            raise ValueError('amount must be positive.')
        # Display Interest Earned on Balance
        print('\n\t\tInterest Earned:\n',f'\t\t   $' +
              f'{interestRate * self.balance:.2f}\n')
        # Calculate Interest Earned and add it to the balance
        self.balance += interestRate * self.balance
# New CheckingAccount Class info  
class CheckingAccount(Account):
    """CheckingAccount class for maintaining a checking account."""
    # Checking Account withdraw method
    def checkingWithdraw(self, amount):
        """Withdraw money from the account with a fee."""
        # Fee amount for each withdraw from checking account.
        fee = Decimal('3.00')
        # if amount is less than 0.00, raise an exception
        if amount < Decimal('0.00'):
            raise ValueError('amount must be positive.')
        self.balance -= amount
        # Overdraft Protection Section used with a while loop
        while (self.balance < fee):
            # Error Message
            print("------------------------------------------------")
            print("|You don't have that much money in your account|")
            print("|       after the $"+str(fee)+" fee is charged         |")
            print("------------------------------------------------")
            # Reset Last Transaction
            self.balance += amount
            # Display the current balance
            print("-------------------------------")
            print('|This is your current balance:|')
            print("-------------------------------")
            print(self.balance)
            # User input to withdraw from the checking account.
            redoWithdraw = input('Withdraw Amount:')
            # Redo the withdraw amount from the custCheck variable.
            custCheck.checkingWithdraw(Decimal(redoWithdraw))
        # Charge fee to balance when the money is available.
        else:
            # Subtract the fee from the recent transaction.
            self.balance -= fee
        
    def checkingDeposit(self, amount):
        """Deposit money to the checking account."""
        # if amount is less than 0.00, raise an exception
        if amount < Decimal('0.00'):
            raise ValueError('amount must be positive.')
        # Add the deposit amount into the balance
        self.balance += amount
# Saving Account Processes and Calculations
# Customer Save used as variable to add name and initial deposit amount.
custSave = SavingsAccount('Tom Jones', Decimal('50000.00'))
print('----------------------')
print("|SAVINGS ACCOUNT INFO|")
print('----------------------\n')
# Display initial amount
print('Account Type:\t Name: \t\t Starting Balance: \t')
print('Savings Acct\t',custSave.name,'\t$',custSave.balance)
# Deposit Section of the Savings Account
print('\nDeposit $250.75 into Savings Account')
custSave.deposit(Decimal('250.75'))
# Display current amount
print('Account Type:\t Name: \t\t Current Balance: ')
print('Savings Acct\t',custSave.name,'\t$',custSave.balance)
# Withdraw Section of the Savings Account
print('\nWithdraw $5555.22 out of Savings Account')
custSave.withdraw(Decimal('5555.22'))
# Display current amount
print('Account Type:\t Name: \t\t Current Balance: ')
print('Savings Acct\t',custSave.name,'\t$',custSave.balance)
# Calculate Interest Section of Savings Account
custSave.calculate_interest((custSave.balance))
# Display current amount
print('Account Type:\t Name: \t\t Current Balance: ')
print('Savings Acct\t',custSave.name,'\t$',f'{custSave.balance:.2f}')
# Saving Account Processes and Calculations
print('\n----------------------')
print("|CHECKING ACCOUNT INFO|")
print('----------------------\n')
# Customer Check used as variable to add name and initial deposit amount.
custCheck = CheckingAccount('Bill Poole', Decimal('25000.00'))
# Display initial amount
print('Account Type:\t Name: \t\t Starting Balance: \t')
print('Savings Acct\t',custCheck.name,'\t$',custCheck.balance)
# Deposit Section of the Checking Account
print('\nDeposit $2000.55 into Checking Account')
custCheck.checkingDeposit(Decimal('2000.55'))
# Display current amount
print('Account Type:\t Name: \t\t Current Balance: \t')
print('Savings Acct\t',custCheck.name,'\t$',custCheck.balance)
# Withdraw Section of the Checking Account with purposeful error
print('\nWithdraw $27000.00 out of Checking Account\n')
custCheck.checkingWithdraw(Decimal('27000'))
print('Account Type:\t Name: \t\t Current Balance: \t')
print('Savings Acct\t',custCheck.name,'\t$',custCheck.balance)
# Program Outro
print("\n-----------------------------------")
print('|Thank you for using this program.|')
print("-----------------------------------")