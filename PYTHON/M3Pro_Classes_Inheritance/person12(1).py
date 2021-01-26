

class Person:
    def __init__(self, firstName,lastName, email):
        self.__firstName = firstName
        self.__lastName = lastName
        self.__email = email

    def set_firstName(self, firstName):
        self.__firstName = firstName

    def set_lastName(self, lastName):
        self.__lastName = lastName

    def set_email(self, email):
        self.__email = email
    
    def get_firstName(self):
        return self.__firstName
        
    def get_lastName(self):
        return self.__lastName
    
    def get_email(self):
        return self.__email





