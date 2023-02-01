/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package courseinformation;

import java.util.Scanner;

public class CourseInformation {
   public static void main(String[] args) {
      Scanner scnr = new Scanner(System.in);

      Course myCourse = new Course();
      OfferedCourse myOfferedCourse = new OfferedCourse();

      String courseNumber, courseTitle;
      String oCourseNumber, oCourseTitle, instructorName, term, classTime;

      courseNumber = scnr.nextLine();
      courseTitle = scnr.nextLine();

      oCourseNumber =  scnr.nextLine();
      oCourseTitle =  scnr.nextLine();
      instructorName = scnr.nextLine();
      term = scnr.nextLine();
      classTime = scnr.nextLine();

      myCourse.setCourseNumber(courseNumber);
      myCourse.setCourseTitle(courseTitle);
      myCourse.printInfo();

      myOfferedCourse.setCourseNumber(oCourseNumber);
      myOfferedCourse.setCourseTitle(oCourseTitle);
      myOfferedCourse.setInstructorName(instructorName);
      myOfferedCourse.setTerm(term);
      myOfferedCourse.setClassTime(classTime);
      myOfferedCourse.printInfo();

      System.out.println("   Instructor Name: " + myOfferedCourse.getInstructorName());
      System.out.println("   Term: " + myOfferedCourse.getTerm());
      System.out.println("   Class Time: " + myOfferedCourse.getClassTime());
   }
}
