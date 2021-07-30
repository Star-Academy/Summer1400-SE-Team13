import java.util.*;

public class FullTextSearch {
<<<<<<< HEAD
    private static final char PLUS_SIGN = '+';
    private static final char MINUS_SIGN = '-';
    private String command;
    private HashSet<String> plus;
    private HashSet<String> minus;
    private HashSet<String> noSign;
    private HashSet<Integer> result;
=======
    private final String command;
    private final InvertedIndex invertedIndex;
    private final Tokenizer tokenizer;
    private final DocsFileReader docsFileReader;
    private final FilterHandler filterHandler;
>>>>>>> Phase02

    public FullTextSearch(String command, InvertedIndex invertedIndex, Tokenizer tokenizer,
            DocsFileReader docsFileReader, FilterHandler filterHandler) {
        this.command = command;
<<<<<<< HEAD
        plus = new HashSet<>();
        minus = new HashSet<>();
        noSign = new HashSet<>();
        result = new HashSet<>();
=======
        this.invertedIndex = invertedIndex;
        this.tokenizer = tokenizer;
        this.docsFileReader = docsFileReader;
        this.filterHandler = filterHandler;
>>>>>>> Phase02
    }

    public void loadDocs() {
        final String fileAddress = "Phase1/EnglishData";
        HashMap<Integer, String> initialDocs = docsFileReader.readContent(fileAddress);
        for (int id : initialDocs.keySet()) {
            String docString = initialDocs.get(id);
            HashSet<String> wordsSet = tokenizer.tokenize(docString);
            invertedIndex.addDoc(wordsSet, id);
        }
    }

<<<<<<< HEAD
        split();
        handleFilters(invertedIndex);

        if (result.size() == 0)
            System.out.println("no doc found!");
        else {
            TreeSet<Integer> sortedDocs = new TreeSet<Integer>(result);
            System.out.println(sortedDocs);
        }
=======
    public HashSet<Integer> run() {
        loadDocs();
        String[] words = splitCommand();
        return filterHandler.filter(words);
    }

    public String[] splitCommand() {
        return command.split(" ");
>>>>>>> Phase02
    }

    public void split() {
        String[] words = command.split(" ");
        for (String word : words) {
            if (word.charAt(0) == PLUS_SIGN)
                plus.add(word.substring(1, word.length()));
            else if (word.charAt(0) == MINUS_SIGN)
                minus.add(word.substring(1, word.length()));
            else
                noSign.add(word);
        }
    }

    public void handleFilters(InvertedIndex invertedIndex) {
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
}
