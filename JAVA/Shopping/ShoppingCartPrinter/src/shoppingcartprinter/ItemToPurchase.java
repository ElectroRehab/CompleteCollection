/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package shoppingcartprinter;
public class ItemToPurchase {
    private String itemName;
    private int itemPrice;
    private int itemQuantity;
    
    public void setName(String name){
        itemName = name;
    }
    public void setPrice(int price){
        itemPrice = price;
    }
    public void setQuantity(int quantity){
        itemQuantity = quantity;
    }
    
    public String getName(){
        return itemName;
    }
    public int getPrice(){
        return itemPrice;
    }
    public int getQuantity(){
        return itemQuantity;
    }
}