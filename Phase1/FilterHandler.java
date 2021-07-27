import java.util.*;

public class FilterHandler {
    private final HashSet<String> plus;
    private final HashSet<String> minus;
    private final HashSet<String> noSign;
    private HashSet<Integer> result;
    private final InvertedIndex invertedIndex;
    private final String[] words;

    public FilterHandler(String[] words, InvertedIndex invertedIndex) {
        this.words = words;
        plus = new HashSet<>();
        minus = new HashSet<>();
        noSign = new HashSet<>();
        result = new HashSet<>();
        this.invertedIndex = invertedIndex;
    }

    public HashSet<Integer> filter() {
        addToSeparateSets(words);
        handleFilters();
        return result;
    }

    private void addToSeparateSets(String[] words) {
        char plusSign = '+';
        char minusSign = '-';
        for (String word : words) {
            if (word.charAt(0) == plusSign)
                plus.add(word.substring(1));
            else if (word.charAt(0) == minusSign)
                minus.add(word.substring(1));
            else
                noSign.add(word);
        }
    }

    private void handleFilters() {
        Filter plusFilter = new PlusFilter();
        for (String word : plus) {
            HashSet<Integer> docs = invertedIndex.getWordDocs(word);
            plusFilter.filter(result, docs);
        }
        Filter noSignFilter = new NoSignFilter();
        for (String word : noSign) {
            HashSet<Integer> docs = invertedIndex.getWordDocs(word);
            if (result.isEmpty()) {
                result = docs;
                continue;
            }
            noSignFilter.filter(result, docs);
        }
        Filter minusFilter = new MinusFilter();
        for (String word : minus) {
            if (!result.isEmpty()) {
                HashSet<Integer> docs = invertedIndex.getWordDocs(word);
                minusFilter.filter(result, docs);
            }
        }
    }
}
