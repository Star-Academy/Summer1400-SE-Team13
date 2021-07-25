import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String searchWord = scanner.nextLine().toLowerCase();
        FullTextSearch fullTextSearch = new FullTextSearch(searchWord);
        fullTextSearch.run();
        scanner.close();
    }
}