#include "FoodItem.h"
#include <stdio.h>

// Define default constructor

// Define second constructor with arguments
// to initialize private data members

string FoodItem::GetName() {
   return name;
}

double FoodItem::GetFat() {
   return fat;
}

double FoodItem::GetCarbs() {
   return carbs;
}

double FoodItem::GetProtein() {
   return protein;
}

double FoodItem::GetCalories(double numServings) {
   // Calorie formula
   double calories = ((fat * 9) + (carbs * 4) + (protein * 4)) * numServings;
   return calories;
}

void FoodItem::PrintInfo() {
   printf("Nutritional information per serving of %s:\n", name.c_str());
   printf("   Fat: %.2f g\n", fat);
   printf("   Carbohydrates: %.2f g\n", carbs);
   printf("   Protein: %.2f g\n", protein);
}