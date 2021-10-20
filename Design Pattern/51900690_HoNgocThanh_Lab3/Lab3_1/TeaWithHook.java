
import java.util.*;
public class TeaWithHook extends CaffeineBeverage {
    @Override
    void brew() {
        System.out.println("Steeping the tea");
    }

    @Override
    void addCondiments() {
        System.out.println("Adding lemon");
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
