/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trianglearea;
import java.util.Scanner;
public class TriangleArea {

    public static void main(String[] args) {
        Scanner scnr = new Scanner(System.in);

        double baseOne = scnr.nextDouble();
        double heightOne = scnr.nextDouble();
        double baseTwo = scnr.nextDouble();
        double heightTwo = scnr.nextDouble();

        // TODO: Read and set base and height for triangle1 (use setBase() and setHeight())
        Triangle triangle1 = new Triangle();
        triangle1.setBase(baseOne);
        triangle1.setHeight(heightOne);

        // TODO: Read and set base and height for triangle2 (use setBase() and setHeight())
        Triangle triangle2 = new Triangle();
        triangle2.setBase(baseTwo);
        triangle2.setHeight(heightTwo);

        // TODO: Determine larger triangle (use getArea())

        System.out.println("Triangle with larger area:");
        if (triangle1.getArea() < triangle2.getArea()){
            triangle2.printInfo();
        }
        else{
            triangle1.printInfo();
        }
    }
}
