package shoppingcartprinter;
import java.util.Scanner;
public class ShoppingCartPrinter {
    public static void main(String[] args) {
        Scanner scnr = new Scanner(System.in);
        
        ItemToPurchase itemOne = new ItemToPurchase();
        ItemToPurchase itemTwo = new ItemToPurchase();
        
        String itemNameOne;
        int itemPriceOne;
        int itemQuantityOne;
        int itemCostOne;
        
        System.out.println("Item 1");
        System.out.println("Enter the item name:");
        itemNameOne = scnr.nextLine();
        itemOne.setName(itemNameOne);
        
        System.out.println("Enter the item price:");
        itemPriceOne = scnr.nextInt();
        itemOne.setPrice(itemPriceOne);
        
        System.out.println("Enter the item quantity:");
        itemQuantityOne = scnr.nextInt();
        itemOne.setQuantity(itemQuantityOne);
        itemNameOne = itemOne.getName();
        itemQuantityOne = itemOne.getQuantity();
        itemPriceOne = itemOne.getPrice();
        itemCostOne = itemPriceOne * itemQuantityOne;
        
        String itemNameTwo;
        int itemPriceTwo;
        int itemQuantityTwo;
        int itemCostTwo;
        
        System.out.println("\nItem 2");
        
        System.out.println("Enter the item name:");
        itemNameTwo = scnr.next() + scnr.nextLine();
        itemTwo.setName(itemNameTwo);
        
        System.out.println("Enter the item price:");
        itemPriceTwo = scnr.nextInt();
        itemTwo.setPrice(itemPriceTwo);
        
        System.out.println("Enter the item quantity:");
        itemQuantityTwo = scnr.nextInt();
        itemTwo.setQuantity(itemQuantityTwo);
        
        itemNameTwo = itemTwo.getName();
        itemQuantityTwo = itemTwo.getQuantity();
        itemPriceTwo = itemTwo.getPrice();
        itemCostTwo = itemPriceTwo * itemQuantityTwo;
        
        int totalCost;
        
        totalCost = itemCostOne + itemCostTwo;
        
        System.out.println("\nTOTAL COST");
        System.out.println(itemNameOne + " " + itemQuantityOne +  " @ $" + 
                itemPriceOne + " = $" + itemCostOne);
        System.out.println(itemNameTwo + " " + itemQuantityTwo +  " @ $" + 
                itemPriceTwo + " = $" + itemCostTwo);
        System.out.println("\nTotal: $" + totalCost);
    }
}