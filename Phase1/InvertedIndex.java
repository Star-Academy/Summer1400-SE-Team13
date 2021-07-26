import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private HashMap<String, HashSet<Integer>> wordsMap;

    public InvertedIndex() {
        wordsMap = new HashMap<>();
    }

    public void addDoc(HashSet<String> docWords, int docId) {
        for (String word : docWords) {
            if (word.length() <= 1)
                continue;
            addWord(word);
            addDocID(word, docId);
        }
    }

    private void addDocID(String word, int ID) {
        wordsMap.get(word).add(ID);
    }

    private void addWord(String word) {
        if (!wordsMap.containsKey(word))
            wordsMap.put(word, new HashSet<>());
    }

    public HashSet<Integer> getWordDocs(String word) {
        if (containsWord(word))
            return wordsMap.get(word);
        return null;
    }

    /**
     * check if the word exists in docs
     */
    public boolean containsWord(String word) {
        return wordsMap.containsKey(word);
    }
}