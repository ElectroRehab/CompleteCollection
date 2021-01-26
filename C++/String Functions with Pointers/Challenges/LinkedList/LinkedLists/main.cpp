/*
#include <iostream>
using namespace std;

class PlaylistSong {
   public:
      PlaylistSong(string value = "noName", PlaylistSong* nextLoc = nullptr);
      void InsertAfter(PlaylistSong* nodePtr);
      PlaylistSong* GetNext();
      void PrintNodeData();
   private:
      string name;
      PlaylistSong* nextPlaylistSongPtr;
};

PlaylistSong::PlaylistSong(string name, PlaylistSong* nextLoc) {
   this->name = name;
   this->nextPlaylistSongPtr = nextLoc;
}

void PlaylistSong::InsertAfter(PlaylistSong* nodeLoc) {
   PlaylistSong* tmpNext = nullptr;

   tmpNext = this->nextPlaylistSongPtr;
   this->nextPlaylistSongPtr = nodeLoc;
   nodeLoc->nextPlaylistSongPtr = tmpNext;
}

PlaylistSong* PlaylistSong::GetNext() {
   return this->nextPlaylistSongPtr;
}

void PlaylistSong::PrintNodeData() {
   cout << this->name << endl;
}

int main() {
   PlaylistSong* headObj = nullptr;
   PlaylistSong* firstSong = nullptr;
   PlaylistSong* secondSong = nullptr;
   PlaylistSong* thirdSong = nullptr;
   PlaylistSong* currObj = nullptr;

   headObj = new PlaylistSong("head");

   firstSong = new PlaylistSong("Pavanne");
   headObj->InsertAfter(firstSong);

   secondSong = new PlaylistSong("Fidelio");
   firstSong->InsertAfter(secondSong);

   thirdSong = new PlaylistSong("Canon");
   secondSong->InsertAfter(thirdSong);

   currObj = headObj;

   while (currObj != nullptr) {
      currObj->PrintNodeData();
      currObj = currObj->GetNext();
   }
   return 0;
}
*/


/*
#include <iostream>
using namespace std;

class IntNode {
   public:
      IntNode(int value = -1, IntNode* nextLoc = nullptr);
      void InsertAfter(IntNode* nodePtr);
      int GetValue();
      IntNode* GetNext();
      void PrintData();
   private:
      int value;
      IntNode* nextIntNodePtr;
};

IntNode::IntNode(int val, IntNode* nextLoc) {
   this->value = val;
   this->nextIntNodePtr = nextLoc;
}

void IntNode::InsertAfter(IntNode* nodeLoc) {
   IntNode* tmpNext = nullptr;

   tmpNext = this->nextIntNodePtr;
   this->nextIntNodePtr = nodeLoc;
   nodeLoc->nextIntNodePtr = tmpNext;
}

int IntNode::GetValue() {
   return this->value;
}

IntNode* IntNode::GetNext() {
   return this->nextIntNodePtr;
}

void IntNode::PrintData() {
   cout << this->value << endl;
}

int main() {
   IntNode* headObj = nullptr;
   IntNode* node1 = nullptr;
   IntNode* node2 = nullptr;
   IntNode* node3 = nullptr;
   IntNode* node4 = nullptr;
   IntNode* currObj = nullptr;

   headObj = new IntNode(-1);

   node1 = new IntNode(1);
   headObj->InsertAfter(node1);

   node2 = new IntNode(20);
   node1->InsertAfter(node2);

   node3 = new IntNode(25);
   node2->InsertAfter(node3);

   node4 = new IntNode(35);
   node3->InsertAfter(node4);

   currObj = headObj;

   while (currObj != nullptr) {
      if (currObj->GetValue() < 30) {
         currObj->PrintData();
      }
      currObj = currObj->GetNext();
   }

   return 0;
}
*/



/*
#include <iostream>
using namespace std;

class IntNode {
   public:
      IntNode(int value = -1, IntNode* nextLoc = nullptr);
      void InsertAfter(IntNode* nodePtr);
      int GetValue();
      IntNode* GetNext();
      void PrintData();
   private:
      int value;
      IntNode* nextIntNodePtr;
};

IntNode::IntNode(int val, IntNode* nextLoc) {
   this->value = val;
   this->nextIntNodePtr = nextLoc;
}

void IntNode::InsertAfter(IntNode* nodeLoc) {
   IntNode* tmpNext = nullptr;

   tmpNext = this->nextIntNodePtr;
   this->nextIntNodePtr = nodeLoc;
   nodeLoc->nextIntNodePtr = tmpNext;
}

IntNode* IntNode::GetNext() {
   return this->nextIntNodePtr;
}

void IntNode::PrintData() {
   cout << this->value << endl;
}

int main() {
   IntNode* headObj = nullptr;
   IntNode* node1 = nullptr;
   IntNode* node2 = nullptr;
   IntNode* node3 = nullptr;
   IntNode* node4 = nullptr;
   IntNode* currObj = nullptr;

   headObj = new IntNode(-1);

   node1 = new IntNode(1);
   headObj->InsertAfter(node1);

   node2 = new IntNode(2);
   headObj->InsertAfter(node2);

   node3 = new IntNode(3);
   node1->InsertAfter(node3);

   node4 = new IntNode(4);
   node3->InsertAfter(node4);

   currObj = headObj;

   while (currObj != nullptr) {
      currObj->PrintData();
      currObj = currObj->GetNext();
   }

   return 0;
}
*/


// 8.5.2: Linked list negative values counting.
// Assign negativeCntr with the number of negative values in the linked list.
#include <iostream>
#include <cstdlib>
using namespace std;

class IntNode {
public:
   IntNode(int dataInit = 0, IntNode* nextLoc = nullptr);
   void InsertAfter(IntNode* nodePtr);
   IntNode* GetNext();
   int GetDataVal();
private:
   int dataVal;
   IntNode* nextNodePtr;
};

// Constructor
IntNode::IntNode(int dataInit, IntNode* nextLoc) {
   this->dataVal = dataInit;
   this->nextNodePtr = nextLoc;
}

/* Insert node after this node.
 * Before: this -- next
 * After:  this -- node -- next
 */
void IntNode::InsertAfter(IntNode* nodeLoc) {
   IntNode* tmpNext = nullptr;

   tmpNext = this->nextNodePtr;    // Remember next
   this->nextNodePtr = nodeLoc;    // this -- node -- ?
   nodeLoc->nextNodePtr = tmpNext; // this -- node -- next
}

// Grab location pointed by nextNodePtr
IntNode* IntNode::GetNext() {
   return this->nextNodePtr;
}

int IntNode::GetDataVal() {
   return this->dataVal;
}

int main() {
   IntNode* headObj = nullptr; // Create intNode objects
   IntNode* currObj = nullptr;
   IntNode* lastObj = nullptr;
   int i;
   int negativeCntr;

   negativeCntr = 0;

   headObj = new IntNode(-1);        // Front of nodes list
   lastObj = headObj;

   for (i = 0; i < 10; ++i) {        // Append 10 rand nums
      currObj = new IntNode((rand() % 21) - 10);
      lastObj->InsertAfter(currObj); // Append curr
      lastObj = currObj;             // Curr is the new last item
   }

   currObj = headObj;                // Print the list
   while (currObj != nullptr) {
      cout << currObj->GetDataVal() << ", ";
      currObj = currObj->GetNext();
   }
   cout << endl;

   currObj = headObj;                // Count number of negative numbers
   while (currObj != nullptr) {

/////////////////////// Your solution goes here  ///////////////////////////////////////
      if(currObj->GetDataVal() < 0){
            negativeCntr++;
      }
////////////////////////////////////////////////////////////////////////////////////////
      currObj = currObj->GetNext();
   }
   cout << "Number of negatives: " << negativeCntr << endl;

   return 0;
}
