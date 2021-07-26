import java.util.*;

public class FullTextSearch {
    private String command;
    private HashSet<String> plus;
    private HashSet<String> minus;
    private HashSet<String> noSign;
    private HashSet<Integer> result;
    private InvertedIndex invertedIndex;

    public FullTextSearch(String command) {
        this.command = command;
        plus = new HashSet<>();
        minus = new HashSet<>();
        noSign = new HashSet<>();
        result = new HashSet<>();
        invertedIndex = new InvertedIndex();
    }

    public void run() {
        loadDocs();
        String[] words = split();
        addToSeparateSets(words);
        handleFilters();
        printResponse();
    }

    private void loadDocs() {
        String FILE_ADDRESS = "EnglishData";
        DocsFileReader fileReader = new DocsFileReader(FILE_ADDRESS);
        HashMap<Integer, String> initialDocs = fileReader.readContent();
        for (int id : initialDocs.keySet()) {
            String docString = initialDocs.get(id);
            Tokenizer tokenizer = new Tokenizer();
            HashSet<String> wordsSet = tokenizer.tokenize(docString);
            invertedIndex.addDoc(wordsSet, id);
        }
    }

    private String[] split() {
        return command.split(" ");
    }

    private void addToSeparateSets(String[] words) {
        char PLUS_SIGN = '+';
        char MINUS_SIGN = '-';
        for (String word : words) {
            if (word.charAt(0) == PLUS_SIGN)
                plus.add(word.substring(1, word.length()));
            else if (word.charAt(0) == MINUS_SIGN)
                minus.add(word.substring(1, word.length()));
            else
                noSign.add(word);
        }
    }

    private void handleFilters() {
        Filter currentFilter;
        for (String word : plus) {
            HashSet<Integer> docs = invertedIndex.getWordDocs(word);
            currentFilter = new PlusFilter();
            currentFilter.filter(result, docs);
        }
        for (String word : noSign) {
            HashSet<Integer> docs = invertedIndex.getWordDocs(word);
            if (result.isEmpty()) {
                result = docs;
                continue;
            } else {
                currentFilter = new NoSignFilter();
                currentFilter.filter(result, docs);
            }
        }
        for (String word : minus) {
            if (!result.isEmpty()) {
                HashSet<Integer> docs = invertedIndex.getWordDocs(word);
                currentFilter = new MinusFilter();
                currentFilter.filter(result, docs);
            }
        }
    }

    private void printResponse() {
        if (emptyResult())
            System.out.println("no doc found!");
        else {
            TreeSet<Integer> sortedDocs = sortIDS(result);
            System.out.println(sortedDocs.size());
            System.out.println(sortedDocs);
        }
    }

    private TreeSet<Integer> sortIDS(HashSet<Integer> IDs) {
        return new TreeSet<Integer>(result);
    }

    private boolean emptyResult() {
        return result.isEmpty();
    }
}
