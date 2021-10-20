
public abstract class CaffeineBeverage {
    protected final void PrepareRecipe(){
        BoilWater();
        brew();
        PourInCup();
        addCondiments();
    }

    abstract void brew();
    abstract void addCondiments();

    void BoilWater(){
        System.out.println("Boiling water");
    }

    void PourInCup(){
        System.out.println("Pouring into cup");
    }

    boolean CustomerWantsCondiments() {
        return true;
    }
}