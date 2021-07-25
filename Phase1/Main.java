import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String command = scanner.nextLine().toLowerCase();
        FullTextSearch fullTextSearch = new FullTextSearch(command);
        fullTextSearch.run();
        scanner.close();
    }
}