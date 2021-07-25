import java.util.*;

public class FullTextSearch {
    private static final char PLUS_SIGN = '+';
    private static final char MINUS_SIGN = '-';
    private String command;
    private HashSet<String> plus;
    private HashSet<String> minus;
    private HashSet<String> noSign;
    private HashSet<Integer> result;

    public FullTextSearch(String command) {
        this.command = command;
        plus = new HashSet<>();
        minus = new HashSet<>();
        noSign = new HashSet<>();
        result = new HashSet<>();
    }

    public void run() {
        GetInput getInput = new GetInput("/home/melika/Desktop/codes/codestar/phase1/EnglishData");
        HashMap<Integer, String> hashMap = getInput.readContent();
        InvertedIndex invertedIndex = new InvertedIndex();

        for (int id : hashMap.keySet()) {
            String docString = hashMap.get(id);
            Tokenizer tokenizer = new Tokenizer(docString);
            HashSet<String> wordsSet = tokenizer.tokenize();
            invertedIndex.addDoc(wordsSet, id);
        }

        split();
        handleFilters(invertedIndex);

        if (result.size() == 0)
            System.out.println("no doc found!");
        else {
            TreeSet<Integer> sortedDocs = new TreeSet<Integer>(result);
            System.out.println(sortedDocs);
        }
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
