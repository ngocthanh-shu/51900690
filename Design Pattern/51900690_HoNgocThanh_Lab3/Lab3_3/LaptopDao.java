public class LaptopDao extends DataAccessObject {

    @Override
    public void Select() {
        System.out.println("Select statement for Laptop");
    }

    @Override
    public void Process() {
        System.out.println("Process the selected results set for Laptop");
    }
    
}
