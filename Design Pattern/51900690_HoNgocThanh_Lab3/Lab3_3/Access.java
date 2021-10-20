public class Access {
    public static void main(String[] args) {
        DataAccessObject access = new LaptopDao();
        access.Run();

        access = new MobileDAO();
        access.Run();
    }
}
