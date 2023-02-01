package artworklabel;
public class Artist {
    // TODO: Declare private fields - artistName, birthYear, deathYear
    private String name;
    private int birthYear;
    private int deathYear;
    // TODO: Define default constructor
    public Artist(){
        this.name = "None";
        birthYear = 0;
        deathYear = 0;
    }
    // TODO: Define second constructor to initialize 
    public Artist(String name, int birthYear, int deathYear){
        this.name = name;
        this.birthYear = birthYear;
        this.deathYear = deathYear;
    }
    // TODO: Define get methods: getName(), getBirthYear(), getDeathYear()
    public String getName(){
        return name;
    }
    
    public int getBirthYear(){
        return birthYear;
    }
    
    public int getDeathYear(){
        return deathYear;
    }
    // TODO: Define printInfo() method
    //      If deathYear is entered as -1, only print birthYear
    public void printInfo(){
        if (deathYear == -1){
            System.out.println("Artist: " + name + ", born " + birthYear);
        }
        else{
            System.out.println("Artist: " + name + " (" + birthYear + 
                    "-" + deathYear + ")");
        }
    }
}