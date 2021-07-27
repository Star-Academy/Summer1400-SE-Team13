import java.util.*;

public class FilterHandler {
    private final HashSet<String> plus;
    private final HashSet<String> minus;
    private final HashSet<String> noSign;
    private final InvertedIndex invertedIndex;
    private final Filter plusFilter;
    private final Filter noSignFilter;
    private final Filter minusFilter;
    private HashSet<Integer> result;

    public FilterHandler(InvertedIndex invertedIndex, Filter plusFilter, Filter noSignFilter, Filter minusFilter) {
        this.invertedIndex = invertedIndex;
        this.plusFilter = plusFilter;
        this.noSignFilter = noSignFilter;
        this.minusFilter = minusFilter;
        plus = new HashSet<>();
        minus = new HashSet<>();
        noSign = new HashSet<>();
        result = new HashSet<>();

    }

    public HashSet<Integer> filter(String[] words) {
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
        for (String word : plus) {
            HashSet<Integer> docs = invertedIndex.getWordDocs(word);
            plusFilter.filter(result, docs);
        }
        for (String word : noSign) {
            HashSet<Integer> docs = invertedIndex.getWordDocs(word);
            if (result.isEmpty() && docs != null) {
                result = docs;
                continue;
            }
            noSignFilter.filter(result, docs);
        }
        for (String word : minus) {
            if (!result.isEmpty()) {
                HashSet<Integer> docs = invertedIndex.getWordDocs(word);
                minusFilter.filter(result, docs);
            }
        }
    }
}
