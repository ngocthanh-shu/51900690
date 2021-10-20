import javax.sql.DataSource;

public abstract class DataAccessObject {
    protected String connectionString;
    protected DataSource dataSource;

    public void Connect(){
        System.out.println("Connecting Database using connection string");
        connectionString = "Data Source=DESKTOP-HJINU4T;Initial Catalog=Lab3_CDCNPM;Integrated Security=True";
    }
    public abstract void Select();
    public abstract void Process();
    public void Disconnect(){
        System.out.println("Disconnecting Database");
    }
    public final void Run(){
        Connect();
        Select();
        Process();
        Disconnect();
    }
}