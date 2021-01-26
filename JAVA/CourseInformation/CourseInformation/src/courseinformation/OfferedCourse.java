package courseinformation;

public class OfferedCourse extends Course {
    // TODO: Declare private fields - instructorName, term, classTime
    private String instructorName, term, classTime;
    // TODO: Define mutator methods -
    //      setInstructorName(), setTerm(), setClassTime()
    public void setInstructorName(String instructorName){
        this.instructorName = instructorName;
    }
    public void setTerm(String term){
        this.term = term;
    }
    public void setClassTime(String classTime){
        this.classTime = classTime;
    }
    // TODO: Define accessor methods -
    //      getInstructorName(), getTerm(), getClassTime()
    public String getInstructorName(){
        return instructorName;
    }
    public String getTerm(){
        return term;
    }
    public String getClassTime(){
        return classTime;
    }
}