package src;
import java.util.*;

public class Main {

    static void printResult(HashSet<Integer> result) {
        if (result.isEmpty()) {
            System.out.println("no doc found!");
        } else {
            System.out.println(result.size());
            System.out.println(result);
        }
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String command = scanner.nextLine().toLowerCase();
        InvertedIndex invertedIndex = new InvertedIndex();
        DocsFileReader docsFileReader = new DocsFileReader();
        Tokenizer tokenizer = new Tokenizer();
        Filter plusFilter = new PlusFilter();
        Filter noSignFilter = new NoSignFilter();
        Filter minusFilter = new MinusFilter();
        FilterHandler filterHandler = new FilterHandler(invertedIndex, plusFilter, noSignFilter, minusFilter);
        FullTextSearch fullTextSearch = new FullTextSearch(command, invertedIndex, tokenizer, docsFileReader,
                filterHandler);
        HashSet<Integer> result = fullTextSearch.run();
        printResult(result);
        scanner.close();
    }
}
