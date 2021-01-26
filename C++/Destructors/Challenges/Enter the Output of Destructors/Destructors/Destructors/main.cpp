/*#include <iostream>
using namespace std;

class IntNode {
   public:
      IntNode(int value) {
         numVal = value;
      }

      ~IntNode() {
         cout << numVal << endl;
      }

      int numVal;
};

int main() {
   IntNode* node1 = new IntNode(2);
   IntNode* node2 = new IntNode(4);
   IntNode* node3 = new IntNode(5);
   IntNode* node4 = new IntNode(8);

   delete node3;
   delete node2;
   delete node1;
   delete node4;

   return 0;
}
*/
/*
#include <iostream>
using namespace std;

class IntNode {
   public:
      IntNode(int value) {
         numVal = value;
      }

      ~IntNode() {
         cout << numVal << endl;
      }

      int numVal;
      IntNode* next;
};

class IntLinkedList {
   public:
      IntLinkedList();
      ~IntLinkedList();
      void Prepend(int);

      IntNode* head;
};

IntLinkedList::IntLinkedList() {
   head = nullptr;
}

IntLinkedList::~IntLinkedList() {
   while (head) {
      IntNode* next = head->next;
      delete head;
      head = next;
   }
   cout << "end of list" << endl;
}

void IntLinkedList::Prepend(int dataValue) {
   IntNode* newNode = new IntNode(dataValue);
   newNode->next = head;
   head = newNode;
}

int main() {
   IntLinkedList* list = new IntLinkedList();

   list->Prepend(1);
   list->Prepend(4);
   list->Prepend(6);
   list->Prepend(8);

   delete list;

   return 0;
}
*/
/*
#include <iostream>
using namespace std;

class IntNode {
   public:
      IntNode(int value) {
         numVal = new int;
         *numVal = value;
      }
      void SetNumVal(int val) { *numVal = val; }
      int GetNumVal() { return *numVal; }
   private:
      int* numVal;
};

int main() {
   IntNode node1(1);
   IntNode node2(2);
   IntNode node3(3);

   node2 = node1;
   node1.SetNumVal(5);

   cout << node2.GetNumVal() << " " << node1.GetNumVal() << endl;

   return 0;
}
*/
#include <iostream>
using namespace std;

class IntNode {
   public:
      IntNode(int value) {
         numVal = new int;
         *numVal = value;
      }
      IntNode(const IntNode& origObject) {
         cout << "Copying " << *(origObject.numVal) << endl;
         numVal = new int;
         *numVal = *(origObject.numVal);
      }
      ~IntNode() {
         delete numVal;
      }
      void SetNumVal(int val) { *numVal = val; }
      int GetNumVal() { return *numVal; }
   private:
      int* numVal;
};

int main() {
   IntNode node1(1);
   IntNode node2 = node1;

   node1.SetNumVal(5);
   cout << node2.GetNumVal() << " " << node1.GetNumVal() << endl;

   return 0;
}
