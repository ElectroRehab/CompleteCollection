package courseinformation;

public class Course{
    // TODO: Declare private fields - courseNumber, courseTitle
    private String courseNumber, courseTitle;
    // TODO: Define mutator methods - 
    //       setCourseNumber(), setCourseTitle()
    public void setCourseNumber(String courseNumber){
        this.courseNumber = courseNumber;
    }
    public void setCourseTitle(String courseTitle){
        this.courseTitle = courseTitle;
    }
    // TODO: Define accessor methods - 
    //       getCourseNumber(), getCourseTitle()
    public String getCourseNumber(){
        return courseNumber;
    }
    public String getCourseTitle(){
        return courseTitle;
    }
    // TODO: Define printInfo()
    public void printInfo(){
        System.out.println("Course Information: ");
        System.out.println("   Course Number: " + getCourseNumber());
        System.out.println("   Course Title: " + getCourseTitle());
    }    
}