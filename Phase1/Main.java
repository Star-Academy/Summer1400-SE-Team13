import java.util.*;

public class Main {

    static void printResult(HashSet<Integer> result) {
        if (result.isEmpty())
            System.out.println("no doc found!");
        else {
            System.out.println(result.size());
            System.out.println(result);
        }
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String command = scanner.nextLine().toLowerCase();
        InvertedIndex invertedIndex = new InvertedIndex();
        FullTextSearch fullTextSearch = new FullTextSearch(command, invertedIndex);
        HashSet<Integer> result = fullTextSearch.run();
        printResult(result);
        scanner.close();
    }
}
