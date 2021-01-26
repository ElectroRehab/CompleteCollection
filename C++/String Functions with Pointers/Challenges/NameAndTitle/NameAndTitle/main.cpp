#include <iostream>
#include <cstring>
using namespace std;
// Challenges 8.4.1: Enter the output of the string functions.

/*
// Dr Hill
int main() {
   char nameAndTitle[50];
   char* stringPointer = nullptr;

   strcpy(nameAndTitle, "Dr. Ann Hill");

   stringPointer = strchr(nameAndTitle, 'p');
   if (stringPointer != nullptr) {
      cout << "a" << endl;
   }
   else {
      cout << "b" << endl;
   }

   return 0;
}
*/

//
/*
int main() {
   char nameAndTitle[50];
   char subString[50];
   char* stringPointer = nullptr;

   strcpy(nameAndTitle, "Dr. Amaya Webb");

   stringPointer = strrchr(nameAndTitle, 'A');
   strcpy(subString, stringPointer);

   cout << subString << endl;

   return 0;
}
*/


//
/*
int main() {
   char nameAndTitle[50];
   char subString[50];
   char* stringPointer = nullptr;

   strcpy(nameAndTitle, "Ms. Ada Perez");

   stringPointer = strstr(nameAndTitle, "Mr.");
   if (stringPointer != nullptr) {
      cout << "a" << endl;
   }
   else {
      cout << "b" << endl;
   }

   return 0;
}
*/


/*
//
int main() {
   char nameAndTitle[50];
   char subString[50];
   char* stringPointer = nullptr;

   strcpy(nameAndTitle, "Dr. Ace Alvarez");

   stringPointer = strstr(nameAndTitle, "Alvarez");
   strcpy(subString, stringPointer);

   cout << subString << endl;

   return 0;
}
*/

/*
//
int main() {
   char userString[50];
   char* stringPointer = nullptr;

   strcpy(userString, "Hello world? How are you?");

   stringPointer = strchr(userString, '?');
   while (stringPointer != nullptr) {
      *stringPointer = '.';
      stringPointer = strchr(userString, '?');
   }

   cout << userString << endl;

   return 0;
}
*/

/*
// 8.4.2: Find char in C string
int main() {
   char personName[100];
   char searchChar;
   char* searchResult = nullptr;

   cin.getline(personName, 100);
   cin >> searchChar;

   // Your solution goes here  //
   searchResult = strchr(personName, searchChar);

   if (searchResult != nullptr) {
      cout << "Character found." << endl;
   }
   else {
      cout << "Character not found." << endl;
   }

   return 0;
}
*/


/*
// 8.4.3: Find C string in C string.
int main() {
   char movieTitle[100];
   char* movieResult = nullptr;

   cin.getline(movieTitle, 100);

   // Your solution goes here  //
   movieResult = strstr(movieTitle, "The");

   cout << "Movie title contains The? ";
   if (movieResult != nullptr) {
      cout << "Yes." << endl;
   }
   else {
      cout << "No." << endl;
   }

   return 0;
}
*/


