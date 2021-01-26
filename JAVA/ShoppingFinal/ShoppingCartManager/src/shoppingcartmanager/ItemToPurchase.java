/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package shoppingcartmanager;
public class ItemToPurchase {
   private String itemName;
   private int itemPrice;
   private int itemQuantity;
   private String itemDescription;
   
   public ItemToPurchase () {
      itemName = "none";
      itemPrice = 0;
      itemQuantity = 0;
      itemDescription = "none";
   }
   public ItemToPurchase (String name, String description, int price, 
           int quantity){
      itemName = name;
      itemPrice = price;
      itemQuantity = quantity;
      itemDescription = description;
   }
   
   public void setDescription(String description) {
      itemDescription = description;
   }
   public void setName(String name) {
      itemName = name;
   }
   public void setPrice(int price) {
      itemPrice = price;
   }
   public void setQuantity(int quantity) {   
      itemQuantity = quantity;
   }
   
   public String getDescription() {
      return itemDescription;
   }
   public String getName() {
      return itemName;
   }
   public int getPrice() {
      return itemPrice;
   }
   public int getQuantity() {
      return itemQuantity;
   }
   
   public void printItemCost() {
      System.out.println(itemName + " " + itemQuantity +  " @ $" + 
              itemPrice + " = $" + (itemPrice * itemQuantity));
   }
   public void printItemDescription() {
      System.out.println(itemName + ": " + itemDescription);
   }
}