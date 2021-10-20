
import java.util.*;

public class CoffeeWithHook extends CaffeineBeverage {
    @Override
    void brew() {
        System.out.println("Dripping coffee through filter");
    }
    @Override
    void addCondiments() {
        System.out.println("Adding Sugar and Milk");
    }

    public boolean CustomerWantsCondiments(){
        Scanner inp = new Scanner(System.in);
        inp.close();
        String ans = inp.nextLine();

        if(ans.toLowerCase().startsWith("y")) {
            return true;
        }
        else {
            return false;
        }
    }
    
}
