from account import Account
from decimal import Decimal


nameInput = input('Enter Name:')
balanceInput = input('Balance:')
depositAmount = input('Depo:')
withdrawAmount = input('With:')
account1 = Account(nameInput, Decimal(balanceInput))
print(account1.name)
print(account1.balance)
answer1 = account1.balance
answer2 = account1.saveInterest(Decimal(depositAmount))
answer3 = account1.withdraw(Decimal(withdrawAmount))
answer4 = Decimal(account1.balance)
print(f'Starting Balance: {answer1}\nDeposit Amount: ${answer2}\n'+
      f'Withdraw Amount: ${answer3}\nFee Amount: ${answer}\n'+
      f'Account Balance: ${answer4}\n')

#account1.withdraw(Decimal(withdrawAmount))
#print(account1.balance)
#
#print(account1.balance)