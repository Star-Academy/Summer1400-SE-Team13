import java.util.*;

public class FilterHandler {
    private HashSet<String> plus;
    private HashSet<String> minus;
    private HashSet<String> noSign;
    private HashSet<Integer> result;
    private InvertedIndex invertedIndex;
    private String[] words;

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
}
